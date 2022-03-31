using GameFramework;
using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class ActorEquips
    {
        private int m_WeaponId;
        private int m_ArmorId;
        private int m_RingId;

        public int WeaponId => m_WeaponId;
        public int ArmorId => m_ArmorId;
        public int RingId => m_RingId;

        /// <summary> 
        /// </summary>
        /// <param name="x">����id</param>
        /// <param name="y">����id</param>
        /// <param name="z">��Ʒid</param>
        public ActorEquips(int x, int y, int z)
        {
            m_WeaponId = x;
            m_ArmorId = y;
            m_RingId = z;
        }

        public void SetWeapon(int x)
        {
            m_WeaponId = x;
        }

        public void SetArmor(int y)
        {
            m_ArmorId = y;
        }

        public void SetRing(int z)
        {
            m_RingId = z;
        }
    }



    public abstract class Actor : Entity,IComparable
    {
        [SerializeField]
        private ActorData m_ActorData = null;

        public virtual void Awake()
        {
            GameEntry.Event.Subscribe(ActorRoundStartEventArgs.EventId, OnActorRoundStart);
        }
        public ActorData ActorData
        {
            get
            {
                return m_ActorData;
            }
        }

        public int ATK
        {
            get
            {
                return 100;
            }
        }

        public bool IsDead
        {
            get
            {
                return m_ActorData.HP <= 0;
            }
        }

        public abstract ImpactData GetImpactData();

        public void ApplyDamage(Entity attacker, int damageHP)
        {
            m_ActorData.HP -= damageHP;
            if (m_ActorData.HP <= 0)
            {
                OnDead(attacker);
            }
        }


        protected override void OnInit(object userData)
        {
            m_ActorData = userData as ActorData;

            m_ActorData.HP = 100;

            if (m_ActorData == null)
            {
                Log.Error("Actor data is invalid.");
            }
            base.OnInit(userData);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_ActorData = userData as ActorData;
            if(m_ActorData == null)
            {
                Log.Error("Actor data is invalid");
            }

            Name = Utility.Text.Format("Actor ({0})", Id);

            
        }

        protected virtual void OnDead(Entity attacker)
        {
        }


        //actor֮��Ĵ�С�Ƚϰ��������ݵ��ȹ�ֵ���Ƚ�
        public int CompareTo(object obj)
        {
            int result;
            try
            {
                if (this.m_ActorData.Priority >= (obj as Actor).m_ActorData.Priority)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException("�����쳣");
            }
        }


        /// <summary>
        /// ÿ�غϿ�ʼ�ָ�SP
        /// </summary>
        private void RestoreSP()
        {
            ActorData.SP += ActorData.SPRecovery;
        }

        private void OnActorRoundStart(object sender, GameEventArgs e)
        {
            ActorRoundStartEventArgs ne = (ActorRoundStartEventArgs)e;
            if (ne.ActorId != this.ActorData.Id)
            {
                return;
            }

            RestoreSP();
        }
    }
}
