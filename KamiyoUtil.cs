using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _1ChronoArkKamiyoUtil
{
    public static class KamiyoUtil
    {
        public static CastingSkill GetCastingSkill<T>(BattleChar owner) where T : Skill_Extended
        {
            var skill = BattleSystem.instance.SaveSkill.FirstOrDefault(x =>
                x.Usestate == owner && x.skill.AllExtendeds.Any(y => y is T));
            if (skill != null) return skill;
            skill = BattleSystem.instance.CastSkills.FirstOrDefault(x =>
                x.Usestate == owner && x.skill.AllExtendeds.Any(y => y is T));
            return skill;
        }

        public static void Counter(BattleChar target, CastingSkill CastingSkill, bool draw, bool restoreMana)
        {
            if (draw) BattleSystem.instance.AllyTeam.Draw(1);
            if (restoreMana) BattleSystem.instance.AllyTeam.AP += 1;
            switch (target.Info.Ally)
            {
                case true:
                    BattleSystem.instance.ActWindow.CastingWaste(CastingSkill.skill);
                    BattleSystem.instance.CastSkills.Remove(CastingSkill);
                    BattleSystem.instance.SaveSkill.Remove(CastingSkill);
                    return;
                case false when !target.IsDead:
                    CastingSkill.Target = target;
                    BattleSystem.DelayInput(Counter(CastingSkill));
                    return;
            }
        }

        private static IEnumerator Counter(CastingSkill CastingSkill)
        {
            yield return BattleSystem.instance.StartCoroutine(
                BattleSystem.instance.AllyCastingSkillUse(CastingSkill, false));
            BattleSystem.instance.CastSkills.Remove(CastingSkill);
            BattleSystem.instance.SaveSkill.Remove(CastingSkill);
            yield return null;
        }

        public static void DrawCharacterSkill(BattleChar bChar, Skill skill, int quantity = 1, bool notDraw = true)
        {
            for (var i = 0; i < quantity; i++) bChar.MyTeam.Add(skill.CloneSkill(), notDraw);
        }

        public static string CreateDialogPath<T>(ModInfo modInfo) where T : DialogueCreator
        {
            var dialogue = DialogueCreator.CreateDialogueTree<T>();
            return modInfo.assetInfo.ConstructObjectByCode(dialogue);
        }

        public static string GetImagePath(ModAssetInfo assetInfo, string path, Vector2 pos)
        {
            return assetInfo.ChangeSpritePivot(assetInfo.ImageFromFile(path), pos);
        }

        public static void IncreaseEnemyActionCountByValue(int value, bool allEnemies = true, BattleChar target = null)
        {
            foreach (var enemy in BattleSystem.instance.EnemyTeam.GetAliveChars()
                         .Where(x => x is BattleEnemy && (allEnemies || (target != null && x == target)))
                         .Select(x => x as BattleEnemy))
            {
                if (enemy == null) continue;
                foreach (var skill in enemy.SkillQueue)
                    skill.CastSpeed += value;
            }
        }

        public static void AdditionalAttack(BattleChar bChar, BattleChar target, Skill skill, int quantity = 1)
        {
            for (var i = 0; i < quantity; i++) BattleSystem.DelayInput(PassiveAttack(skill, target));
        }

        public static IEnumerator PassiveAttack(Skill skill, BattleChar target)
        {
            yield return new WaitForSeconds(0.2f);
            if (BattleSystem.instance.EnemyList.Count != 0)
                yield return BattleSystem.instance.ForceAction(skill, target, false, false, true);
        }

        public static void AddShieldValue(BattleChar bChar, string shieldBuffKeyword, int quantity)
        {
            bChar.BuffAdd(shieldBuffKeyword, bChar);
            bChar.BuffReturn(shieldBuffKeyword).BarrierHP += quantity;
        }

        public static void DrawPrefCharacterSkillFromDeck(BattleChar bChar)
        {
            var skillList = BattleSystem.instance.AllyTeam.Skills_Deck.Where(x => x.Master == bChar).ToList();
            var skill = skillList[Random.Range(0, skillList.Count)];
            if (skill != null) BattleSystem.instance.AllyTeam.Draw(skill);
            else BattleSystem.instance.AllyTeam.Draw(1);
        }

        public static T GetBuff<T>(BattleChar bChar, string keyword, bool addNewIfNotFound = true) where T : Buff
        {
            var buff = !bChar.BuffFind(keyword) && addNewIfNotFound
                ? bChar.BuffAdd(keyword, bChar, true)
                : bChar.Buffs.FirstOrDefault(x => x is T);
            return buff as T;
        }

        public static Skill PrepareSkill(BattleChar bChar, string keyword, KamiyoSkillChangeParameters p,
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

        public static Skill PrepareRandomSkill(BattleChar bChar, List<string> keywords, KamiyoSkillChangeParameters p,
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
    }
}