using System.Collections.Generic;
using System.Linq;
using ChronoArkMod;
using HarmonyLib;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _1ChronoArkKamiyoUtil
{
    [HarmonyPatch]
    public class MainHarmonyPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch(typeof(RootStoryScript), nameof(RootStoryScript.PartySpine))]
        [HarmonyPatch(typeof(ClockTowerMap), nameof(ClockTowerMap.PartySpine))]
        [HarmonyPatch(typeof(KingRoomScript), nameof(KingRoomScript.PartySpine))]
        [HarmonyPatch(typeof(MasterSDMap), nameof(MasterSDMap.PartySpine))]
        [HarmonyPatch(typeof(MasterSDMap2), nameof(MasterSDMap2.PartySpine))]
        [HarmonyPatch(typeof(MasterSDMap3), nameof(MasterSDMap2.PartySpine))]
        public static void InstanceMap_PartySpine(object __instance, int Num, string KeyData)
        {
            if (PlayData.TSavedata == null || PlayData.TSavedata.Party == null ||
                !PlayData.TSavedata.Party.IsSafeAccess(Num) ||
                !ModManager.IsModAddedGDE(PlayData.TSavedata.Party[Num].KeyData)) return;
            var tryGetDialogs = KamiyoGlobalModParameters.DialogueTrees.TryGetValue(KeyData, out var dialogueItem);
            DialogueFinder item;
            if (!tryGetDialogs) return;
            switch (__instance)
            {
                case RootStoryScript instance:
                    KamiyoArtUtil.PrepareSkin(instance, Num, KeyData);
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(RootStoryScript));
                    if (item != null) KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
                case ClockTowerMap instance:
                    KamiyoArtUtil.PrepareSkin(instance, Num, KeyData);
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(ClockTowerMap));
                    if (item != null) KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
                case KingRoomScript instance:
                    KamiyoArtUtil.PrepareSkin(instance, Num, KeyData);
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(KingRoomScript));
                    if (item != null) KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
                case MasterSDMap instance:
                    KamiyoArtUtil.PrepareSkin(instance, Num, KeyData);
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(MasterSDMap));
                    if (item != null)
                        KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree, item.DialogueTreeFail,
                            item.DialogueTreeShort);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
                case MasterSDMap2 instance:
                    KamiyoArtUtil.PrepareSkin(instance, Num, KeyData);
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(MasterSDMap2));
                    if (item != null)
                        KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree, item.DialogueTreeFail);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
                case MasterSDMap3 instance:
                    KamiyoArtUtil.PrepareSkin(instance, Num, KeyData);
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(MasterSDMap3));
                    if (item != null)
                        KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree, item.DialogueTreeFail);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
            }
        }

        [HarmonyPrefix]
        [HarmonyPatch(typeof(SkillParticle), nameof(SkillParticle.init), typeof(Skill), typeof(BattleChar),
            typeof(List<BattleChar>))]
        public static void SkillParticle_init(SkillParticle __instance, Skill skill, BattleChar User,
            List<BattleChar> Target)
        {
            if (skill?.MySkill == null || string.IsNullOrEmpty(skill.MySkill.KeyID)) return;
            var modifier =
                KamiyoGlobalModParameters.VFXSkillModifier.FirstOrDefault(x => x.SkillId == skill.MySkill.KeyID);
            if (modifier == null) return;
            if (modifier.IsRemoval)
            {
                foreach (var obj in __instance.SpacialCGMainCharacter) Object.Destroy(obj);
                return;
            }

            if (!string.IsNullOrEmpty(modifier.CustomSkin) && !SaveManager.NowData.EnableSkins.Any(x =>
                    x.charKey == User.Info.KeyData && x.skinKey == modifier.CustomSkin)) return;
            var assetInfo = ModManager.getModInfo(modifier.ModId).assetInfo;
            var imageObj = __instance.SpacialCGMainCharacter.FirstOrDefault(x => x.name == "AzarMotion");
            if (modifier.NeedClone)
            {
                var path = modifier.VFXClonedEnum.GetVFXPathByEnum();
                if (string.IsNullOrEmpty(path)) return;
                var enemy = Target.FirstOrDefault() as BattleEnemy;
                if (enemy == null) return;
                var vector = new Vector3(enemy.MyUIObject.custom.Center.parent.position.x,
                    enemy.MyUIObject.custom.Center.parent.position.y, enemy.MyUIObject.custom.Center.parent.position.z);
                var imageObj2 =
                    AddressableLoadManager.Instantiate(path, AddressableLoadManager.ManageType.Battle, vector);
                if (modifier.RemoveBaseCloneEffects)
                {
                    foreach (var obj in imageObj2.GetComponentsInChildren<ParticleSystem>(true)) Object.Destroy(obj);
                    foreach (var obj in imageObj2.GetComponentsInChildren<ParticleSystemRenderer>(true))
                        Object.Destroy(obj);
                }

                var spComponent = imageObj2.GetComponent<SkillParticle>();
                __instance.SpacialCGMainCharacter = spComponent.SpacialCGMainCharacter;
                __instance.SpacialCGCam = spComponent.SpacialCGCam;
                __instance.IsSpacialCG = true;
                __instance.GroundOut = true;
                imageObj = __instance.SpacialCGMainCharacter.FirstOrDefault(x => x.name == "AzarMotion");
            }

            if (imageObj == null) return;
            var image = KamiyoUtil.GetImagePath(assetInfo, modifier.Path, modifier.Pos, modifier);
            var modImageInfo = assetInfo.ModImageInfos.FirstOrDefault(x => x.Key == image);
            var components = imageObj.GetComponents<SpriteRenderer>();
            var componentsChildren = imageObj.GetComponentsInChildren<SpriteRenderer>(true);
            foreach (var component in componentsChildren) component.sprite = modImageInfo.Value.Get();
            foreach (var component in components) component.sprite = modImageInfo.Value.Get();
        }
    }
}