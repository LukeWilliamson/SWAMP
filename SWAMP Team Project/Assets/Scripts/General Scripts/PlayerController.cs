using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public bool onWall;
    [HideInInspector]
    public bool scalingBackground;
    [HideInInspector]
    public bool nearLadder;
    bool climbingLadder;
    [HideInInspector]
    public GameObject ladder;

    [HideInInspector]
    public Rigidbody2D rigBod;
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

    float attackCooldown = 0;
    bool attacking;
    [HideInInspector]
    public bool facingLeft;
    public float invulnerabilityTimer;

    public AnimationClip dieAnim;
    public Vector3 knockbackPos;
    public GameObject swordOnBack;

    void Start()
    {
		rigBod = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<BoxCollider2D>();
		anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        ClampFallSpeed(-15);

        if (Stats.canMove)
        {
            if (inWater)
            {
                Swim(20);
            }
			/*else if (scalingBackground && InputManager.HoldCrouch() && Stats.canScaleBackground)
            {
                Swim(0);
            }*/
            else
            {
                //jumpForce = 10;
                Walk();
            }

            if(nearLadder && InputManager.HoldVertical() != 0 && InputManager.HoldHorizontal() == 0)
            {
                ClimbLadder();
            }
            else if(InputManager.HoldHorizontal() != 0)
            {
                climbingLadder = false;
            }

            if (!grounded)
            {
                //WallJump();
            }
        }
        else
        {
            rigBod.velocity = new Vector2(0, rigBod.velocity.y);
        }

        anim.SetBool("CanMove", Stats.canMove);
    }

	void Walk()
	{
		rigBod.gravityScale = 5;
		rigBod.velocity = new Vector2(InputManager.HoldHorizontal() * moveSpeed, rigBod.velocity.y);

        if(InputManager.HoldHorizontal() > 0)
        {
            facingLeft = false;
        }
        if (InputManager.HoldHorizontal() < 0)
        {
            facingLeft = true;
        }
    }

    void ClimbLadder()
    {
        climbingLadder = true;
        transform.position = new Vector3(Mathf.Lerp(transform.position.x, ladder.transform.position.x, Time.deltaTime * moveSpeed), transform.position.y, transform.position.z);

        if (InputManager.HoldVertical() > 0)
        {
            if (transform.position.y + 1 < ladder.GetComponent<BoxCollider2D>().bounds.max.y - 1f)
            {
                transform.position += Vector3.up * 0.1f;
            }
        }
        else if (InputManager.HoldVertical() < 0)
        {
            if (transform.position.y - 1 > ladder.GetComponent<BoxCollider2D>().bounds.min.y + 1)
            {
                transform.position -= Vector3.up * 0.1f;
            }
        }
    }

	void Swim (float gravityModifier)
	{
		//rigBod.gravityScale = gravityModifier;

		if(Stats.canFreeSwim)
		{
			rigBod.velocity = new Vector2(InputManager.HoldHorizontal(), InputManager.HoldVertical()) * swimSpeed;
            rigBod.gravityScale = 0;
		}
		else
		{
			rigBod.velocity = new Vector2(InputManager.HoldHorizontal() * moveSpeed, rigBod.velocity.y);
            jumpForce = 0;
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
        if (Stats.canMove)
        {
            if (waitToJump >= 0)
            {
                waitToJump -= Time.deltaTime;
            }
            if (waitToJump <= 0)
            {
                grounded = Physics2D.OverlapCircle(new Vector2(playerCol.bounds.center.x, playerCol.bounds.min.y), 0.05f, groundLayer);
            }

            hitHead = Physics2D.OverlapCircle(new Vector2(playerCol.bounds.center.x, playerCol.bounds.max.y), 0.05f, groundLayer);

            if (hitHead)
            {
                isJumping = false;
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

			if (jumps != 0 && InputManager.PressJump() && grounded)
            {
                jumps -= 1;
                isJumping = true;
                grounded = false;
                waitToJump = 0.25f;
                jumpTimeCounter = jumpTime;
                rigBod.velocity = Vector2.up * jumpForce;
            }

			if (InputManager.HoldJump() && isJumping)
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

			if (InputManager.ReleaseJump())
            {
                isJumping = false;
            }

            CheckCollision();

            if (inWater && Stats.canFreeSwim)
            {

            }
            else if (scalingBackground && Input.GetKey(KeyCode.LeftControl) && Stats.canScaleBackground)
            {

            }
            else
            {
				if (grounded && InputManager.HoldCrouch())
                {
                    spiderForm = true;
                }
                else
                {
                    spiderForm = false;
                }

                if (!wallJumping)
                {
                    Jump();
                }

                //WallJump();
            }

            AnimatePlayer();

            if (Stats.hasSword)
            {
                Attack();
            }

            TakeDamage();


            if (climbingLadder)
            {
                rigBod.velocity = new Vector2(rigBod.velocity.x, 0);
                rigBod.gravityScale = 0;
            }
        }
    
        if (invulnerabilityTimer <= 0)
        {
            invulnerabilityTimer = 0;
        }
        else if (invulnerabilityTimer < 1)
        {
            Stats.canMove = true;
            invulnerabilityTimer -= Time.deltaTime;
        }
        else
        {
            invulnerabilityTimer -= Time.deltaTime;
            Knockback();
        }

        if (Stats.playerHealth <= 0)
        {
            Image blackScreen = FindObjectOfType<CameraController>().blackScreen.GetComponent<Image>();
            blackScreen.color = Color.Lerp(blackScreen.color, Color.black, Time.deltaTime * 4);
        }
    }

    void TakeDamage ()
    {
        Collider2D[] enemies = Physics2D.OverlapBoxAll(transform.position, GetComponent<BoxCollider2D>().size * transform.localScale, 0);

        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].GetComponent<EnemyManager>() && invulnerabilityTimer <= 0)
            {
                if (enemies[i].GetComponent<EnemyManager>().damageValue != 0)
                {
                    Stats.playerHealth -= enemies[i].GetComponent<EnemyManager>().damageValue;
                    Stats.canMove = false;
                    invulnerabilityTimer = 1.5f;

                    if (transform.position.x > enemies[i].transform.position.x)
                    {
                        knockbackPos = (new Vector2(transform.position.x, transform.position.y) + (Vector2.up * 0.5f) + Vector2.right) * 10;
                    }
                    else
                    {
                        knockbackPos = (new Vector2(transform.position.x, transform.position.y) + (Vector2.up * 0.5f) + Vector2.left) * 10;
                    }
                    return;
                }
            }
        }

        if(Stats.playerHealth <= 0)
        {
            StartCoroutine(Die());
        }
    }

    void Knockback()
    {
        transform.position = Vector2.MoveTowards(transform.position, knockbackPos, 0.5f);
        knockbackPos -= Physics.gravity;
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

		if (jumps != 0 && InputManager.PressJump() && grounded)
		{
			jumps -= 1;
			isJumping = true;
			grounded = false;
			waitToJump = 0.25f;
			jumpTimeCounter = jumpTime;
			rigBod.velocity = Vector2.up * jumpForce;
		}

		if (InputManager.HoldJump() && isJumping && !wallJumping)
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

		if (InputManager.ReleaseJump())
		{
			isJumping = false;
		}
	}

	void WallJump()
	{
        if ((hitWallRight || hitWallLeft) && Input.GetKey(KeyCode.RightControl))
        {
            rigBod.gravityScale = 0;
            rigBod.velocity = Vector2.zero;
        }
        else
        {
            rigBod.gravityScale = 5;
        }

		if(InputManager.HoldHorizontal() != 0)
		{
			if(hitWallRight || hitWallLeft)
			{
				ClampFallSpeed(-5);
			}

			if(hitWallRight && InputManager.PressJump())
			{
				rightWall = true;
				wallJumping = true;
				wallJumpTimeCounter = wallJumpTime;
				rigBod.velocity = new Vector2(-jumpForce, jumpForce);
			}

			if(hitWallLeft && InputManager.PressJump())
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

    void Attack ()
    {
        Collider2D[] enemies = new Collider2D[10];
        
        if(InputManager.PressAttack() && attackCooldown <= 0)
        {
            StartCoroutine(StopAttacking());
            attackCooldown = 0.5f;

            if (facingLeft)
            {
                enemies = Physics2D.OverlapCircleAll(transform.position + Vector3.left * 0.25f, 1f);
            }
            else if (!facingLeft)
            {
                enemies = Physics2D.OverlapCircleAll(transform.position + Vector3.right * 0.25f, 1f);
            }

            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].GetComponent<EnemyManager>())
                {
                    enemies[i].gameObject.GetComponent<EnemyManager>().Damage(Stats.playerStrength);
                }
            }

            anim.SetTrigger("Attack1");
        }

        else if (InputManager.PressAttack() && attackCooldown > 0)
        {
            StartCoroutine(StopAttacking());
            attackCooldown = 0;

            if (facingLeft)
            {
                enemies = Physics2D.OverlapCircleAll(transform.position + Vector3.left * 0.25f, 1f);
            }
            else if (!facingLeft)
            {
                enemies = Physics2D.OverlapCircleAll(transform.position + Vector3.right * 0.25f, 1f);
            }

            for(int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].GetComponent<EnemyManager>())
                {
                    enemies[i].gameObject.GetComponent<EnemyManager>().Damage(Stats.playerStrength * 1.5f);
                }
            }

            anim.SetTrigger("Attack2");
        }

        attackCooldown -= Time.deltaTime;
    }

    IEnumerator StopAttacking()
    {
        attacking = true;
        yield return new WaitForSeconds(0.25f);
        attacking = false;
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
        if(Stats.hasSword && !attacking)
        {
            swordOnBack.SetActive(true);
        }
        else
        {
            swordOnBack.SetActive(false);
        }

        if (!Stats.isPaused)
        {
            anim.SetFloat("Move", InputManager.HoldHorizontal());
            anim.SetBool("Grounded", grounded);
            anim.SetBool("Spider", spiderForm);
            anim.SetFloat("Look", InputManager.HoldHorizontal());
        }
	}

	public IEnumerator Die ()
	{
        invulnerabilityTimer = 0;
        Stats.canMove = false;
        if(dieAnim != null)
        {
            anim.SetTrigger("Die");
            yield return new WaitForSeconds(dieAnim.length);
        }

        FindObjectOfType<CameraController>().blackScreen.GetComponent<Image>().color = Color.black;
        Stats.playerHealth = Stats.maxPlayerHealth;
        Stats.canMove = true;
        invulnerabilityTimer = 1000;

        Stats.respawning = true;
        UnityEngine.SceneManagement.SceneManager.LoadScene(Stats.currentWorkbenchScene);
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
		BoxCollider2D pCol = UnityEditor.Selection.activeGameObject.GetComponent<BoxCollider2D>();
	
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireCube(new Vector2(pCol.bounds.center.x, pCol.bounds.min.y), new Vector3((pCol.bounds.max.x - pCol.bounds.min.x) - groundDist, groundDist, 0));

		Gizmos.color = Color.green;
		Gizmos.DrawWireCube(new Vector2(pCol.bounds.center.x, pCol.bounds.max.y), new Vector3((pCol.bounds.max.x - pCol.bounds.min.x) - groundDist, groundDist, 0));

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + Vector3.left * 0.25f, 1f);
        Gizmos.DrawWireSphere(transform.position - Vector3.left * 0.25f, 1f);

        Gizmos.color = new Color(1, 0, 1);								  
		Gizmos.DrawWireSphere(new Vector2(pCol.bounds.min.x, pCol.bounds.center.y), groundDist);
		Gizmos.DrawWireSphere(new Vector2(pCol.bounds.max.x, pCol.bounds.center.y), groundDist);
    }
#endif
}