using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public enum E_EquipType
    {
        weapon = 1,
        cloth = 2,

    }

    public enum E_EquipRare
    {

    }
    public class EquipData : EntityData
    {
        [SerializeField]
        private int m_Id = 0;      //װ��ID

        [SerializeField]
        private string m_EquipName = "";    //װ������

        [SerializeField]
        private string m_EquipDescription = "";     //װ������

        [SerializeField]
        private string m_EquipPath = "";    //��Դ����

        [SerializeField]
        private int m_PhysicsAttack = 0;    //���������ӳ�

        [SerializeField]
        private int m_SpellAttack = 0;      //ħ���������ӳ�

        [SerializeField]
        private int m_PhysicsDefense = 0;   //�����Լӳ�

        [SerializeField]
        private int m_SpellDefense = 0;     //ħ�����Լӳ�

        [SerializeField]
        private int m_Level = 0;    //װ���ȼ�

        [SerializeField]
        private int m_EquipType = 0;    //װ������ 
        /// 0 ������
        /// 1 ����
        /// 2 ����
        [SerializeField]
        private int m_SubEquipType;  //װ��������             

        [SerializeField]
        private int m_EquipRare;    //ϡ�ж�
                                    /// 1 ��ͨ
                                    /// 2 ϡ��
                                    /// 3 ʷʫ
                                    /// 4 ��˵

        public EquipData(int entityId, int typeId, int ownerId) : base(entityId, typeId)
        {

        }
    }
}
