using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using UnityEngine.Pool;
using PVZA3.FSM;

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
        public float fullHP;
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
            public Vector2 coordinate;
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
        public float aTK;
        public List<armor> armors = new List<armor>();
        public float CSC;//综合强度系数
        public GameObject UIpreview;

        public List<SpriteRenderer> renderers = new List<SpriteRenderer>();
        

        public bool haveHalfAction = true;
        public GameObject fullBloodSign;
        public GameObject halfBloodSign;
        public bool haveHalfAction_AT = false;
        public GameObject halfBloodSign_AT;

        [NonSerialized] public Plant plant;
        public float brightness;

        [Serializable]
        public class m_SceneID
        {
            public int line;
        }
        public void Awake()
        {
            if (haveHalfAction == true)
            {
                fullBloodSign.SetActive(true);
                halfBloodSign.SetActive(false);
                if (haveHalfAction_AT == true)
                {
                    halfBloodSign_AT.SetActive(false);
                }
            }
            hP = fullHP;
        }

        public void HalfBloodAction()
        {
            if (haveHalfAction == true)
            {
                fullBloodSign.SetActive(false);
                halfBloodSign.SetActive(true);
                if (haveHalfAction_AT == true)
                {
                    halfBloodSign_AT.SetActive(false);
                }
            }
        }

        public void HalfBloodAction_AT()
        {
            if (haveHalfAction == true)
            {
                fullBloodSign.SetActive(false);
                halfBloodSign.SetActive(false);
                if (haveHalfAction_AT == true)
                {
                    halfBloodSign_AT.SetActive(true);
                }
            }
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

        public ObjectPool<GameObject> pool;
    }
    public class SunFlower : MonoBehaviour
    {
        public float spawnSpeed;
        public int onceGet;
    }

    namespace FSM
    {
        public enum StateType
        {
            a,
            b,
            c,
            d,
            e,
            f,
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
        public class FSM
        {
            public IState curState;
            public Dictionary<StateType, IState> states;
            public Blackboard blackboard;

            public FSM(Blackboard blackboard)
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
                curState.OnUpdate();
            }
            public void OnCheck()
            {
                //curState.OnCheck();
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