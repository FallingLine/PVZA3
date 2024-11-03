using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantDetection : MonoBehaviour
{
    public bool haveZombie;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        var tag = collision.collider.tag;
        if (tag == "Zombie")
        {
            haveZombie = true;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        var tag = collision.collider.tag;
        if(tag == "Zombie")
        {
            haveZombie = false;
        }
    }
}
