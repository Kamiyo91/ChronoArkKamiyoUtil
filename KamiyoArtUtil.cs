using System.Linq;
using ChronoArkMod.DialogueCreate;
using Dialogical;
using GameDataEditor;
using UnityEngine;

namespace _1ChronoArkKamiyoUtil
{
    public static class KamiyoArtUtil
    {
        public static void PrepareSkin(RootStoryScript instance, int num, string keyData)
        {
            var list = instance.PartySpines.ToList();
            instance.PartyMember_SK[num].skeletonDataAsset = list[2];
            instance.PartyMember_SK[num].Initialize(true);
            instance.PartyMember_SK[num].loop = true;
            var gameObject2 = AddressableLoadManager.Instantiate(
                new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_Object_CampSDObject).Gameobject_Path,
                AddressableLoadManager.ManageType.Stage, instance.PartyMember[num].transform);
            instance.PartyMember[num].gameObject.SetActive(true);
            gameObject2.GetComponent<CampSDObject>().Info = PlayData.TSavedata.Party[num];
            gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
            var path5 = PlayData.TSavedata.Party[num].GetData.CampSD_Path[0];
            if (CharacterSkinData.SkinCheck(PlayData.TSavedata.Party[num].KeyData))
            {
                var skinData = CharacterSkinData.GetSkinData(PlayData.TSavedata.Party[num].KeyData);
                path5 = skinData.CampSD_Path[0];
            }

            AddressableLoadManager.LoadAsyncAction(path5, AddressableLoadManager.ManageType.Stage,
                gameObject2.transform.Find("Char").GetComponent<SpriteRenderer>());
            gameObject2.transform.Find("Light").gameObject.SetActive(false);
            instance.PartyMember_SK[num].gameObject.SetActive(false);
        }

        public static void PrepareSkin(ClockTowerMap instance, int num, string keyData)
        {
            var list = instance.PartySpines.ToList();
            instance.PartyMember_SK[num].skeletonDataAsset = list[2];
            instance.PartyMember_SK[num].Initialize(true);
            instance.PartyMember_SK[num].loop = true;
            var gameObject2 = AddressableLoadManager.Instantiate(
                new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_Object_CampSDObject).Gameobject_Path,
                AddressableLoadManager.ManageType.Stage, instance.PartyMember[num].transform);
            instance.PartyMember[num].gameObject.SetActive(true);
            gameObject2.GetComponent<CampSDObject>().Info = PlayData.TSavedata.Party[num];
            gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
            var path5 = PlayData.TSavedata.Party[num].GetData.CampSD_Path[0];
            if (CharacterSkinData.SkinCheck(PlayData.TSavedata.Party[num].KeyData))
            {
                var skinData = CharacterSkinData.GetSkinData(PlayData.TSavedata.Party[num].KeyData);
                path5 = skinData.CampSD_Path[0];
            }

            AddressableLoadManager.LoadAsyncAction(path5, AddressableLoadManager.ManageType.Stage,
                gameObject2.transform.Find("Char").GetComponent<SpriteRenderer>());
            gameObject2.transform.Find("Light").gameObject.SetActive(false);
            instance.PartyMember_SK[num].gameObject.SetActive(false);
        }

        public static void PrepareSkin(KingRoomScript instance, int num, string keyData)
        {
            var list = instance.PartySpines.ToList();
            instance.PartyMember_SK[num].skeletonDataAsset = list[2];
            instance.PartyMember_SK[num].Initialize(true);
            instance.PartyMember_SK[num].loop = true;
            var gameObject2 = AddressableLoadManager.Instantiate(
                new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_Object_CampSDObject).Gameobject_Path,
                AddressableLoadManager.ManageType.Stage, instance.PartyMember[num].transform);
            instance.PartyMember[num].gameObject.SetActive(true);
            gameObject2.GetComponent<CampSDObject>().Info = PlayData.TSavedata.Party[num];
            gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
            var path5 = PlayData.TSavedata.Party[num].GetData.CampSD_Path[0];
            if (CharacterSkinData.SkinCheck(PlayData.TSavedata.Party[num].KeyData))
            {
                var skinData = CharacterSkinData.GetSkinData(PlayData.TSavedata.Party[num].KeyData);
                path5 = skinData.CampSD_Path[0];
            }

            AddressableLoadManager.LoadAsyncAction(path5, AddressableLoadManager.ManageType.Stage,
                gameObject2.transform.Find("Char").GetComponent<SpriteRenderer>());
            gameObject2.transform.Find("Light").gameObject.SetActive(false);
            instance.PartyMember_SK[num].gameObject.SetActive(false);
        }

        public static void PrepareSkin(MasterSDMap instance, int num, string keyData)
        {
            var list = instance.PartySpines.ToList();
            instance.PartyMember_SK[num].skeletonDataAsset = list[2];
            instance.PartyMember_SK[num].Initialize(true);
            instance.PartyMember_SK[num].loop = true;
            var gameObject2 = AddressableLoadManager.Instantiate(
                new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_Object_CampSDObject).Gameobject_Path,
                AddressableLoadManager.ManageType.Stage, instance.PartyMember[num].transform);
            instance.PartyMember[num].gameObject.SetActive(true);
            gameObject2.GetComponent<CampSDObject>().Info = PlayData.TSavedata.Party[num];
            gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
            var path5 = PlayData.TSavedata.Party[num].GetData.CampSD_Path[0];
            if (CharacterSkinData.SkinCheck(PlayData.TSavedata.Party[num].KeyData))
            {
                var skinData = CharacterSkinData.GetSkinData(PlayData.TSavedata.Party[num].KeyData);
                path5 = skinData.CampSD_Path[0];
            }

            AddressableLoadManager.LoadAsyncAction(path5, AddressableLoadManager.ManageType.Stage,
                gameObject2.transform.Find("Char").GetComponent<SpriteRenderer>());
            gameObject2.transform.Rotate(60, 0, 0);
            gameObject2.transform.Find("Light").gameObject.SetActive(false);
            instance.PartyMember_SK[num].gameObject.SetActive(false);
        }

        public static void PrepareSkin(MasterSDMap2 instance, int num, string keyData)
        {
            var list = instance.PartySpines.ToList();
            instance.PartyMember_SK[num].skeletonDataAsset = list[2];
            instance.PartyMember_SK[num].Initialize(true);
            instance.PartyMember_SK[num].loop = true;
            var gameObject2 = AddressableLoadManager.Instantiate(
                new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_Object_CampSDObject).Gameobject_Path,
                AddressableLoadManager.ManageType.Stage, instance.PartyMember[num].transform);
            instance.PartyMember[num].gameObject.SetActive(true);
            gameObject2.GetComponent<CampSDObject>().Info = PlayData.TSavedata.Party[num];
            gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
            var path5 = PlayData.TSavedata.Party[num].GetData.CampSD_Path[0];
            if (CharacterSkinData.SkinCheck(PlayData.TSavedata.Party[num].KeyData))
            {
                var skinData = CharacterSkinData.GetSkinData(PlayData.TSavedata.Party[num].KeyData);
                path5 = skinData.CampSD_Path[0];
            }

            AddressableLoadManager.LoadAsyncAction(path5, AddressableLoadManager.ManageType.Stage,
                gameObject2.transform.Find("Char").GetComponent<SpriteRenderer>());
            gameObject2.transform.Rotate(60, 0, 0);
            gameObject2.transform.Find("Char").rotation.Set(0, 0, 0, 0);
            gameObject2.transform.Find("Light").gameObject.SetActive(false);
            instance.PartyMember_SK[num].gameObject.SetActive(false);
        }

        public static void PrepareSkin(MasterSDMap3 instance, int num, string keyData)
        {
            var list = instance.PartySpines.ToList();
            instance.PartyMember_SK[num].skeletonDataAsset = list[2];
            instance.PartyMember_SK[num].Initialize(true);
            instance.PartyMember_SK[num].loop = true;
            var gameObject2 = AddressableLoadManager.Instantiate(
                new GDEGameobjectDatasData(GDEItemKeys.GameobjectDatas_Object_CampSDObject).Gameobject_Path,
                AddressableLoadManager.ManageType.Stage, instance.PartyMember[num].transform);
            instance.PartyMember[num].gameObject.SetActive(true);
            gameObject2.GetComponent<CampSDObject>().Info = PlayData.TSavedata.Party[num];
            gameObject2.transform.localScale = new Vector3(1f, 1f, 1f);
            var path5 = PlayData.TSavedata.Party[num].GetData.CampSD_Path[0];
            if (CharacterSkinData.SkinCheck(PlayData.TSavedata.Party[num].KeyData))
            {
                var skinData = CharacterSkinData.GetSkinData(PlayData.TSavedata.Party[num].KeyData);
                path5 = skinData.CampSD_Path[0];
            }

            AddressableLoadManager.LoadAsyncAction(path5, AddressableLoadManager.ManageType.Stage,
                gameObject2.transform.Find("Char").GetComponent<SpriteRenderer>());
            gameObject2.transform.Rotate(60, 0, 0);
            gameObject2.transform.Find("Char").rotation.Set(0, 0, 0, 0);
            gameObject2.transform.Find("Light").gameObject.SetActive(false);
            instance.PartyMember_SK[num].gameObject.SetActive(false);
        }

        public static void PrepareDialogue(MasterSDMap instance, int num, string keyData, DialogueTree dialogueTree,
            DialogueTree failedDialogueTree, DialogueTree dialogueTreeShort)
        {
            var charData = SaveManager.NowData.statistics.GetCharData(keyData);
            if (instance.CheckCrimsonDialogue(keyData))
            {
                instance.PartyMember_Dial[num].tree = failedDialogueTree;
                instance.PartyMember_DialEnd[num].tree = failedDialogueTree;
                instance.PartyTalkMark[num].SetActive(false);
            }
            else
            {
                instance.PartyMember_Dial[num].tree = dialogueTree;
                instance.PartyMember_Dial[num].IsSkip = true;
                instance.PartyMember_Dial[num].DialogueEnd.AddListener(delegate
                {
                    instance.PartyTalkMark[num].SetActive(false);
                    if (charData.FriendshipLV != 4)
                        UIManager.InstantiateActiveAddressable(UIManager.inst.CompleteUI,
                                AddressableLoadManager.ManageType.EachStage).GetComponent<FriendShipCompleteUI>()
                            .MaxLevel(keyData);
                    PlayData.IsSkip = false;
                });
                instance.PartyMember_DialEnd[num].tree = dialogueTreeShort;
                instance.PartyTalkMark[num].SetActive(charData.FriendshipLV != 4);
            }
        }

        public static void PrepareDialogue(MasterSDMap3 instance, int num, string keyData, DialogueTree dialogueTree,
            DialogueTree failedDialogueTree)
        {
            if (instance.CheckCrimsonDialogue(keyData))
            {
                instance.PartyMember_Dial[num].tree = failedDialogueTree;
                instance.PartyMember_Dial[num].DialogueEnd.RemoveAllListeners();
            }
            else
            {
                instance.PartyMember_Dial[num].tree = dialogueTree;
                instance.PartyMember_Dial[num].DialogueEnd.AddListener(delegate { PlayData.IsSkip = false; });
            }
        }

        public static void PrepareDialogue(MasterSDMap2 instance, int num, string keyData, DialogueTree dialogueTree,
            DialogueTree failedDialogueTree)
        {
            instance.PartyMember_Dial[num].tree =
                instance.CheckCrimsonDialogue(keyData) ? failedDialogueTree : dialogueTree;
        }

        public static void PrepareDialogue(RootStoryScript instance, int num, string keyData, DialogueTree dialogueTree)
        {
            instance.NowChars.Add(SaveManager.NowData.statistics.GetCharData(PlayData.TSavedata.Party[num].KeyData));
            instance.PartyTalkMark[num].SetActive(!instance.NowChars[num].IsCrimsonDialogue);
            instance.PartyMember_EO[num].TargetEvent.AddListener(instance.CallSkipNotice);
            instance.PartyMember_Dial[num].tree = dialogueTree;
            instance.PartyMember_Dial[num].DialogueEnd.AddListener(instance.DialogueEndDel);
        }

        public static void PrepareDialogue(ClockTowerMap instance, int num, string keyData, DialogueTree dialogueTree)
        {
            instance.PartyMember_Dial[num].tree = dialogueTree;
        }

        public static void PrepareDialogue(KingRoomScript instance, int num, string keyData, DialogueTree dialogueTree)
        {
            instance.PartyMember_Dial[num].tree = dialogueTree;
        }

        public static void PrepareBlankDialogue(MasterSDMap instance, int num, string keyData)
        {
            var dialogueTree = DialogueCreator.CreateDialogueTree<EmptyDialogueTree>();
            var charData = SaveManager.NowData.statistics.GetCharData(keyData);
            if (instance.CheckCrimsonDialogue(keyData))
            {
                instance.PartyMember_Dial[num].tree = dialogueTree;
                instance.PartyMember_DialEnd[num].tree = dialogueTree;
                instance.PartyTalkMark[num].SetActive(false);
            }
            else
            {
                instance.PartyMember_Dial[num].tree = dialogueTree;
                instance.PartyMember_Dial[num].IsSkip = true;
                instance.PartyMember_Dial[num].DialogueEnd.AddListener(delegate
                {
                    instance.PartyTalkMark[num].SetActive(false);
                    if (charData.FriendshipLV != 4)
                        UIManager.InstantiateActiveAddressable(UIManager.inst.CompleteUI,
                                AddressableLoadManager.ManageType.EachStage).GetComponent<FriendShipCompleteUI>()
                            .MaxLevel(keyData);
                    PlayData.IsSkip = false;
                });
                instance.PartyMember_DialEnd[num].tree = dialogueTree;
                instance.PartyTalkMark[num].SetActive(charData.FriendshipLV != 4);
            }
        }

        public static void PrepareBlankDialogue(MasterSDMap2 instance, int num, string keyData)
        {
            var dialogueTree = DialogueCreator.CreateDialogueTree<EmptyDialogueTree>();
            instance.PartyMember_Dial[num].tree = dialogueTree;
        }

        public static void PrepareBlankDialogue(MasterSDMap3 instance, int num, string keyData)
        {
            var dialogueTree = DialogueCreator.CreateDialogueTree<EmptyDialogueTree>();
            if (instance.CheckCrimsonDialogue(keyData))
            {
                instance.PartyMember_Dial[num].tree = dialogueTree;
                instance.PartyMember_Dial[num].DialogueEnd.RemoveAllListeners();
            }
            else
            {
                instance.PartyMember_Dial[num].tree = dialogueTree;
                instance.PartyMember_Dial[num].DialogueEnd.AddListener(delegate { PlayData.IsSkip = false; });
            }
        }

        public static void PrepareBlankDialogue(ClockTowerMap instance, int num, string keyData)
        {
            var dialogueTree = DialogueCreator.CreateDialogueTree<EmptyDialogueTree>();
            instance.PartyMember_Dial[num].tree = dialogueTree;
        }

        public static void PrepareBlankDialogue(KingRoomScript instance, int num, string keyData)
        {
            var dialogueTree = DialogueCreator.CreateDialogueTree<EmptyDialogueTree>();
            instance.PartyMember_Dial[num].tree = dialogueTree;
        }

        public static void PrepareBlankDialogue(RootStoryScript instance, int num, string keyData)
        {
            var dialogueTree = DialogueCreator.CreateDialogueTree<EmptyDialogueTree>();
            instance.NowChars.Add(SaveManager.NowData.statistics.GetCharData(PlayData.TSavedata.Party[num].KeyData));
            instance.PartyTalkMark[num].SetActive(!instance.NowChars[num].IsCrimsonDialogue);
            instance.PartyMember_EO[num].TargetEvent.AddListener(instance.CallSkipNotice);
            instance.PartyMember_Dial[num].tree = dialogueTree;
            instance.PartyMember_Dial[num].DialogueEnd.AddListener(instance.DialogueEndDel);
        }
    }
}