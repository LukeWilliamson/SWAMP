using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float health = 1;

    void Die ()
    {
        Destroy(this.gameObject);
    }

    public void Damage (float damageValue)
    {
        health -= damageValue;

        if(health <= 0)
        {
            Die();
        }
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
