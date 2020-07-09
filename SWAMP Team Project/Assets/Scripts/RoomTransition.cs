﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour
{
    public string roomToLoad;
	public int doorID;
	public Vector2 size;
    public Vector2 spawnPos;
	Image blackScreen;
    PlayerController player;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    float fadeTime = 1;
    bool loadRoom = false;

	bool entering = false;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if (doorID == Stats.globalDoorID)
		{
            float heightOffset = ((player.GetComponent<BoxCollider2D>().size.y / 2) - player.GetComponent<BoxCollider2D>().offset.y) * player.transform.localScale.y;
			player.transform.position = new Vector3(transform.position.x + spawnPos.x, transform.position.y + spawnPos.y + heightOffset, 0);
		}

        if (IsPlayerInBounds())
        {
            entering = true;
        }
    }

    bool IsPlayerInBounds()
    {
        if (transform.position.x + (size.x / 2) > player.transform.position.x &&
                transform.position.x - (size.x / 2) < player.transform.position.x &&
                transform.position.y + (size.y / 2) > player.transform.position.y &&
                transform.position.y - (size.y / 2) < player.transform.position.y)
        {
            return true;
        }

        return false;
    }

	IEnumerator EnterRoom ()
	{
		yield return new WaitForSeconds(0.5f);
        Stats.canMove = true;
		entering = false;
	}

    void Update()
    {
        if(entering && !IsPlayerInBounds())
        {
            StartCoroutine(EnterRoom());
        }

		blackScreen = FindObjectOfType<CameraController>().blackScreen.GetComponent<Image>();
        
        if (entering && doorID == Stats.globalDoorID)
		{
			if (left)
			{
                player.facingLeft = true;
				player.transform.position += new Vector3(0.1f, 0, 0);
			}

			if (right)
			{
                player.facingLeft = false;
                player.transform.position += new Vector3(-0.1f, 0, 0);
			}

			if (down)
			{
				player.transform.position += new Vector3(0, 0.1f, 0);
			}

			if (up)
			{
				player.transform.position += new Vector3(0, -0.1f, 0);
			}
		}
		else
        {
			if(IsPlayerInBounds() && roomToLoad != "None")
            {

                loadRoom = true;
                Stats.globalDoorID = doorID;

                /*if(left)
                {
                    Stats.doorOffset = -Mathf.Abs(player.transform.position.x - spawnPos.x);
                }

                if(right)
                {
                    Stats.doorOffset = Mathf.Abs(player.transform.position.x - spawnPos.x);
                }

                if(up)
                {
                    Stats.doorOffset = Mathf.Abs(player.transform.position.y - spawnPos.y);
                }

                if(down)
                {
                    Stats.doorOffset = -Mathf.Abs(player.transform.position.y - spawnPos.y);
                }*/

                Stats.canMove = false;
            }
		}
        
        if (loadRoom)
        {
            fadeTime -= Time.deltaTime;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            blackScreen.color = Color.Lerp(blackScreen.color, Color.black, Time.deltaTime * 4);

            if (right)
            {
                player.transform.position += new Vector3(0.1f, 0, 0);
            }

            if (left)
            {
                player.transform.position += new Vector3(-0.1f, 0, 0);
            }

            if (up)
            {
                player.transform.position += new Vector3(0, 0.1f, 0);
            }

            if (down)
            {
                player.transform.position += new Vector3(0, -0.1f, 0);
            }

            if (fadeTime < 0)
            {
                SceneManager.LoadScene(roomToLoad);
            }
        }
    }

    void OnDrawGizmos()
    {
        #if UNITY_EDITOR
        Gizmos.color = Color.blue;
		Gizmos.DrawWireCube(transform.position, size);
		Gizmos.color = Color.yellow;
		Gizmos.DrawWireSphere(new Vector3(transform.position.x + spawnPos.x, transform.position.y + spawnPos.y, 0), 0.1f);
        #endif
    }


}