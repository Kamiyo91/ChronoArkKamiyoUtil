using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _1ChronoArkKamiyoUtil
{
    public static class KamiyoUtilExtensions
    {
        public static CastingSkill GetCastingSkill<T>(this BattleChar owner) where T : Skill_Extended
        {
            var skill = BattleSystem.instance.SaveSkill.FirstOrDefault(x =>
                x.Usestate == owner && x.skill.AllExtendeds.Any(y => y is T));
            if (skill != null) return skill;
            skill = BattleSystem.instance.CastSkills.FirstOrDefault(x =>
                x.Usestate == owner && x.skill.AllExtendeds.Any(y => y is T));
            return skill;
        }

        public static void DrawCharacterSkill(this BattleChar bChar, Skill skill, int quantity = 1, bool notDraw = true)
        {
            for (var i = 0; i < quantity; i++) bChar.MyTeam.Add(skill.CloneSkill(), notDraw);
        }

        public static void AdditionalAttack(this BattleChar bChar, BattleChar target, Skill skill, int quantity = 1)
        {
            for (var i = 0; i < quantity; i++) BattleSystem.DelayInput(KamiyoUtil.PassiveAttack(skill, target));
        }

        public static void AddShieldValue(this BattleChar bChar, string shieldBuffKeyword, int quantity)
        {
            bChar.BuffAdd(shieldBuffKeyword, bChar);
            bChar.BuffReturn(shieldBuffKeyword).BarrierHP += quantity;
        }

        public static void DrawPrefCharacterSkillFromDeck(this BattleChar bChar)
        {
            var skillList = BattleSystem.instance.AllyTeam.Skills_Deck.Where(x => x.Master == bChar).ToList();
            var skill = skillList[Random.Range(0, skillList.Count)];
            if (skill != null) BattleSystem.instance.AllyTeam.Draw(skill);
            else BattleSystem.instance.AllyTeam.Draw(1);
        }

        public static T GetBuff<T>(this BattleChar bChar, string keyword, bool hide = false,
            bool addNewIfNotFound = true)
            where T : Buff
        {
            var buff = !bChar.BuffFind(keyword) && addNewIfNotFound
                ? bChar.BuffAdd(keyword, bChar, hide)
                : bChar.Buffs.FirstOrDefault(x => x is T);
            return buff as T;
        }

        public static T GetBuffTarget<T>(this BattleChar target, BattleChar buffer, string keyword, bool hide = false,
            bool addNewIfNotFound = true) where T : Buff
        {
            var buff = !target.BuffFind(keyword) && addNewIfNotFound
                ? target.BuffAdd(keyword, buffer, hide)
                : target.Buffs.FirstOrDefault(x => x is T);
            return buff as T;
        }

        public static Skill PrepareSkill(this BattleChar bChar, string keyword, KamiyoSkillChangeParameters p,
            bool isExcept = true)
        {
            var skill = Skill.TempSkill(keyword, bChar, bChar.MyTeam);
            if (p.ChangeAP.Change) skill.AP = p.ChangeAP.Value;
            if (p.ChangeCounting.Change) skill.Counting = p.ChangeCounting.Value;
            if (p.ChangeSwiftness.Change) skill.NotCount = p.ChangeSwiftness.Value;
            if (p.ChangeAutoDelete.Change) skill.AutoDelete = p.ChangeAutoDelete.Value;
            foreach (var ex in p.SkillExtendeds) skill.ExtendedAdd(ex);
            skill.isExcept = isExcept;
            return skill;
        }

        public static Skill PrepareRandomSkill(this BattleChar bChar, List<string> keywords,
            KamiyoSkillChangeParameters p,
            bool isExcept = true)
        {
            var keyword = keywords[Random.Range(0, keywords.Count)];
            var skill = Skill.TempSkill(keyword, bChar, bChar.MyTeam);
            if (p.ChangeAP.Change) skill.AP = p.ChangeAP.Value;
            if (p.ChangeCounting.Change) skill.Counting = p.ChangeCounting.Value;
            if (p.ChangeSwiftness.Change) skill.NotCount = p.ChangeSwiftness.Value;
            if (p.ChangeAutoDelete.Change) skill.AutoDelete = p.ChangeAutoDelete.Value;
            foreach (var ex in p.SkillExtendeds) skill.ExtendedAdd(ex);
            skill.isExcept = isExcept;
            return skill;
        }

        public static bool IsSafeAccess<T>(this IList<T> list, int index)
        {
            return index >= 0 && index < list.Count;
        }
    }
}