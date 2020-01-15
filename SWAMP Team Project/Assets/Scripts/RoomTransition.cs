using System.Collections;
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

	bool entering = true;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

		StartCoroutine(EnterRoom());

		if(doorID == Stats.globalDoorID)
		{
			player.transform.position = spawnPos;
		}
    }

    void IsPlayerInBounds()
    {
        if (transform.position.x + (size.x / 2) > player.transform.position.x &&
                transform.position.x - (size.x / 2) < player.transform.position.x &&
                transform.position.y + (size.y / 2) > player.transform.position.y &&
                transform.position.y - (size.y / 2) < player.transform.position.y)
        {
            loadRoom = true;
			Stats.globalDoorID = doorID;
            Stats.canMove = false;
        }
    }

	IEnumerator EnterRoom ()
	{
		yield return new WaitForSeconds(0.5f);
		Stats.canMove = true;
		entering = false;
	}

    void Update()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			UnityEngine.SceneManagement.SceneManager.LoadScene("Pause Menu", LoadSceneMode.Additive);
		}

		if(entering)
		{
			if (left)
			{
				player.transform.position += new Vector3(0.1f, 0, 0);
			}

			if (right)
			{
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

			blackScreen = FindObjectOfType<CameraController>().blackScreen.GetComponent<Image>();
		}
		else
		{
			IsPlayerInBounds();
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
		Gizmos.DrawSphere(spawnPos, 0.1f);
        #endif
    }


}
