using System;
using ChronoArkMod.DialogueCreate;

namespace _1ChronoArkKamiyoUtil
{
    public class EmptyDialogueTree : DialogueCreator
    {
        public override Type FirstNodeCreatorType => typeof(EmptyDialogueTreeN1);
    }

    public class EmptyDialogueTreeN1 : DialogueNodeCreator
    {
        public override DialogueNodeParameter SetDialogueNodeParameter()
        {
            return new DialogueNodeParameter
            {
                Text = ""
            };
        }
    }
}