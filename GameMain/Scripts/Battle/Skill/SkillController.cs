using GameFramework;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RPGGame
{
    public class SkillController
    {

        public static Skill CreateSkill(int SkillId, Actor Launcher)
        {
            //ȡ��Skill���ݣ��õ�����
            DRSkillConfig dRSkillConfig = GameEntry.DataTable.GetDataTable<DRSkillConfig>().GetDataRow(SkillId);
            Assembly assembly = Assembly.GetExecutingAssembly();
            Skill skill = assembly.CreateInstance("Skill00" + SkillId) as Skill;
            skill.Init(dRSkillConfig, Launcher);
            return skill;
        }
    }
}
