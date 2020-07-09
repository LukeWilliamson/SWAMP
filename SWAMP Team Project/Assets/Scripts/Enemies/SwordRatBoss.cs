using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRatBoss : MonoBehaviour
{
    public GameObject wallPieces;
    public GameObject wallBreak;
    GameObject[] pieces = new GameObject[8];
    public int pieceCount = 0;

    float maxHeight;
    Rigidbody2D rigBod;
    PlayerController player;
    Vector3 target;
    bool jump = false;
    bool begun = false;

    public BoxCollider2D[] circuitBoxes;
    public BoxCollider2D[] shockPanels;
    public Animator[] shockHandles;
    public Animator sparkAnim;
    bool takingDamage = false;
    bool checkBoss = false;
    bool testing = false;

    public GameObject swordItem;
    public SpriteRenderer pullSprite;

    void Start()
    {
        if(Stats.beatRatBoss)
        {
            Destroy(this.gameObject);
        }

        maxHeight = transform.position.y + 5.75f;
        rigBod = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        foreach(Transform wallPiece in wallPieces.GetComponentsInChildren<Transform>())
        {
            if (wallPiece.gameObject.name != "Wall Crumble")
            {
                pieces[pieceCount] = wallPiece.gameObject;
                pieceCount += 1;
            }
        }

        pieceCount = pieces.Length;
    }

    void Update()
    {
        if (GetComponent<EnemyManager>().requiresTrigger == false && !begun)
        {
            StartCoroutine(Attack());
            begun = true;
        }
        if(jump)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, 1);
        }

        if(transform.position == target)
        {
            jump = false;
        }

        if (PlayerInBounds() != 0)
        {
            if (!testing)
            {
                pullSprite.enabled = true;
            }

            if (InputManager.PressVertical() < 0)
            {
                sparkAnim.SetInteger("Spark", PlayerInBounds());
                shockHandles[PlayerInBounds() - 1].SetTrigger("Pull");
                testing = true;
                StartCoroutine(TakeDamage());
            }
        }
        else
        {
            if (!testing)
            {
                pullSprite.enabled = false;
            }
        }
    }

    int PlayerInBounds()
    {
        for (int i = 0; i < circuitBoxes.Length; i++)
        {
            if (circuitBoxes[i].bounds.max.x > player.transform.position.x &&
                    circuitBoxes[i].bounds.min.x < player.transform.position.x &&
                    circuitBoxes[i].bounds.max.y > player.transform.position.y &&
                    circuitBoxes[i].bounds.min.y < player.transform.position.y)
            {
                return i + 1;
            }
        }
        return 0;
    }

    int BossInBounds()
    {
        for (int i = 0; i < circuitBoxes.Length; i++)
        {
            if (shockPanels[i].bounds.max.x > transform.position.x &&
                    shockPanels[i].bounds.min.x < transform.position.x)
            {
                return i + 1;
            }
        }

        return 0;
    }

    IEnumerator TakeDamage()
    {
        pullSprite.enabled = false;

        if (BossInBounds() == PlayerInBounds() && checkBoss)
        {
            takingDamage = true;
        }

        yield return new WaitForSeconds(1);

        sparkAnim.SetInteger("Spark", 0);

        if (BossInBounds() == PlayerInBounds() && checkBoss)
        {
            takingDamage = true;
        }

        yield return new WaitForSeconds(1);

        sparkAnim.SetInteger("Spark", 0);

        if (BossInBounds() == PlayerInBounds() && checkBoss)
        {
            takingDamage = true;
        }

        if (takingDamage)
        {
            GetComponent<EnemyManager>().health -= 1;
            GetComponentInChildren<SpriteRenderer>().color += new Color(0.2f, 0, 0);
            yield return new WaitForSeconds(2);
            takingDamage = false;

            if (GetComponent<EnemyManager>().health > 0)
            {
                StartCoroutine(Attack());
            }
            else
            {
                GameObject sword = Instantiate(swordItem);
                sword.transform.position = transform.position;
                FindObjectOfType<BossArena>().OpenDoors();
                Stats.beatRatBoss = true;
                GetComponent<EnemyManager>().Die();
            }
        }

        testing = false;
    }

    IEnumerator Attack()
    {
        rigBod.gravityScale = 0;

        target = new Vector3(player.transform.position.x, maxHeight, 0.1f);
        jump = true;

        yield return new WaitForSeconds(0.5f);
        rigBod.gravityScale = 1;
        yield return new WaitForSeconds(1.5f);

        /********************************************/

        rigBod.gravityScale = 0;

        target = new Vector3(player.transform.position.x, maxHeight, 0.1f);
        jump = true;

        yield return new WaitForSeconds(0.5f);
        rigBod.gravityScale = 1;
        yield return new WaitForSeconds(1.5f);

        /********************************************/

        rigBod.gravityScale = 0;

        target = new Vector3(player.transform.position.x, maxHeight, 0.1f);
        jump = true;

        yield return new WaitForSeconds(0.5f);
        rigBod.gravityScale = 1;
        yield return new WaitForSeconds(1f);

        checkBoss = true;
        if (pieceCount > 0)
        {
            StartCoroutine(breakWall());
        }
        yield return new WaitForSeconds(3f);
        checkBoss = false;

        if (!takingDamage)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator breakWall ()
    {
        int randomPiece = Random.Range(0, pieces.Length);

        if (pieces[randomPiece] != null)
        {
            GameObject breakPart = Instantiate(wallBreak);
            breakPart.transform.position = pieces[randomPiece].transform.position;
            Destroy(pieces[randomPiece]);
            pieceCount -= 1;

            yield return new WaitForSeconds(2);
        }
        else if (pieceCount > 0)
        {
            StartCoroutine(breakWall());
        }
    }
}
