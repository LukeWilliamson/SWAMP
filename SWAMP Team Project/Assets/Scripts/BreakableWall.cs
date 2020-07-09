using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    EnemyManager health;
    public GameObject breakParticles;
    public Animator anim;
    public string trigger;
    public int wallID;
    // Start is called before the first frame update
    void Start()
    {
        if(BreakableWallManager.wallsAreBroken[wallID] == true)
        {
            Destroy(this.gameObject);
        }

        health = GetComponent<EnemyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health.health <= 0)
        {
            if (breakParticles != null)
            {
                GameObject particle = Instantiate(breakParticles);
                particle.transform.position = this.transform.position;
            }

            if(anim != null)
            {
                anim.SetTrigger(trigger);
            }

            BreakableWallManager.wallsAreBroken[wallID] = true;
            Destroy(this.gameObject);
        }
    }
}
