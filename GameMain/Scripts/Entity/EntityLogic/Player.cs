using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityGameFramework.Runtime;

namespace RPGGame
{
    public class Player : Actor
    {
        [SerializeField]
        private PlayerData m_PlayerData = null;
        private NavMeshAgent nav;

        private List<Skill> SkillList;
        private Skill SelectedSkill;

        public bool inPlayerTurn;
        float pedometer = 0;

        protected override void OnInit(object userData)
        {
            base.OnInit(userData);
            SkillList = new List<Skill>(8) { null, null, null, null, null, null, null, null };
        }
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            EventComponent eventComponent = GameEntry.Event;

            eventComponent.Fire(this, PlayerShowEventArgs.Create());
            eventComponent.Fire(this, UpdateSkillInfoEventArges.Create(SkillList));

            //��ȡ��ɫ��������id
            //ͨ��idƴ��
            canMove = true;

            m_PlayerData = userData as PlayerData;
            if (m_PlayerData == null)
            {
                Log.Error("Player data is invalid.");
                return;
            }

            nav = GetComponent<NavMeshAgent>();

            Name = Utility.Text.Format("Player ({0})", Id);
            //GameEntry.HPBar.ShowHPBar(this, (m_PlayerData as ActorData).HPRatio, (m_PlayerData as ActorData).HPRatio);
        }

        [System.Obsolete]
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            if (Input.GetMouseButtonDown(1) && canMove && m_PlayerData.SP > 0)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    nav.SetDestination(hit.point);
                }
            }

            if (inPlayerTurn)
            {
                //�ƶ�SP����
                pedometer += Time.deltaTime * nav.velocity.magnitude;
                if (pedometer > 2f)
                {
                    pedometer = 0;
                    base.ConsumeSP(1);
                }
            }

           
            if (Input.GetMouseButtonDown(0))
            {
                if (SelectedSkill != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 1000, 1 << LayerMask.NameToLayer("Actor")))
                    {
                        Actor Target = hit.collider.gameObject.GetComponent<Actor>();
                        Vector3 Position = hit.point;
                        Position.y = this.transform.position.y;
                        Vector3 ForwordDir = (Position - this.transform.position).normalized;

                        SelectedSkill.Launch(Target, Position, ForwordDir);
                    }
                }
            }

            ///Test
            if (Input.GetKeyDown(KeyCode.F))
            {
                DoAnimation("ReleaseSkill", 0.14f);
            }
        }
    }

    public class PlayerShowEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(PlayerShowEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public static PlayerShowEventArgs Create()
        {
            PlayerShowEventArgs e = ReferencePool.Acquire<PlayerShowEventArgs>();
            return e;
        }
        public override void Clear()
        {

        }
    }

}
