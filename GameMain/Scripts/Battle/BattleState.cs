using GameFramework;
using GameFramework.Event;
using GameFramework.Fsm;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class BattleState : FsmState<BattleMgr>
    {
        private List<Actor> m_battleActors;
        private Dictionary<int, Actor> camp1Dic;  //����ģʽ��ͨ��ָ�����Ӫ
        private Dictionary<int, Actor> camp2Dic;  //����ģʽ��ͨ��ָnpc������Ӫ

        private int m_CurActorIndex = 0;
        private float startTimer = 0;
        private bool isBattle = true;
        public Actor CurActor
        {
            get
            {
                if (m_CurActorIndex < m_battleActors.Count)
                {
                    return m_battleActors[m_CurActorIndex];
                }

                return null;
            }
        }


        IFsm<BattleMgr> fsm;
        IFsm<BattleState> battleStateFsm;
        public Player player;

        protected override void OnInit(IFsm<BattleMgr> fsm)
        {
            camp1Dic = new Dictionary<int, Actor>();
            camp2Dic = new Dictionary<int, Actor>();
            GameEntry.Event.Subscribe(ActorDeadEventArgs.EventId, OnActorDead);
            GameEntry.Event.Subscribe(ActorEnterBattleEventArgs.EventId, WhenActorEnterBattle);
            this.fsm = fsm;
        }


        private void OnActorDead(object sender, GameEventArgs e)
        {
            ActorDeadEventArgs ae = e as ActorDeadEventArgs;
            if(ae != null&&ae.actor!=null) 
            {
                RemoveActor(ae.actor.ActorData.Id, fsm);
            }
        }

        private void WhenActorEnterBattle(object sender, GameEventArgs e)
        {
            Actor actor = sender as Actor;
            ActorEnterBattleEventArgs ae = e as ActorEnterBattleEventArgs;
            if (actor != null&&ae!=null&&ae.Mgr == fsm.Owner) 
            {
                AddActor(actor);
            }
        }


        protected override void OnEnter(IFsm<BattleMgr> fsm)
        {
            base.OnEnter(fsm);
            startTimer = 0;
            isBattle = false;

            player = fsm.Owner.player;
            m_battleActors = fsm.Owner.battleActors;
            AddActor(player);
            m_CurActorIndex = 0;
            
            battleStateFsm = GameEntry.Fsm.CreateFsm<BattleState>(this, new BattleRoundStartState(), new BattleRoundDoState(), new BattleRoundEndState());  
        }

        protected override void OnUpdate(IFsm<BattleMgr> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);
            if (startTimer <= 0.33f)
            {
                startTimer += elapseSeconds;
            }

            if (!isBattle && startTimer > 0.33f)
            {
                isBattle = true;
                MessageData msgData = new MessageData("ս����ʼ", "");
                GameEntry.UI.OpenUIForm(UIFormId.MessageForm, msgData);
                battleStateFsm.Start<BattleRoundStartState>();
            }
        }

        protected override void OnLeave(IFsm<BattleMgr> fsm, bool isShutdown)
        {
            MessageData msgData = new MessageData("ս������", "");
            GameEntry.UI.OpenUIForm(UIFormId.MessageForm, msgData);
            GameEntry.Fsm.DestroyFsm(battleStateFsm);
            m_battleActors.Clear();
            camp1Dic.Clear();
            camp2Dic.Clear();

            GameEntry.Event.Fire(this, LevelBattleEventArgs.Create(fsm.Owner));
            base.OnLeave(fsm, isShutdown);
        }

        public void AddActor(Actor actor) 
        {
            m_battleActors.Add(actor);
            if(actor.ActorData.Camp == CampType.Player) 
            {
                camp1Dic.Add(actor.ActorData.Id, actor);
            }
            else if(actor.ActorData.Camp == CampType.Enemy)
            {
                camp2Dic.Add(actor.ActorData.Id, actor);
            }

            m_battleActors.Sort();
        }

        public void RemoveActor(int id, IFsm<BattleMgr> fsm)
        {
            for (int i = 0; i < m_battleActors.Count; i++)
            {
                if (m_battleActors[i].ActorData.Id == id)
                {
                    if (m_battleActors[i].ActorData.Camp == CampType.Enemy)
                    {
                        if (camp2Dic.ContainsKey(id))
                        {
                            camp2Dic.Remove(id);

                            if (fsm != null && camp2Dic.Count == 0)
                            {
                                ChangeState<NormalState>(fsm);
                            }
                        }
                    }
                    m_battleActors.RemoveAt(i);
                    if (m_battleActors[i].ActorData.Camp == CampType.Player)
                    {
                        if (camp1Dic.ContainsKey(id))
                        {
                            camp1Dic.Remove(id);

                            if (fsm != null && camp1Dic.Count == 0)
                            {
                                ChangeState<NormalState>(fsm);
                            }
                        }
                    }
                    break;
                }
            }
        }

        public void ShiftToNextActor()
        {
            Debug.LogWarning("Shift To Next!");
            if (m_CurActorIndex == m_battleActors.Count - 1)
            {
                m_CurActorIndex = 0;
            }
            else
            {
                m_CurActorIndex++;
            }
        }
    }

    public class LevelBattleEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(LevelBattleEventArgs).GetHashCode();
        public override int Id => EventId;

        public BattleMgr mgr;

        public static LevelBattleEventArgs Create(BattleMgr battleMgr) 
        {
            LevelBattleEventArgs e = ReferencePool.Acquire<LevelBattleEventArgs>();
            e.mgr = battleMgr;
            return e;
        }
        public override void Clear()
        {
            mgr = null;
        }
    }

    /// <summary>
    /// �غϿ�ʼ
    /// </summary>
    public class BattleRoundStartState : FsmState<BattleState>
    {
        float timer = 0;
        protected override void OnInit(IFsm<BattleState> fsm)
        {
            base.OnInit(fsm);
            //GameEntry.Event.Fire(this, ActorRoundStartEventArgs.Create(fsm.Owner.CurActor.ActorData.Id));
        }
        protected override void OnEnter(IFsm<BattleState> fsm)
        {
            base.OnEnter(fsm);
            GameEntry.Event.Fire(this, ActorRoundStartEventArgs.Create(fsm.Owner.CurActor));
            timer = 0;
            MessageData msgData = new MessageData("ս���غϿ�ʼ", $"{fsm.Owner.CurActor.gameObject.name}�Ļغ�");
            GameEntry.UI.OpenUIForm(UIFormId.MessageForm, msgData);
            //�ǽ�ɫ�غ���Ҳ�����·
            if (fsm.Owner.CurActor.tag != "Player")
            {
                fsm.Owner.player.canMove = false;
                fsm.Owner.player.inPlayerTurn = false;
            }
            else
            {
                fsm.Owner.player.canMove = true;
                fsm.Owner.player.inPlayerTurn = true;
            }

#if UNITY_EDITOR
            if (fsm.Owner.CurActor != null)
            {
                fsm.Owner.CurActor.RestoreSP();
                Log.Info(fsm.Owner.CurActor + "���Ļغ�");
            }
#endif
        }
        protected override void OnUpdate(IFsm<BattleState> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            //Log.Debug("�غϿ�ʼ");
            //when round start animation play over then change state
            timer += elapseSeconds;
            if (timer > 2f)
            {
                ChangeState<BattleRoundDoState>(fsm);
            }

        }

        protected override void OnLeave(IFsm<BattleState> fsm, bool isShutdown)
        {
            base.OnLeave(fsm, isShutdown);
        }
    }


    /// <summary>
    /// �غϽ���
    /// </summary>
    public class BattleRoundDoState : FsmState<BattleState>
    {
        IFsm<BattleState> fsm;
        float timer = 0;
        protected override void OnInit(IFsm<BattleState> fsm)
        {
            base.OnInit(fsm);
            GameEntry.Event.Subscribe(ActorRoundFinishEventArgs.EventId, OnActorRoundFinish);
            this.fsm = fsm;
        }

        protected override void OnEnter(IFsm<BattleState> fsm)
        {
            base.OnEnter(fsm);
            timer = 0;
            fsm.Owner.CurActor.inTurn = true;
#if UNITY_EDITOR
            Log.Info($"Actor {fsm.Owner.CurActor.ActorData.Id} Round Do!");
#endif
        }

        protected override void OnUpdate(IFsm<BattleState> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            //Enemyִ��AI�߼���ִ�н��������غϽ���״̬
            if(fsm.Owner.CurActor == null) { return; }

            if (fsm.Owner.CurActor.tag == "Enemy")
            {
                timer += realElapseSeconds;

                if (timer > 60)
                {
                    ChangeState<BattleRoundEndState>(fsm);
                }
            }

        }

        private void OnActorRoundFinish(object sender, GameEventArgs e)
        {
            if (fsm != null)
            {
                ChangeState<BattleRoundEndState>(fsm);
            }
        }
    }


    /// <summary>
    /// �غϽ���
    /// </summary>
    public class BattleRoundEndState : FsmState<BattleState>
    {
        float timer = 0;
        protected override void OnEnter(IFsm<BattleState> fsm)
        {
            base.OnEnter(fsm);
            timer = 0;
            fsm.Owner.CurActor.inTurn = false;
            MessageData msgData = new MessageData("�غϽ���", "");
            GameEntry.UI.OpenUIForm(UIFormId.MessageForm, msgData);
        }

        protected override void OnUpdate(IFsm<BattleState> fsm, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(fsm, elapseSeconds, realElapseSeconds);

            timer += elapseSeconds;
            //�ȴ��غϽ�����������
            if (timer > 2f)
            {
                ChangeState<BattleRoundStartState>(fsm);
            }
        }

        protected override void OnLeave(IFsm<BattleState> fsm, bool isShutdown)
        {
            Debug.LogWarning("OnLeave");
            //�л�����һ��Actor
            fsm.Owner.ShiftToNextActor();
            base.OnLeave(fsm, isShutdown);
        }
    }
}
