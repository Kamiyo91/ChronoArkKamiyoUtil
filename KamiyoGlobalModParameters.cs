using System.Collections.Generic;
using Dialogical;

namespace _1ChronoArkKamiyoUtil
{
    public class KamiyoGlobalModParameters
    {
        public static Dictionary<string, List<DialogueFinder>> DialogueTrees =
            new Dictionary<string, List<DialogueFinder>>();

        public static List<string> VFXSkillHide = new List<string>();
    }

    public class DialogueFinder
    {
        public string DialogueName { get; set; }
        public DialogueTree DialogueTree { get; set; }
        public DialogueTree DialogueTreeFail { get; set; }
        public DialogueTree DialogueTreeShort { get; set; }
    }
}