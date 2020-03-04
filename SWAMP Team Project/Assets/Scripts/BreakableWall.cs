using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    EnemyManager health;
    public GameObject breakParticles;
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
        if(health.health == 0)
        {
            GameObject part = Instantiate(breakParticles);

            part.transform.position = this.transform.position;
            BreakableWallManager.wallsAreBroken[wallID] = true;
            Destroy(this.gameObject);
        }
    }
}
