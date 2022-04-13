using GameFramework.DataTable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame {

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
        private string m_Lv;        //�ȼ� = ֱ������MaxHP, ����Atk
        [SerializeField]
        private int m_Power;        //���� = ����MaxHP, ���ӻ���, ��������������
        [SerializeField]    
        private int m_Agile;        //���� = �����ȹ�,  ����MaxSP, ��������������
        [SerializeField]    
        private int m_Wisdom;       //���� = ���ӷ�ǿ�� ����ħ��,  ����ħ��������
        //[SerializeField]
        //private int m_Faith;      
        [SerializeField]
        private Dictionary<EquipType, Equip> PlayerEquips;       //��ɫ��װ��

        public PlayerData(DRPlayer dRPlayer, int entityId, int typeId) :base(entityId, typeId)
        {

        }
    }
}
