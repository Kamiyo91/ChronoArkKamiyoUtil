using System.Collections;
using System.Linq;
using ChronoArkMod.DialogueCreate;
using ChronoArkMod.ModData;
using UnityEngine;

namespace _1ChronoArkKamiyoUtil
{
    public static class KamiyoUtil
    {
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

        public static IEnumerator PassiveAttack(Skill skill, BattleChar target)
        {
            yield return new WaitForSeconds(0.2f);
            if (BattleSystem.instance.EnemyList.Count != 0)
                yield return BattleSystem.instance.ForceAction(skill, target, false, false, true);
        }
    }
}