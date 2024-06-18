using System.Collections.Generic;

namespace _1ChronoArkKamiyoUtil
{
    public class KamiyoSkillChangeParameters
    {
        public KamiyoSkillChangeParameters(int? counting = null, bool? swiftness = null, int? ap = null,
            int? autoDelete = null, List<Skill_Extended> skillExtendeds = null)
        {
            ChangeCounting = new ChangeParametersValue<int> { Change = counting != null, Value = counting ?? 0 };
            ChangeSwiftness = new ChangeParametersValue<bool>
                { Change = swiftness != null, Value = swiftness ?? false };
            ChangeAP = new ChangeParametersValue<int> { Change = ap != null, Value = ap ?? 0 };
            ChangeAutoDelete = new ChangeParametersValue<int> { Change = autoDelete != null, Value = autoDelete ?? 0 };
            SkillExtendeds = skillExtendeds ?? new List<Skill_Extended>();
        }

        public ChangeParametersValue<int> ChangeCounting { get; set; }
        public ChangeParametersValue<bool> ChangeSwiftness { get; set; }
        public ChangeParametersValue<int> ChangeAP { get; set; }
        public ChangeParametersValue<int> ChangeAutoDelete { get; set; }
        public List<Skill_Extended> SkillExtendeds { get; set; }
    }

    public class ChangeParametersValue<T>
    {
        public bool Change { get; set; }
        public T Value { get; set; }
    }
}