using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGGame
{
  
    public class NPCData : ActorData
    {
        [SerializeField]
        private int m_NPCId = 0;                    //NPCId            
        [SerializeField]
        private int m_AIId = 0;                     //AI Id
        [SerializeField]
        private int m_DropId = 0;                   //��ɱ����Id                   
        [SerializeField]
        private int m_ExpReward = 0;                //��ɱ���齱��ֵ

        public NPCData(int entityId, int typeId) : base(entityId, typeId)
        {
        }
    }
}
