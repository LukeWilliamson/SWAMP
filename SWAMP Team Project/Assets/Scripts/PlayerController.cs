using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float moveSpeed = 7;
	public float swimSpeed = 7;
    public float jumpForce = 10;
	public float jumpTime = 0.3f;
	public float wallJumpTime = 0.3f;
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

	float jumpTimeCounter;
    float wallJumpTimeCounter;
    bool isJumping;
	bool wallJumping;
	bool leftWall;
	bool rightWall;
    int jumps;
    float waitToJump;
	float groundDist = 0.05f;

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
			Swim(20);
		}
		else if(scalingBackground && Input.GetKey(KeyCode.LeftControl) && Stats.canScaleBackground)
		{
			Swim(0);
		}
		else
		{
			Walk();
		}

		ClampFallSpeed(-15);

		if(!grounded)
		{
			WallJump();
		}
    }

	void Walk()
	{
		rigBod.gravityScale = 5;
		rigBod.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigBod.velocity.y);
	}

	void Swim (float gravityModifier)
	{
		rigBod.gravityScale = gravityModifier;

		if(Stats.canFreeSwim)
		{
			rigBod.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * swimSpeed;
		}
		else
		{
			rigBod.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, rigBod.velocity.y);
		}
	}

	void ClampFallSpeed (float speed)
	{
		if(rigBod.velocity.y < speed)
		{
			rigBod.velocity = new Vector2(rigBod.velocity.x, speed);
		}
	}

    void Update()
    {
		CheckCollision();

		if(inWater && Stats.canFreeSwim)
		{
			
		}
		else if(scalingBackground && Input.GetKey(KeyCode.LeftControl) && Stats.canScaleBackground)
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

			if(!wallJumping)
			{
				Jump();
			}

			WallJump();
		}

		AnimatePlayer();
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
			jumpTimeCounter = jumpTime;
			rigBod.velocity = Vector2.up * jumpForce;
		}

		if (Input.GetButton("Jump") && isJumping && !wallJumping)
		{
			if (jumpTimeCounter > 0)
			{
				rigBod.velocity = Vector2.up * jumpForce;
				jumpTimeCounter -= Time.deltaTime;
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

	void WallJump()
	{
		if(Input.GetAxisRaw("Horizontal") != 0)
		{
			if(hitWallRight || hitWallLeft)
			{
				ClampFallSpeed(-5);

				if(Input.GetKey(KeyCode.RightControl))
				{
					rigBod.gravityScale = 0;
					rigBod.velocity = Vector2.zero;
				}
				else
				{
					rigBod.gravityScale = 5;
				}
			}

			if(hitWallRight && Input.GetButtonDown("Jump"))
			{
				rightWall = true;
				wallJumping = true;
				wallJumpTimeCounter = wallJumpTime;
				rigBod.velocity = new Vector2(-jumpForce, jumpForce);
			}

			if(hitWallLeft && Input.GetButtonDown("Jump"))
			{
				leftWall = true;
				wallJumping = true;
				wallJumpTimeCounter = wallJumpTime;
				rigBod.velocity = new Vector2(jumpForce, jumpForce);
			}
		}

		if (wallJumping)
		{
			if (wallJumpTimeCounter > 0)
			{
				if(leftWall)
				{
					rigBod.velocity = new Vector2(jumpForce, jumpForce);
				}
				else if(rightWall)
				{
					rigBod.velocity = new Vector2(-jumpForce, jumpForce);
				}
				wallJumpTimeCounter -= Time.deltaTime;
			}
			else
			{
				wallJumping = false;
				leftWall = false;
				rightWall = false;
			}
		}
	}

	void CheckCollision ()
	{
		if (waitToJump >= 0)
		{
			waitToJump -= Time.deltaTime;
		}
		if(waitToJump <= 0)
		{
			grounded = Physics2D.OverlapBox(new Vector2(playerCol.bounds.center.x, playerCol.bounds.min.y), new Vector3((playerCol.bounds.max.x - playerCol.bounds.min.x) - groundDist, groundDist, 0), 0, groundLayer);

			hitHead = Physics2D.OverlapBox(new Vector2(playerCol.bounds.center.x, playerCol.bounds.max.y), new Vector3((playerCol.bounds.max.x - playerCol.bounds.min.x) - groundDist, groundDist, 0), 0, groundLayer);

			hitWallLeft = Physics2D.OverlapCircle(new Vector2(playerCol.bounds.min.x, playerCol.bounds.center.y), 0.05f, groundLayer);
			hitWallRight = Physics2D.OverlapCircle(new Vector2(playerCol.bounds.max.x, playerCol.bounds.center.y), 0.05f, groundLayer);
		}

		if(hitHead)
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
		BoxCollider2D pCol = UnityEditor.Selection.activeGameObject.GetComponent<BoxCollider2D>();
	
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(new Vector2(pCol.bounds.center.x, pCol.bounds.min.y), new Vector3((pCol.bounds.max.x - pCol.bounds.min.x) - groundDist, groundDist, 0));

		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(new Vector2(pCol.bounds.center.x, pCol.bounds.max.y), new Vector3((pCol.bounds.max.x - pCol.bounds.min.x) - groundDist, groundDist, 0));


		Gizmos.color = new Color(1, 0, 1);								  
		Gizmos.DrawWireSphere(new Vector2(pCol.bounds.min.x, pCol.bounds.center.y), groundDist);
		Gizmos.DrawWireSphere(new Vector2(pCol.bounds.max.x, pCol.bounds.center.y), groundDist);
    }
#endif
}