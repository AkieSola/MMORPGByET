using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    /// <summary>
    /// С����
    /// ��Ŀ�굥λ����˺���֮���ʩ��һ��ȼ�յ�buff��ÿ�غ�����˺�
    /// </summary>
    public class Skill001 : Skill
    {
        public override void OnInit()
        {
            GameEntry.Event.Subscribe(SkillFireEventArgs.EventId, OnFire);
        }

        private void OnFire(object sender, GameEventArgs e)
        {
            //���ɶ���
            string path = GameEntry.Resource.ReadWritePath;
            ;
        }

        public override void OnBump()
        {
            throw new System.NotImplementedException();
        }

        public override void OnEnd()
        {
            throw new System.NotImplementedException();
        }

        public override void OnFire()
        {
            throw new System.NotImplementedException();
        }



        public override void OnLaunch()
        {
            Config.Launcher.DoSkill(Config);
        }
    }
}
