using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawnpoint : MonoBehaviour
{
    public int workbenchID;
    bool sitting;
    BoxCollider2D col;
    PlayerController player;

    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        player = FindObjectOfType<PlayerController>();

        if(Stats.respawning && workbenchID == Stats.globalWorkbenchID)
        {
            player.transform.position = transform.position + Vector3.forward;
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0);
            Stats.respawning = false;
            sitting = true;
        }
    }

    void Update()
    {
        if(!sitting && InputManager.PressVertical() > 0 && PlayerInBounds())
        {
            Stats.canMove = false;
            Stats.globalWorkbenchID = workbenchID;
            Stats.playerHealth = Stats.maxPlayerHealth;
            Stats.currentWorkbenchScene = SceneManager.GetActiveScene().name;
            sitting = true;
        }
        else if (sitting && InputManager.PressVertical() > 0)
        {
            Stats.canMove = true;
            sitting = false;
        }

        if(Stats.globalWorkbenchID != workbenchID && PlayerInBounds())
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

    bool PlayerInBounds()
    {
        if (col.bounds.max.x > player.transform.position.x &&
                col.bounds.min.x < player.transform.position.x &&
                col.bounds.max.y > player.transform.position.y &&
                col.bounds.min.y < player.transform.position.y)
        {
            return true;
        }

        return false;
    }
}