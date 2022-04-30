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

public enum E_DamageType
{
    /// <summary>
    /// ����
    /// </summary>
    Physics = 1,
    /// <summary>
    /// ����
    /// </summary>
    Spell = 2,

}

namespace RPGGame {
    public interface ISkillLogic
    {
        public void Launch(SkillConfig skillConfig, Actor Target, Vector3 poa);
        public void Clear(SkillConfig skillConfig, Actor Target, Vector3 poa);
    }
}
