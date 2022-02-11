using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class ActorData : EntityData
    {
        [SerializeField]
        private int m_HP = 0;
        [SerializeField]
        private int m_SP = 0;

        [SerializeField]
        private CampType m_Camp = CampType.Unknown;
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
        /// �ж�ֵ
        /// </summary>
        public int SP { get => m_SP; set => m_SP = value; }

        /// <summary>
        /// ����ж�ֵ
        /// </summary>
        public abstract int MaxSP
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
        /// ��Ӫ
        /// </summary>
        public CampType Camp { get => m_Camp;}
    }
}