using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 7;
    public float swimSpeed = 7;
    public float jumpForce = 10;
	public float jumpTime = 0.3f;
	public LayerMask groundLayer;

    [HideInInspector]
	public bool grounded;
	bool hitHead;
	bool hitWallRight;
	bool hitWallLeft;
	bool spiderForm;

	[HideInInspector]
	public bool inWater;
	[HideInInspector]
	public bool scalingBackground;

	Rigidbody2D rigBod;
    BoxCollider2D playerCol;
	Animator anim;

    float JumpTimeCounter;
    bool isJumping;
    int jumps;
    float waitToJump;

    void Start()
    {
		rigBod = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
		if(inWater)
		{
			Swim(5);
		}
		else if(scalingBackground && Input.GetKey(KeyCode.LeftControl))
		{
			Swim(0);
		}
		else
		{
			Walk();
		}

		ClampFallSpeed();
    }

	void Walk()
	{
		rigBod.gravityScale = 5;
		rigBod.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigBod.velocity.y);
	}

	void Swim (float gravityModifier)
	{
		rigBod.gravityScale = gravityModifier;
		rigBod.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * swimSpeed;
	}

	void ClampFallSpeed ()
	{
		if(rigBod.velocity.y < -15)
		{
			rigBod.velocity = new Vector2(rigBod.velocity.x, -15);
		}
	}

    void Update()
    {
		CheckCollision();

		if(inWater)
		{
			
		}
		else if(scalingBackground && Input.GetKey(KeyCode.LeftControl))
		{
			
		}
		else
		{
			if(grounded && Input.GetKey(KeyCode.LeftShift))
			{
				spiderForm = true;
			}
			else
			{
				spiderForm = false;
			}

			Jump();
		}

		AnimatePlayer();
    }



	void CheckCollision ()
	{
		if (waitToJump >= 0)
		{
			waitToJump -= Time.deltaTime;
		}
		if(waitToJump <= 0)
		{ 
			grounded = Physics2D.OverlapCircle(new Vector2(playerCol.bounds.center.x, playerCol.bounds.min.y), 0.05f, groundLayer);
			hitHead = Physics2D.OverlapCircle(new Vector2(playerCol.bounds.center.x, playerCol.bounds.max.y), 0.05f, groundLayer);
			hitWallLeft = Physics2D.OverlapCircle(new Vector2(playerCol.bounds.min.x, playerCol.bounds.center.y), 0.05f, groundLayer);
			hitWallRight = Physics2D.OverlapCircle(new Vector2(playerCol.bounds.max.x, playerCol.bounds.center.y), 0.05f, groundLayer);
		}

		if(hitHead)
		{
			isJumping = false;
		}
	}

	void Jump ()
	{
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

	void AnimatePlayer()
	{
		anim.SetFloat("Move", Input.GetAxisRaw("Horizontal"));
		anim.SetBool("Grounded", grounded);
		anim.SetBool("Spider", spiderForm);
		anim.SetFloat("Look", Input.GetAxisRaw("Vertical"));
	}

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        BoxCollider2D pCol = UnityEditor.Selection.activeGameObject.GetComponent<BoxCollider2D>();
		Gizmos.DrawWireSphere(new Vector2(pCol.bounds.center.x, pCol.bounds.min.y), 0.05f);
		Gizmos.DrawWireSphere(new Vector2(pCol.bounds.center.x, pCol.bounds.max.y), 0.05f);
		Gizmos.DrawWireSphere(new Vector2(pCol.bounds.min.x, pCol.bounds.center.y), 0.05f);
		Gizmos.DrawWireSphere(new Vector2(pCol.bounds.max.x, pCol.bounds.center.y), 0.05f);
    }
#endif
}