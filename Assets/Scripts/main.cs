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
        public float hP;
        public Faction faction;
        public bool isHypnotic;
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
        public string pvzName;
        public float ATK;
        public float moveSpeed = 1;
        public float attackSpeed = 1;
        public List<armor> armors = new List<armor>();
        public float CSC;//综合强度系数
        public GameObject UIpreview;
        public Animator zomAnim;
        public AnimationClip zomWalk;
        [NonSerialized] public float n = 0;

        [NonSerialized] public Vector3 direction = new Vector3(1, 0, 0);


        public class m_SceneID
        {
            public int line;
        }

        public void WalkSpeedChange(float speed) 
        {
            Animation anim = GetComponent<Animation>();
            foreach (AnimationState state in anim)
            {
                state.speed = 0.5F;
            }
            AnimatorController controller = zomAnim.runtimeAnimatorController as AnimatorController;
            AnimatorStateMachine stateMachine = controller.layers[0].stateMachine;
            ChildAnimatorState[] states = stateMachine.states;
            float magnification = states[0].state.speed;
            n = speed * magnification;
        }
        void Update()
        {
            transform.position -= direction * n * Time.deltaTime;
        }
    }
    public class IAZ : Zombie
    {
        public int cost;
        public float CD;
    }
    public class Bullet : MonoBehaviour
    {
        public float damage;
        public float speed;
    }
    public class PlantBullet : Bullet
    {
        
    }
    public class Zombiebullet : Bullet
    {

    }
    public class SunFlower : MonoBehaviour
    {
        public float spawnSpeed;
        public int onceGet;
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