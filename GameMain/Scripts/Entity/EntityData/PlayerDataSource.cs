using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public enum E_AddPointType
    {
        Power = 1,
        Agile = 2,
        Wisdom = 3
    }
    public class PlayerDataSource
    {
        private int m_Id = 0;

        /// <summary>
        /// ��ȡPlayer��š�
        /// </summary>
        public int Id
        {
            get
            {
                return m_Id;
            }
            private set
            {
                m_Id = value;
            }
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        public string Name
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ�ȼ���
        /// </summary>
        public int Lv
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        public int Power
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ���ݡ�
        /// </summary>
        public int Agile
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        public int Wisdom
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ�����������㡣
        /// </summary>
        public int AbilityPoint
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ������
        /// </summary>
        public int Equip1Id
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡͷ����
        /// </summary>
        public int Equip2Id
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ�ؼס�
        /// </summary>
        public int Equip3Id
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ�ۼס�
        /// </summary>
        public int Equip4Id
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ�ȼס�
        /// </summary>
        public int Equip5Id
        {
            get;
            private set;
        }

        /// <summary>
        /// ��ȡ��ָ��
        /// </summary>
        public int Equip6Id
        {
            get;
            private set;
        }
        public PlayerDataSource() 
        {
        }
        public PlayerDataSource(DRPlayer dRPlayer)
        {
            Id = dRPlayer.Id;
            Name = dRPlayer.Name;
            Lv = dRPlayer.Lv;
            Power = dRPlayer.Power;
            Agile = dRPlayer.Agile;
            Wisdom = dRPlayer.Wisdom;
            AbilityPoint = dRPlayer.AbilityPoint;
            Equip1Id = dRPlayer.Equip1Id;
            Equip2Id = dRPlayer.Equip2Id;
            Equip3Id = dRPlayer.Equip3Id;
            Equip4Id = dRPlayer.Equip4Id;
            Equip5Id = dRPlayer.Equip5Id;
            Equip6Id = dRPlayer.Equip6Id;
        }

        public void AddPoint(E_AddPointType pointType, int addValue = 1)
        {
            if (AbilityPoint <= 0) 
            {
                return;
            }
            switch (pointType)
            {
                case E_AddPointType.Power:
                    AbilityPoint -= addValue;
                    Power += addValue;
                    break;
                case E_AddPointType.Agile:
                    AbilityPoint -= addValue;
                    Agile += addValue;
                    break;
                case E_AddPointType.Wisdom:
                    AbilityPoint -= addValue;
                    Wisdom += addValue;
                    break;
            }

        }

        public void SubPoint(E_AddPointType pointType, int subValue = 1)
        {
            if (AbilityPoint <= 0)
            {
                return;
            }
            switch (pointType)
            {
                case E_AddPointType.Power:
                    AbilityPoint += subValue;
                    Power -= subValue;
                    break;
                case E_AddPointType.Agile:
                    AbilityPoint += subValue;
                    Agile -= subValue;
                    break;
                case E_AddPointType.Wisdom:
                    AbilityPoint += subValue;
                    Wisdom -= subValue;
                    break;
            }
        }
    }
}