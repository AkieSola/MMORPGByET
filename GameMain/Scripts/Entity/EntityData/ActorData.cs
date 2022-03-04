using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class ActorData : EntityData
    {
        [SerializeField]                                
        private int m_HP = 1;                           //����ֵ
        [SerializeField]   
        private int m_SP = 1;                           //�ж�ֵ
        [SerializeField]
        private float m_Priority = 0;                   //�ȹ�ֵ
        [SerializeField]
        private CampType m_Camp = CampType.Unknown;     //��Ӫ
        [SerializeField]
        private int m_Power = 0;                        //����
        [SerializeField]
        private int m_Agile = 0;                        //����
        [SerializeField]
        private int m_Intelligence = 0;                 //����
        [SerializeField]
        private int m_Luck = 0;                         //����
        [SerializeField]
        private int m_PhysicalAtk = 0;                  //������
        [SerializeField]
        private int m_SpellAtk = 0;                     //����ǿ��
        [SerializeField]
        private int m_PhysicalDfs = 0;                  //�������
        [SerializeField]
        private int m_SpellDfs = 0;                     //��������

        public ActorData(int entityId, int typeId, CampType camp) : base(entityId, typeId)
        {
            m_Camp = camp;
            m_HP = 0;
            m_SP = 0;
        }

        /// <summary>
        /// ����ֵ
        /// </summary>
        public int HP { get => m_HP; set => m_HP = Math.Max(0, value); }

        /// <summary>
        /// �������
        /// </summary>
        public abstract int MaxHP
        {
            get;
        }

        /// <summary>
        /// �����ٷֱ�
        /// </summary>
        public float HPRatio
        { 
            get
            {
                return MaxHP > 0 ? (float)HP / MaxHP : 0f;
            }
        }

        /// <summary>
        /// �ж�ֵ
        /// </summary>
        public int SP { get => m_SP; set => m_SP = Math.Max(0, value); }

        /// <summary>
        /// ����ж�ֵ
        /// </summary>
        public abstract int MaxSP
        {
            get;
        }

        /// <summary>
        /// ÿ�غ�SP�Ļָ���
        /// </summary>
        public int SPRecovery
        {
            get => MaxSP >> 1 + 2;
        }

        /// <summary>
        /// �ж�ֵ�ٷֱ�
        /// </summary>
        public float SPRatio
        {
            get
            {
                return MaxSP > 0 ? (float)SP / MaxSP : 0f;
            }
        }

        /// <summary>
        /// �ȹ�
        /// </summary>
        public float Priority { get => m_Priority; set => m_Priority = value; }

        /// <summary>
        /// ��Ӫ
        /// </summary>
        public CampType Camp { get => m_Camp;}
    }
}