using System.Collections.Generic;
using Dialogical;
using UnityEngine;

namespace _1ChronoArkKamiyoUtil
{
    public class KamiyoGlobalModParameters
    {
        public static Dictionary<string, List<DialogueFinder>> DialogueTrees =
            new Dictionary<string, List<DialogueFinder>>();

        public static List<VFXSkillModifier> VFXSkillModifier = new List<VFXSkillModifier>();
    }

    public class DialogueFinder
    {
        public string DialogueName { get; set; }
        public DialogueTree DialogueTree { get; set; }
        public DialogueTree DialogueTreeFail { get; set; }
        public DialogueTree DialogueTreeShort { get; set; }
    }

    public class VFXSkillModifier
    {
        public string ModId { get; set; }
        public string SkillId { get; set; }
        public string Path { get; set; }
        public Vector2 Pos { get; set; }
        public string CustomSkin { get; set; }
        public bool IsRemoval { get; set; }
        public bool NeedClone { get; set; }
        public bool RemoveBaseCloneEffects { get; set; }
        public VFXPathEnum VFXClonedEnum { get; set; }
        public string ImageId { get; set; }
    }
}