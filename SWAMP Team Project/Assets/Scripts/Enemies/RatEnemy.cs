using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatEnemy : MonoBehaviour
{
    public float moveSpeed;
    public float waitTime;
    PlayerController player;
    Rigidbody2D rigBod;
    SpriteRenderer sprit;
    Animator anim;

    void Start()
    {
        rigBod = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
        sprit = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponentInChildren<Animator>();

        StartCoroutine(movingRat());
    }

    void Move ()
    {
        if (player.transform.position.x > transform.position.x)
        {
            rigBod.velocity = new Vector3(moveSpeed, 0, 0);
            sprit.flipX = false;
        }
        else
        {
            rigBod.velocity = new Vector3(-moveSpeed, 0, 0);
            sprit.flipX = true;
        }

        anim.SetTrigger("MoveTrigger");
    }

    IEnumerator movingRat()
    {
        Move();

        yield return new WaitForSeconds(waitTime);

        Move();

        yield return new WaitForSeconds(waitTime);

        Move();

        yield return new WaitForSeconds(waitTime);

        rigBod.velocity = Vector3.zero;
        anim.SetTrigger("StopTrigger");

        yield return new WaitForSeconds(waitTime);

        StartCoroutine(movingRat());
    }
}
