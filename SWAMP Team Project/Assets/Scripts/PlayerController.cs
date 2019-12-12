using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    Rigidbody2D rigBod;
    [HideInInspector]
    public bool grounded;
    BoxCollider2D playerCol;
    public LayerMask groundLayer;

    float JumpTimeCounter;
    public float jumpTime;
    bool isJumping;
    int jumps;
    float waitToJump;

    bool hitHead;

    void Start()
    {
        playerCol = GetComponent<BoxCollider2D>();
        rigBod = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rigBod.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigBod.velocity.y);
    }

    void Update()
    {
        if (waitToJump >= 0)
        {
            waitToJump -= Time.deltaTime;
        }
        if(waitToJump <= 0)
        { 
            grounded = Physics2D.OverlapCircle(new Vector2(playerCol.bounds.center.x, playerCol.bounds.min.y), 0.05f, groundLayer);
        }

        hitHead = Physics2D.OverlapCircle(new Vector2(playerCol.bounds.center.x, playerCol.bounds.max.y), 0.05f, groundLayer);

        if(hitHead)
        {
            isJumping = false;
        }

        if (jumps == 2)
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 0, 1);
        }
        else if (jumps == 1)
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(1, 0, 0);
        }
        else
        {
            GetComponentInChildren<SpriteRenderer>().color = new Color(0, 1, 1);
        }

        if (grounded)
        {
            if (Stats.canDoubleJump)
            {
                jumps = 2;
            }
            else
            {
                jumps = 1;
            }
        }

        if (jumps != 0 && Input.GetButtonDown("Jump"))
        {
            jumps -= 1;
            isJumping = true;
            grounded = false;
            waitToJump = 0.25f;
            JumpTimeCounter = jumpTime;
            rigBod.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (JumpTimeCounter > 0)
            {
                rigBod.velocity = Vector2.up * jumpForce;
                JumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        BoxCollider2D pCol = UnityEditor.Selection.activeGameObject.GetComponent<BoxCollider2D>();
        Gizmos.DrawWireSphere(new Vector2(pCol.bounds.center.x, pCol.bounds.min.y), 0.05f);
    }
#endif
}