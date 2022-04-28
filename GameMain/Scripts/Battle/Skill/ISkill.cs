using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_SkillType
{
    /// <summary>
    /// ѡ����
    /// </summary>
    Select = 1,
    /// <summary>
    /// ָ����
    /// </summary>
    Arrow = 2,
    /// <summary>
    /// ��Χ��
    /// </summary>
    Range = 3,
    /// <summary>
    /// ֻ���Լ�ΪĿ��
    /// </summary>
    Normal = 4
}

namespace RPGGame {
    public interface ISkill
    {
        public int SkillId { get; set; }

        public int Init(DRSkillConfig dRSkillConfig);
    }
}
