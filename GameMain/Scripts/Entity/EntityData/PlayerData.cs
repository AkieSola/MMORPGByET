using GameFramework.DataTable;
using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{

    /// <summary>
    /// ������ɫ�ӵĵ�
    /// </summary>
    public class PlayerData : ActorData
    {
        [SerializeField]
        private int m_Id;
        [SerializeField]
        private string m_Name;
        [SerializeField]
        private int m_Lv;        //�ȼ� = ֱ������MaxHP, ����Atk
        [SerializeField]
        private int m_Power;        //���� = ����MaxHP, ���ӻ���, ��������������
        [SerializeField]
        private int m_Agile;        //���� = �����ȹ�,  ����MaxSP, ��������������
        [SerializeField]
        private int m_Wisdom;       //���� = ����MaxSP�� ����ħ��,  ����ħ��������
        //[SerializeField]
        //private int m_Faith;      
        [SerializeField]
        private int m_AbilityAddPoint;
        [SerializeField]
        private Dictionary<EquipType, DREquip> m_PlayerEquips;       //��ɫ��װ��
        [SerializeField]
        private List<int> m_SkillIdList;

        private int baseMaxHP = 100;
        private int baseMaxSP = 10;
        private int baseATK = 10;
        private float m_LvPowAddHP = 1.2f;

        public PlayerDataSource playerDataSource;
        public PlayerData(PlayerDataSource pdSource, int entityId, int typeId) : base(entityId, typeId)
        {
            playerDataSource = pdSource;

            Id1 = pdSource.Id;
            Name = pdSource.Name;
            Lv = pdSource.Lv;
            Power = pdSource.Power;
            Agile = pdSource.Agile;
            Wisdom = pdSource.Wisdom;
            AbilityAddPoint = pdSource.AbilityPoint;

            IDataTable<DREquip> dtEquip = GameEntry.DataTable.GetDataTable<DREquip>();
            PlayerEquips = new Dictionary<EquipType, DREquip>()
            {
                {EquipType.weapon, dtEquip.GetDataRow(pdSource.Equip1Id) },
                {EquipType.helmet, dtEquip.GetDataRow(pdSource.Equip2Id) },
                {EquipType.breastplate, dtEquip.GetDataRow(pdSource.Equip3Id) },
                {EquipType.gardebras, dtEquip.GetDataRow(pdSource.Equip4Id) },
                {EquipType.cuisse, dtEquip.GetDataRow(pdSource.Equip5Id) },
                {EquipType.ring, dtEquip.GetDataRow(pdSource.Equip6Id) }
            };

            SkillIdList = new List<int>() 
            {
                pdSource.Skill1Id, pdSource.Skill2Id, pdSource.Skill3Id, pdSource.Skill4Id, 
                pdSource.Skill5Id, pdSource.Skill6Id, pdSource.Skill7Id, pdSource.Skill8Id 
            };

            base.ActorId = Id1;
            base.MaxHP = (int)(baseMaxHP * Mathf.Pow(m_LvPowAddHP, LvPowAddHP) + Power * 20); //+װ���ӳ�
            base.Priority = 5 + Agile;
            base.MaxSP = baseMaxSP + (int)(Agile*0.33);
            base.Atk = baseATK;
            base.SpellAtk = 0;
            base.AtkDistance = 10.0f;
            base.PhysicsDfs = 0 + Power;
            base.SpellDfs = 0 + Wisdom;
            base.HP = MaxHP;
            base.SP = MaxSP;

            GameEntry.Event.Subscribe(PlayerAddAbilityPointDataEventArgs.EventId, OnPointAdd);
        }

        private void OnPointAdd(object sender, GameEventArgs e)
        {
            E_AddPointType pointType;
            int addValue = 0;
            if (e != null && e is PlayerAddAbilityPointDataEventArgs) 
            {
                pointType = (e as PlayerAddAbilityPointDataEventArgs).pointType;
                addValue = (e as PlayerAddAbilityPointDataEventArgs).value;

                playerDataSource.AddPoint(pointType, addValue);
                PlayerDataReset(playerDataSource);
            }
  
        }

        public void PlayerDataReset(PlayerDataSource pdSource)
        {
            playerDataSource = pdSource;

            Id1 = pdSource.Id;
            Name = pdSource.Name;
            Lv = pdSource.Lv;
            Power = pdSource.Power;
            Agile = pdSource.Agile;
            Wisdom = pdSource.Wisdom;
            AbilityAddPoint = pdSource.AbilityPoint;

            IDataTable<DREquip> dtEquip = GameEntry.DataTable.GetDataTable<DREquip>();
            PlayerEquips = new Dictionary<EquipType, DREquip>()
            {
                {EquipType.weapon, dtEquip.GetDataRow(pdSource.Equip1Id) },
                {EquipType.helmet, dtEquip.GetDataRow(pdSource.Equip2Id) },
                {EquipType.breastplate, dtEquip.GetDataRow(pdSource.Equip3Id) },
                {EquipType.gardebras, dtEquip.GetDataRow(pdSource.Equip4Id) },
                {EquipType.cuisse, dtEquip.GetDataRow(pdSource.Equip5Id) },
                {EquipType.ring, dtEquip.GetDataRow(pdSource.Equip6Id) }
            };

            base.ActorId = Id1;
            base.MaxHP = (int)(baseMaxHP * Mathf.Pow(m_LvPowAddHP, LvPowAddHP) + Power * 20); //+װ���ӳ�
            base.Priority = 5 + Agile;
            base.MaxSP = baseMaxHP + (int)(Agile * 0.33);
            base.Atk = baseATK;
            base.SpellAtk = 0;
            base.AtkDistance = 10.0f;
            base.PhysicsDfs = 0 + Power;
            base.SpellDfs = 0 + Wisdom;

            GameEntry.Event.Fire(this, PlayerAddAbilityPointFormEventArgs.Create(this));
        }
       

        public int BaseMaxHP { get => baseMaxHP; }
        public int BaseMaxSP { get => baseMaxSP; }
        public float LvPowAddHP { get => m_LvPowAddHP; }
        public int Id1 { get => m_Id; set => m_Id = value; }
        public string Name { get => m_Name; set => m_Name = value; }
        public int Lv { get => m_Lv; set => m_Lv = value; }
        public int Power { get => m_Power; set => m_Power = value; }
        public int Agile { get => m_Agile; set => m_Agile = value; }
        public int Wisdom { get => m_Wisdom; set => m_Wisdom = value; }
        public int AbilityAddPoint { get => m_AbilityAddPoint; set => m_AbilityAddPoint = value; }
        public Dictionary<EquipType, DREquip> PlayerEquips { get => m_PlayerEquips; set => m_PlayerEquips = value; }
        public List<int> SkillIdList { get => m_SkillIdList; set => m_SkillIdList = value; }

        ~PlayerData()
        {
            GameEntry.Event.Unsubscribe(PlayerAddAbilityPointDataEventArgs.EventId, OnPointAdd);
        }
    }
}
