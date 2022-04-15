using GameFramework.DataTable;
using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{

    /// <summary>
    /// 包括角色加的点
    /// </summary>
    public class PlayerData : ActorData
    {
        [SerializeField]
        private int m_Id;
        [SerializeField]
        private string m_Name;
        [SerializeField]
        private int m_Lv;        //等级 = 直接增加MaxHP, 增加Atk
        [SerializeField]
        private int m_Power;        //力量 = 增加MaxHP, 增加护甲, 补正力量型武器
        [SerializeField]
        private int m_Agile;        //敏捷 = 增加先攻,  增加MaxSP, 补正敏捷型武器
        [SerializeField]
        private int m_Wisdom;       //智力 = 增加法强， 增加魔抗,  补正魔法型武器
        //[SerializeField]
        //private int m_Faith;      
        [SerializeField]
        private int m_AbilityAddPoint;
        [SerializeField]
        private Dictionary<EquipType, DREquip> m_PlayerEquips;       //角色的装备


        private int baseMaxHP = 100;
        private int baseMaxSP = 10;
        private int baseATK = 10;
        private float m_LvPowAddHP = 1.2f;

        PlayerDataSource playerDataSource;
        public PlayerData(PlayerDataSource pdSource, int entityId, int typeId) : base(entityId, typeId)
        {
            playerDataSource = pdSource;

            Id1 = pdSource.Id;
            Name = pdSource.Name;
            Lv = pdSource.Lv;
            Power = pdSource.Power;
            Agile = pdSource.Agile;
            Wisdom = pdSource.Wisdom;

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
            base.MaxHP = (int)(baseMaxHP * Mathf.Pow(m_LvPowAddHP, LvPowAddHP) + Power * 20); //+装备加成
            base.HP = MaxHP;
            base.SP = MaxSP;
            base.Priority = 5;
            base.MaxSP = baseMaxHP;
            base.Atk = baseATK;
            base.SpellAtk = 0;
            base.AtkDistance = 10.0f;
            base.PhysicsDfs = 0;
            base.SpellDfs = 0;

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
            base.MaxHP = (int)(baseMaxHP * Mathf.Pow(m_LvPowAddHP, LvPowAddHP) + Power * 20); //+装备加成
            base.HP = MaxHP;
            base.SP = MaxSP;
            base.Priority = 5;
            base.MaxSP = baseMaxHP;
            base.Atk = baseATK;
            base.SpellAtk = 0;
            base.AtkDistance = 10.0f;
            base.PhysicsDfs = 0;
            base.SpellDfs = 0;

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

        ~PlayerData()
        {
            GameEntry.Event.Unsubscribe(PlayerAddAbilityPointDataEventArgs.EventId, OnPointAdd);
        }
    }
}
