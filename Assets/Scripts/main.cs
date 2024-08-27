using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

namespace PVZA3
{
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
    public class Plant : MonoBehaviour
    {
        public string name;
        public int cost;
        public float HP;
        public float CD;
        public bool isTaco;
        public bool canSpeedUp = true;
        public GameObject UIpreview;
        public Sprite cardPreview;

        [NonSerialized] public bool isChoosed = false;
        public class SceneInfo
        {
            public bool isPlant = false;
        }
    }
    public class Zombie : MonoBehaviour
    {
        public string name;
        public float HP;
        public float ATK;
        public float moveSpeed;
        public float attackSpeed;
        public bool armorBool;
        public float armorHP;
        public float armorDR;
        public bool armorCanPenetrate;
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
            AnimatorController controller = zomAnim.runtimeAnimatorController as AnimatorController;
            AnimatorStateMachine stateMachine = controller.layers[0].stateMachine;
            ChildAnimatorState[] states = stateMachine.states;
            float magnification = states[0].state.speed;
            n = speed * magnification;
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