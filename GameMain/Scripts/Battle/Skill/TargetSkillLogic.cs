using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public abstract class TargetSkillLogic : ISkillLogic
    {
        /// <summary>
        /// ��ʼ��ʱ����Ҫ����һЩ�¼��Ķ���
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public abstract void OnInit(SkillConfig skillConfig, Actor Target);
        /// <summary>
        /// �տ�ʼ�ͷż���ʱ
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public abstract void OnLaunch(SkillConfig skillConfig, Actor Target);
        /// <summary>
        /// �ͷų����ܵ�ʱ��
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public abstract void OnFire(SkillConfig skillConfig, Actor Target);
        /// <summary>
        /// ���ܶ�����ײ��Ŀ�굥λʱ
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public abstract void OnBump(SkillConfig skillConfig, Actor Target);
        /// <summary>
        /// �����ͷŽ���
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public abstract void OnEnd(SkillConfig skillConfig, Actor Target);
        public void Launch(SkillConfig skillConfig, Actor Target, Vector3 poa)
        {
            OnLaunch(skillConfig, Target);
        }

        public void Clear(SkillConfig skillConfig, Actor Target, Vector3 poa)
        {
            throw new System.NotImplementedException();
        }
    }
}
