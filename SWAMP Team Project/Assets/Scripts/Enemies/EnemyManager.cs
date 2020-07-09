using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float health = 1;
    Animator anim;
    public AnimationClip entranceAnimation;
    public AnimationClip beginAnimation;
    public AudioClip bossMusic;
    public bool requiresTrigger = false;
    public int damageValue = 1;
    Vector3 startPos;

    private void Start()
    {
        anim = GetComponent<Animator>();

        if(requiresTrigger)
        {
            startPos = transform.position;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    private void LateUpdate()
    {
        if(requiresTrigger)
        {
            transform.position = startPos;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;            
        }
    }

    public void Die ()
    {
        if (!GetComponent<BreakableWall>())
        {
            Destroy(this.gameObject);
        }
    }

    public void Damage (float damageVal)
    {
        health -= damageVal;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Enter()
    {
        StartCoroutine(EnterCoroutine());
    }

    IEnumerator EnterCoroutine()
    {
        GetComponentInChildren<SpriteRenderer>().enabled = true;

        if(entranceAnimation != null)
        {
            Stats.canMove = false;
            anim.SetTrigger("Enter");
            yield return new WaitForSeconds(entranceAnimation.length);
            Stats.canMove = true;
        }

        GetComponent<BoxCollider2D>().enabled = true;

        if (beginAnimation != null)
        {
            anim.SetTrigger("Begin");
            yield return new WaitForSeconds(beginAnimation.length / 2);
            if (bossMusic != null)
            {
                FindObjectOfType<AudioManager>().source.clip = bossMusic;
                FindObjectOfType<AudioManager>().source.Play();
            }
            yield return new WaitForSeconds(beginAnimation.length / 2);
        }

        requiresTrigger = false;
    }
}
