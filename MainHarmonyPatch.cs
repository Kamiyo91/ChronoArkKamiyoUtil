﻿using System.Linq;
using ChronoArkMod;
using HarmonyLib;

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
        public static void RootStoryScript_Start(object __instance, int Num, string KeyData)
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
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(RootStoryScript));
                    if (item != null) KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
                case KingRoomScript instance:
                    KamiyoArtUtil.PrepareSkin(instance, Num, KeyData);
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(RootStoryScript));
                    if (item != null) KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
                case MasterSDMap instance:
                    KamiyoArtUtil.PrepareSkin(instance, Num, KeyData);
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(RootStoryScript));
                    if (item != null)
                        KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree, item.DialogueTreeFail,
                            item.DialogueTreeShort);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
                case MasterSDMap2 instance:
                    KamiyoArtUtil.PrepareSkin(instance, Num, KeyData);
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(RootStoryScript));
                    if (item != null)
                        KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree, item.DialogueTreeFail);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
                case MasterSDMap3 instance:
                    KamiyoArtUtil.PrepareSkin(instance, Num, KeyData);
                    item = dialogueItem.FirstOrDefault(x => x.DialogueName == nameof(RootStoryScript));
                    if (item != null)
                        KamiyoArtUtil.PrepareDialogue(instance, Num, KeyData, item.DialogueTree, item.DialogueTreeFail);
                    else KamiyoArtUtil.PrepareBlankDialogue(instance, Num, KeyData);
                    break;
            }
        }
    }
}