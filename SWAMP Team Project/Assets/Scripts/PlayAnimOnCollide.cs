using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnimOnCollide : MonoBehaviour
{
    public bool showBounds;
    public Vector2 pos;
    public Vector2 size;
    PlayerController player;
    bool acceptingTrigger = true;
    public bool playOnce;

    [Header("Events")]
    public bool playAnim;
    public AnimationClip animToPlay;
    Animator anim;

    public bool playSound;
    public AudioClip soundToPlay;
    AudioSource aud;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        if (playAnim)
        {
            anim = GetComponent<Animator>();
        }
        if (playSound)
        {
            aud = GetComponent<AudioSource>();
            aud.clip = soundToPlay;
        }
    }

    void Update()
    {
        if(IsPlayerInBounds() && acceptingTrigger)
        {
            if(playAnim)
            {
                anim.Play(animToPlay.name);

                if(playOnce)
                    acceptingTrigger = false;
            }

            if (playSound)
            {
                aud.Play();
                acceptingTrigger = false;
            }
        }
    }

    bool IsPlayerInBounds()
    {
        if (pos.x + (size.x / 2) > player.transform.position.x &&
                pos.x - (size.x / 2) < player.transform.position.x &&
                pos.y + (size.y / 2) > player.transform.position.y &&
                pos.y - (size.y / 2) < player.transform.position.y)
        {
            return true;
        }

        return false;
    }


    void OnDrawGizmos()
    {
        if (showBounds)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(pos, size);
        }
    }
}
