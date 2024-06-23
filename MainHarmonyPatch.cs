using System.Collections.Generic;
using System.Linq;
using ChronoArkMod;
using HarmonyLib;
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
        public static void InstanceMap_Start(object __instance, int Num, string KeyData)
        {
            if (!ModManager.IsModAddedGDE(PlayData.TSavedata.Party[Num].KeyData)) return;
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
            if (!KamiyoGlobalModParameters.VFXSkillHide.Contains(skill.MySkill.KeyID)) return;
            foreach (var obj in __instance.SpacialCGMainCharacter) Object.Destroy(obj);
        }
    }
}