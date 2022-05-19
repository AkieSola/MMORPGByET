using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// Playerͨ�����Ե㣨�������ԣ�+װ��ӳ�䵽ActorData�Ļ�������
    /// NPC��Enemyͨ�������������ЩActorData�Ļ�������
    /// </summary>
    public abstract class ActorData : EntityData
    {
        [SerializeField]
        private int m_Id;       
        [SerializeField]
        private int m_HP = 1;                           //����ֵ
        [SerializeField]
        private int m_MaxHP = 1;                        //�������
        [SerializeField]
        private int m_SP = 1;                           //�ж�ֵ
        [SerializeField]
        private int m_MaxSp = 1;                        //����ж�
        [SerializeField]
        private float m_Priority = 0;                   //�ȹ�ֵ
        [SerializeField]
        private float m_Atk = 1;                        //������
        [SerializeField]
        private float m_SpellAtk = 1;                   //����ǿ��
        [SerializeField]
        private float m_AtkDistance = 1;                //��������
        [SerializeField]
        private float m_PhysicsDfs = 0;                 //������
        [SerializeField]
        private float m_SpellDfs = 0;                   //ħ������
        [SerializeField]
        private CampType m_Camp = CampType.Unknown;     //��Ӫ


        public ActorData(int entityId, int typeId) : base(entityId, typeId)
        {

        }

        public float Speed { get; set; }
        public int ActorId { get => m_Id; set => m_Id = value; }
        public int HP { get => m_HP; set => m_HP = Math.Min(Math.Max(0, value), MaxHP); }
        public int MaxHP { get => m_MaxHP; set => m_MaxHP = value; }
        public int SP { get => m_SP; set => m_SP = Math.Min(Math.Max(0, value), MaxSP); }
        public int MaxSP { get => m_MaxSp; set => m_MaxSp = value; }
        public float Priority { get => m_Priority; set => m_Priority = value; }
        public float Atk { get => m_Atk; set => m_Atk = Math.Max(0, value); }
        public float SpellAtk { get => m_SpellAtk; set => m_SpellAtk = value; }
        public float AtkDistance { get => m_AtkDistance; set => m_AtkDistance = Math.Max(0, value); }
        public float PhysicsDfs { get => m_PhysicsDfs; set => m_PhysicsDfs = value; }
        public float SpellDfs { get => m_SpellDfs; set => m_SpellDfs = value; }

        /// <summary>
        /// ����ֵ�ٷֱ�
        /// </summary>
        public float HPRatio { get => Math.Max(0, (float)m_HP / (float)m_MaxHP); }
        /// <summary>
        /// SPֵ�ٷֱ�
        /// </summary>
        public float SPRatio { get => Math.Max(0, (float)m_SP / (float)m_MaxSp); }
        /// <summary>
        /// �￹�ٷֱ�
        /// </summary>
        public float PhysicsDfsRatio { get => (float)PhysicsDfs / (float)(100 + PhysicsDfs); }
        /// <summary>
        /// ħ���ٷֱ�
        /// </summary>
        public float SpellDfsRatio { get => (float)SpellDfs / (float)(100 + SpellDfs); }
        /// <summary>
        /// ��ɫ�Ƿ�����
        /// </summary>
        public bool IsDead { get => m_HP <= 0; }
       
    }
}