using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace RPGGame
{
    public class SkillController
    {
        public static void SkillLaunch(int SkillId, Actor Launcher, Actor Taget, Vector3 poa)
        {
            //ȡ��Skill���ݣ��õ�����
            DRSkillConfig dRSkillConfig = GameEntry.DataTable.GetDataTable<DRSkillConfig>().GetDataRow(SkillId);
            //���� = skill + ����id
            Assembly assembly = Assembly.GetExecutingAssembly();
            object skill = assembly.CreateInstance("�����ȫ�޶���");
            //�����ó���ȡ����

        }
    }
}
