using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarMovements : MonoBehaviour
{
    public LayerMask playerLayer;

    public GameObject pillar1;
    public GameObject pillar2;
    public GameObject pillar3;
    public GameObject pillar4;
    public GameObject pillar5;
    public GameObject pillar6;
    public GameObject pillar7;
    public GameObject pillar8;

    [HideInInspector] public static int pillar1Pos = 1;
    [HideInInspector] public static int pillar2Pos = 2;
    [HideInInspector] public static int pillar3Pos = 2;
    [HideInInspector] public static int pillar4Pos = 0;
    [HideInInspector] public static int pillar5Pos = 2;
    [HideInInspector] public static int pillar6Pos = 0;
    [HideInInspector] public static int pillar7Pos = 1;
    [HideInInspector] public static int pillar8Pos = 2;

    public GameObject ButtonIndicator;
    public GameObject upIndicator;
    public GameObject downIndicator;

    public Sprite grabSprite;
    public Sprite releaseSprite;

    bool canMovePillars = true;
    bool held = false;
    int heldBy = 10;
    PlayerController player;

    public GameObject door;

    CameraController cam;

    // Start is called before the first frame update
    void Start()
    {
        MovePillarSprites();

        player = FindObjectOfType<PlayerController>();
        cam = FindObjectOfType<CameraController>();

        if (pillar1Pos == 2 && pillar2Pos == 1 && pillar3Pos == 1 && pillar4Pos == 2 && pillar5Pos == 0 && pillar6Pos == 1 && pillar7Pos == 2 && pillar8Pos == 1)
        {
            door.transform.position = new Vector3(door.transform.position.x, 6.6f, door.transform.position.z);

            canMovePillars = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (canMovePillars)
        {
            MovePillarSprites();

            ButtonIndicator.transform.position = player.transform.position + Vector3.right;
            upIndicator.transform.position = ButtonIndicator.transform.position + Vector3.up * 0.32f;
            downIndicator.transform.position = ButtonIndicator.transform.position + Vector3.down * 0.32f;

            TestForPlayer();

            if (held)
            {
                Move();
            }
        }

        if (pillar1Pos == 2 && pillar2Pos == 1 && pillar3Pos == 1 && pillar4Pos == 2 && pillar5Pos == 0 && pillar6Pos == 1 && pillar7Pos == 2 && pillar8Pos == 1)
        {
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = false;
            upIndicator.GetComponent<SpriteRenderer>().enabled = false;
            downIndicator.GetComponent<SpriteRenderer>().enabled = false;

            door.transform.position = Vector3.Lerp(door.transform.position, new Vector3(door.transform.position.x, 6.6f, door.transform.position.z), Time.deltaTime);

            if (door.transform.position.y < 6)
            {
                cam.OverridePos(true, new Vector3(27.5f, 2.9f, -10));
            }
            else
            {
                cam.OverridePos(false);
                canMovePillars = false;
            }
        }
    }

    void MovePillarSprites ()
    {
        // Pillar 1

        if (pillar1Pos == 0)
        {
            pillar1.transform.position = Vector3.MoveTowards(pillar1.transform.position, new Vector3(pillar1.transform.position.x, -3.75f, pillar1.transform.position.z), 0.1f);
        }

        if (pillar1Pos == 1)
        {
            pillar1.transform.position = Vector3.MoveTowards(pillar1.transform.position, new Vector3(pillar1.transform.position.x, -1.25f, pillar1.transform.position.z), 0.1f);
        }

        if (pillar1Pos == 2)
        {
            pillar1.transform.position = Vector3.MoveTowards(pillar1.transform.position, new Vector3(pillar1.transform.position.x, 1.25f, pillar1.transform.position.z), 0.1f);
        }

        // Pillar 2

        if (pillar2Pos == 0)
        {
            pillar2.transform.position = Vector3.MoveTowards(pillar2.transform.position, new Vector3(pillar2.transform.position.x, -3.75f, pillar2.transform.position.z), 0.1f);
        }

        if (pillar2Pos == 1)
        {
            pillar2.transform.position = Vector3.MoveTowards(pillar2.transform.position, new Vector3(pillar2.transform.position.x, -1.25f, pillar2.transform.position.z), 0.1f);
        }

        if (pillar2Pos == 2)
        {
            pillar2.transform.position = Vector3.MoveTowards(pillar2.transform.position, new Vector3(pillar2.transform.position.x, 1.25f, pillar2.transform.position.z), 0.1f);
        }

        // Pillar 3

        if (pillar3Pos == 0)
        {
            pillar3.transform.position = Vector3.MoveTowards(pillar3.transform.position, new Vector3(pillar3.transform.position.x, -3.75f, pillar3.transform.position.z), 0.1f);
        }

        if (pillar3Pos == 1)
        {
            pillar3.transform.position = Vector3.MoveTowards(pillar3.transform.position, new Vector3(pillar3.transform.position.x, -1.25f, pillar3.transform.position.z), 0.1f);
        }

        if (pillar3Pos == 2)
        {
            pillar3.transform.position = Vector3.MoveTowards(pillar3.transform.position, new Vector3(pillar3.transform.position.x, 1.25f, pillar3.transform.position.z), 0.1f);
        }

        // Pillar 4

        if (pillar4Pos == 0)
        {
            pillar4.transform.position = Vector3.MoveTowards(pillar4.transform.position, new Vector3(pillar4.transform.position.x, -3.75f, pillar4.transform.position.z), 0.1f);
        }

        if (pillar4Pos == 1)
        {
            pillar4.transform.position = Vector3.MoveTowards(pillar4.transform.position, new Vector3(pillar4.transform.position.x, -1.25f, pillar4.transform.position.z), 0.1f);
        }

        if (pillar4Pos == 2)
        {
            pillar4.transform.position = Vector3.MoveTowards(pillar4.transform.position, new Vector3(pillar4.transform.position.x, 1.25f, pillar4.transform.position.z), 0.1f);
        }

        // Pillar 5

        if (pillar5Pos == 0)
        {
            pillar5.transform.position = Vector3.MoveTowards(pillar5.transform.position, new Vector3(pillar5.transform.position.x, -3.75f, pillar5.transform.position.z), 0.1f);
        }

        if (pillar5Pos == 1)
        {
            pillar5.transform.position = Vector3.MoveTowards(pillar5.transform.position, new Vector3(pillar5.transform.position.x, -1.25f, pillar5.transform.position.z), 0.1f);
        }

        if (pillar5Pos == 2)
        {
            pillar5.transform.position = Vector3.MoveTowards(pillar5.transform.position, new Vector3(pillar5.transform.position.x, 1.25f, pillar5.transform.position.z), 0.1f);
        }

        // Pillar 6

        if (pillar6Pos == 0)
        {
            pillar6.transform.position = Vector3.MoveTowards(pillar6.transform.position, new Vector3(pillar6.transform.position.x, -3.75f, pillar6.transform.position.z), 0.1f);
        }

        if (pillar6Pos == 1)
        {
            pillar6.transform.position = Vector3.MoveTowards(pillar6.transform.position, new Vector3(pillar6.transform.position.x, -1.25f, pillar6.transform.position.z), 0.1f);
        }

        if (pillar6Pos == 2)
        {
            pillar6.transform.position = Vector3.MoveTowards(pillar6.transform.position, new Vector3(pillar6.transform.position.x, 1.25f, pillar6.transform.position.z), 0.1f);
        }

        // Pillar 7

        if (pillar7Pos == 0)
        {
            pillar7.transform.position = Vector3.MoveTowards(pillar7.transform.position, new Vector3(pillar7.transform.position.x, -3.75f, pillar7.transform.position.z), 0.1f);
        }

        if (pillar7Pos == 1)
        {
            pillar7.transform.position = Vector3.MoveTowards(pillar7.transform.position, new Vector3(pillar7.transform.position.x, -1.25f, pillar7.transform.position.z), 0.1f);
        }

        if (pillar7Pos == 2)
        {
            pillar7.transform.position = Vector3.MoveTowards(pillar7.transform.position, new Vector3(pillar7.transform.position.x, 1.25f, pillar7.transform.position.z), 0.1f);
        }

        // Pillar 8

        if (pillar8Pos == 0)
        {
            pillar8.transform.position = Vector3.MoveTowards(pillar8.transform.position, new Vector3(pillar8.transform.position.x, -3.75f, pillar8.transform.position.z), 0.1f);
        }

        if (pillar8Pos == 1)
        {
            pillar8.transform.position = Vector3.MoveTowards(pillar8.transform.position, new Vector3(pillar8.transform.position.x, -1.25f, pillar8.transform.position.z), 0.1f);
        }

        if (pillar8Pos == 2)
        {
            pillar8.transform.position = Vector3.MoveTowards(pillar8.transform.position, new Vector3(pillar8.transform.position.x, 1.25f, pillar8.transform.position.z), 0.1f);
        }
    }

    void Move()
    {
        Stats.canMove = false;

        if (heldBy == 1)
        {
            player.transform.position = pillar1.transform.position + Vector3.up * 3.5f;
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = releaseSprite;

            if (InputManager.ReleaseJump())
            {
                held = false;
                Stats.canMove = true;
            }

            if (InputManager.PressVertical() >= 0)
            {
                pillar1Pos = Mathf.Clamp(pillar1Pos + 1, 0, 3);
            }

            if (InputManager.PressVertical() <= 0)
            {
                pillar1Pos = Mathf.Clamp(pillar1Pos - 1, 0, 2);
            }

            if (InputManager.ReleaseJump())
            {
                held = false;
            }

            if (pillar1Pos == 0)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (pillar1Pos == 1)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (pillar1Pos == 2)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = false;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (heldBy == 2)
        {
            player.transform.position = pillar2.transform.position + Vector3.up * 3.5f;
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = releaseSprite;

            if (InputManager.ReleaseJump())
            {
                held = false;
                Stats.canMove = true;
            }

            if (InputManager.PressVertical() >= 0)
            {
                pillar2Pos = Mathf.Clamp(pillar2Pos + 1, 0, 3);
            }

            if (InputManager.PressVertical() <= 0)
            {
                pillar2Pos = Mathf.Clamp(pillar2Pos - 1, 0, 2);
            }

            if (InputManager.ReleaseJump())
            {
                held = false;
            }

            if (pillar2Pos == 0)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (pillar2Pos == 1)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (pillar2Pos == 2)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = false;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (heldBy == 3)
        {
            player.transform.position = pillar3.transform.position + Vector3.up * 3.5f;
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = releaseSprite;

            if (InputManager.ReleaseJump())
            {
                held = false;
                Stats.canMove = true;
            }

            if (InputManager.PressVertical() >= 0)
            {
                pillar3Pos = Mathf.Clamp(pillar3Pos + 1, 0, 3);
            }

            if (InputManager.PressVertical() <= 0)
            {
                pillar3Pos = Mathf.Clamp(pillar3Pos - 1, 0, 2);
            }

            if (InputManager.ReleaseJump())
            {
                held = false;
            }

            if (pillar3Pos == 0)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (pillar3Pos == 1)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (pillar3Pos == 2)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = false;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (heldBy == 4)
        {
            player.transform.position = pillar4.transform.position + Vector3.up * 3.5f;
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = releaseSprite;

            if (InputManager.ReleaseJump())
            {
                held = false;
                Stats.canMove = true;
            }

            if (InputManager.PressVertical() >= 0)
            {
                pillar4Pos = Mathf.Clamp(pillar4Pos + 1, 0, 3);
            }

            if (InputManager.PressVertical() <= 0)
            {
                pillar4Pos = Mathf.Clamp(pillar4Pos - 1, 0, 2);
            }

            if (InputManager.ReleaseJump())
            {
                held = false;
            }

            if (pillar4Pos == 0)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (pillar4Pos == 1)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (pillar4Pos == 2)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = false;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (heldBy == 5)
        {
            player.transform.position = pillar5.transform.position + Vector3.up * 3.5f;
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = releaseSprite;

            if (InputManager.ReleaseJump())
            {
                held = false;
                Stats.canMove = true;
            }

            if (InputManager.PressVertical() >= 0)
            {
                pillar5Pos = Mathf.Clamp(pillar5Pos + 1, 0, 3);
            }

            if (InputManager.PressVertical() <= 0)
            {
                pillar5Pos = Mathf.Clamp(pillar5Pos - 1, 0, 2);
            }

            if (InputManager.ReleaseJump())
            {
                held = false;
            }

            if (pillar5Pos == 0)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (pillar5Pos == 1)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (pillar5Pos == 2)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = false;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (heldBy == 6)
        {
            player.transform.position = pillar6.transform.position + Vector3.up * 3.5f;
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = releaseSprite;

            if (InputManager.ReleaseJump())
            {
                held = false;
                Stats.canMove = true;
            }

            if (InputManager.PressVertical() >= 0)
            {
                pillar6Pos = Mathf.Clamp(pillar6Pos + 1, 0, 3);
            }

            if (InputManager.PressVertical() <= 0)
            {
                pillar6Pos = Mathf.Clamp(pillar6Pos - 1, 0, 2);
            }

            if (InputManager.ReleaseJump())
            {
                held = false;
            }

            if (pillar6Pos == 0)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (pillar6Pos == 1)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (pillar6Pos == 2)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = false;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (heldBy == 7)
        {
            player.transform.position = pillar7.transform.position + Vector3.up * 3.5f;
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = releaseSprite;

            if (InputManager.ReleaseJump())
            {
                held = false;
                Stats.canMove = true;
            }

            if (InputManager.PressVertical() >= 0)
            {
                pillar7Pos = Mathf.Clamp(pillar7Pos + 1, 0, 3);
            }

            if (InputManager.PressVertical() <= 0)
            {
                pillar7Pos = Mathf.Clamp(pillar7Pos - 1, 0, 2);
            }

            if (InputManager.ReleaseJump())
            {
                held = false;
            }

            if (pillar7Pos == 0)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (pillar7Pos == 1)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (pillar7Pos == 2)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = false;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
        else if (heldBy == 8)
        {
            player.transform.position = pillar8.transform.position + Vector3.up * 3.5f;
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = releaseSprite;

            if (InputManager.ReleaseJump())
            {
                held = false;
                Stats.canMove = true;
            }

            if (InputManager.PressVertical() >= 0)
            {
                pillar8Pos = Mathf.Clamp(pillar8Pos + 1, 0, 3);
            }

            if (InputManager.PressVertical() <= 0)
            {
                pillar8Pos = Mathf.Clamp(pillar8Pos - 1, 0, 2);
            }

            if (InputManager.ReleaseJump())
            {
                held = false;
            }

            if (pillar8Pos == 0)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (pillar8Pos == 1)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = true;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
            else if (pillar8Pos == 2)
            {
                upIndicator.GetComponent<SpriteRenderer>().enabled = false;
                downIndicator.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    void TestForPlayer ()
    {
        if(Physics2D.OverlapCircle(pillar1.transform.position + Vector3.up * 3.5f, 1, playerLayer))
        {           
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = grabSprite;

            if (InputManager.PressJump())
            {
                held = true;
                heldBy = 1;
            }
        }
        else if (Physics2D.OverlapCircle(pillar2.transform.position + Vector3.up * 3.5f, 1, playerLayer))
        {
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = grabSprite;

            if (InputManager.PressJump())
            {
                held = true;
                heldBy = 2;
            }
        }
        else if (Physics2D.OverlapCircle(pillar3.transform.position + Vector3.up * 3.5f, 1, playerLayer))
        {
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = grabSprite;

            if (InputManager.PressJump())
            {
                held = true;
                heldBy = 3;
            }
        }
        else if (Physics2D.OverlapCircle(pillar4.transform.position + Vector3.up * 3.5f, 1, playerLayer))
        {
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = grabSprite;

            if (InputManager.PressJump())
            {
                held = true;
                heldBy = 4;
            }
        }
        else if (Physics2D.OverlapCircle(pillar5.transform.position + Vector3.up * 3.5f, 1, playerLayer))
        {
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = grabSprite;

            if (InputManager.PressJump())
            {
                held = true;
                heldBy = 5;
            }
        }
        else if (Physics2D.OverlapCircle(pillar6.transform.position + Vector3.up * 3.5f, 1, playerLayer))
        {
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = grabSprite;

            if (InputManager.PressJump())
            {
                held = true;
                heldBy = 6;
            }
        }
        else if (Physics2D.OverlapCircle(pillar7.transform.position + Vector3.up * 3.5f, 1, playerLayer))
        {
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = grabSprite;

            if (InputManager.PressJump())
            {
                held = true;
                heldBy = 7;
            }
        }
        else if (Physics2D.OverlapCircle(pillar8.transform.position + Vector3.up * 3.5f, 1, playerLayer))
        {
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = true;
            ButtonIndicator.GetComponent<SpriteRenderer>().sprite = grabSprite;

            if (InputManager.PressJump())
            {
                held = true;
                heldBy = 8;
            }
        }
        else
        {
            ButtonIndicator.GetComponent<SpriteRenderer>().enabled = false;
            upIndicator.GetComponent<SpriteRenderer>().enabled = false;
            downIndicator.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    #if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawWireSphere(pillar1.transform.position + Vector3.up * 3.5f, 1);
        Gizmos.DrawWireSphere(pillar2.transform.position + Vector3.up * 3.5f, 1);
        Gizmos.DrawWireSphere(pillar3.transform.position + Vector3.up * 3.5f, 1);
        Gizmos.DrawWireSphere(pillar4.transform.position + Vector3.up * 3.5f, 1);
        Gizmos.DrawWireSphere(pillar5.transform.position + Vector3.up * 3.5f, 1);
        Gizmos.DrawWireSphere(pillar6.transform.position + Vector3.up * 3.5f, 1);
        Gizmos.DrawWireSphere(pillar7.transform.position + Vector3.up * 3.5f, 1);
        Gizmos.DrawWireSphere(pillar8.transform.position + Vector3.up * 3.5f, 1);
    }
    #endif
}
