using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPGGame
{
    public abstract class Skill : ISkillLogic
    {
        public SkillConfig Config { get; set; }
        public Actor Target { get; set; }
        public Vector3 TargetPosition { get; set; }
        public Vector3 ForwardDir { get; set; }

        /// <summary>
        /// ��ʼ��ʱ����Ҫ����һЩ�¼��Ķ���
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnInit() { }
        /// <summary>
        /// �տ�ʼ�ͷż���ʱ
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnLaunch() 
        {
            Config.EnterCoolDown();
        }
        /// <summary>
        /// �ͷų����ܵ�ʱ��
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnFire(object sender, GameEventArgs e) { }
        /// <summary>
        /// ���ܶ�����ײ��Ŀ�굥λʱ
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnBump() { }
        /// <summary>
        /// �����ͷŽ���
        /// </summary>
        /// <param name="skillConfig"></param>
        /// <param name="Target"></param>
        public virtual void OnEnd() {}

        public void Clear()
        {
            throw new System.NotImplementedException();
        }
        
        public void Init(DRSkillConfig drSkillConfig, Actor Launcher)
        {
            Config = new SkillConfig(drSkillConfig, Launcher); 
            OnInit();
        }

        public void Launch(Actor Target, Vector3 Position, Vector3 ForwardDir)
        {
            this.Target = Target;
            this.TargetPosition = Position;
            this.ForwardDir = ForwardDir;
            OnLaunch();
        }
    }
}
