using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace PVZA3
{
    public enum Faction
    {
        Own,
        Enemy,
    }
    public enum Scene
    {
        YourHouseDay,
        YourHouseNight,
        CampGroundDay,
        CampGroundNight,
    }
    public enum GameMod
    {
        None,
        ImZombie,
        ZomBotany,
        Endless,
    }
    public class PVZObject : MonoBehaviour
    {
        public Faction faction;
        [NonSerialized] public float hP;
        [NonSerialized] public bool isHypnotic;
    }
    public class Plant : PVZObject
    {
        public string pvzName;
        public int cost;
        public float CD;
        public bool canSpeedUp = true;
        public GameObject UIpreview;
        public Sprite cardPreview;

        [NonSerialized] public bool isChoosed = false;
        public class SceneInfo
        {
            public bool isPlant = false;
            public bool isTaco = false;
        }
    }
    public class armor : PVZObject
    {
        public float dR;
        public bool canPenetrate = false;//是否能被贯穿（默认否）
    }
    public class Zombie : PVZObject
    {
        public float fullHP;
        public string pvzName;
        public float ATK;
        public float moveSpeed = 1f;
        public float attackSpeed = 1f;
        public List<armor> armors = new List<armor>();
        public float CSC;//综合强度系数
        public GameObject UIpreview;
        public Animator zomAnim;
        public AnimationClip zomWalk;

        public GameObject fullBloodSign;
        public GameObject halfBloodSign;

        [NonSerialized] public float n = 0;
        [NonSerialized] public float m = 0;

        [NonSerialized] public Plant plant;
        [NonSerialized] public Vector3 direction = new Vector3(1, 0, 0);

        [Serializable]
        public class m_SceneID
        {
            public int line;
        }

        public void Awake()
        {
            fullBloodSign.SetActive(true);
            halfBloodSign.SetActive(false);
            hP = fullHP;
            zomAnim.speed = moveSpeed;
        }
        void Update()
        {
            transform.position -= direction * n * Time.deltaTime;
            if (hP <= fullHP / 2)
            {
                HalfBloodAction();
            }
        }
        
        void OnCollisionEnter2D(Collision2D collision)
        {
            var tag = collision.collider.tag;
            if (tag == "Bullet")
            {
                Bullet bullet = collision.gameObject.GetComponent<Bullet>();
                if (bullet.faction != faction)
                {
                    hP -= bullet.damage;
                }
            }
        }
        void OnCollisionStay2D(Collision2D collision)
        {
            var tag = collision.collider.tag;
            if (tag == "Plant")
            {
                plant = collision.gameObject.GetComponent<Plant>();
            }
        }

        public void WalkSpeedChange(float speed)
        {
            zomAnim.speed = moveSpeed;
            n = speed * moveSpeed;
        }
        public void StopMove()
        {
            n = 0;
            zomAnim.speed = attackSpeed;
        }
        public void Attack()
        {
            plant.hP -= ATK;
        }
        public void HalfBloodAction()
        {
            fullBloodSign.SetActive(false);
            halfBloodSign.SetActive(true);
        }
    }
    public class IAZ : Zombie
    {
        public int cost;
        public float CD;
    }
    public class Bullet : MonoBehaviour
    {
        public Faction faction;
        public float damage;
        public float speed;
    }
    public class SunFlower : MonoBehaviour
    {
        public float spawnSpeed;
        public int onceGet;
    }

    namespace P_FSM
    {
        public enum StateType
        {
            Idle,
            Attack,
            PF,
            Taco,
            TacoATK,
            TacoPF,
        }
        public interface IState
        {
            void OnEnter();
            void OnExit();
            void OnUpdate();
            //void OnCleck();
            //void OnFixUpdate();
        }
        [Serializable]
        public class Blackboard
        {
            //此处存储共享数据，或者向外展示的数据，可配置数据
        }
        public class PlantFSM
        {
            public IState curState;
            public Dictionary<StateType, IState> states;
            public Blackboard blackboard;

            public PlantFSM(Blackboard blackboard)
            {
                this.states = new Dictionary<StateType, IState>();
                this.blackboard = blackboard;
            }

            public void AddState(StateType stateType, IState state)
            {
                if (states.ContainsKey(stateType))
                {
                    Debug.Log("[AddState] >>>>>>>>>>> Plant has contain key : " + stateType);
                    return;
                }
                states.Add(stateType, state);
            }

            public void SwitchState(StateType stateType)
            {
                if (!states.ContainsKey(stateType))
                {
                    Debug.Log("[AddState] >>>>>>>>>>> Not contain key : " + stateType);
                    return;
                }
                if (curState != null)
                {
                    curState.OnExit();
                }
                curState = states[stateType];
                curState.OnEnter();
            }
            public void OnUpdate()
            {
                //curState.OnFixUpdate():
            }
            public void OnCheck()
            {
                //curState.OnCleck();
            }
            public void OnFixUpdate()
            {
                //curState.OnFixUpdate();
            }
        }
    }

    namespace UI
    {
        public class SceneLoader : MonoBehaviour
        {
            public Animator transtion;
            public float waitForSeconds = 1f;
            public void LoadScene(int sceneID,GameObject text)
            {
                StartCoroutine(LoadNextScene(sceneID, text));
            }

            IEnumerator LoadNextScene(int sceneID_2,GameObject text_2)
            {
                //Play animation
                transtion.SetTrigger("Start");

                //Wait
                yield return new WaitForSeconds(waitForSeconds);

                //Load Scene
                text_2.SetActive(false);
                SceneManager.LoadScene(sceneID_2);
            }
        }
    }
}