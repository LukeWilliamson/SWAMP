using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RoomTransition : MonoBehaviour
{
    public string roomToLoad;
    public Vector2 size;
    GameObject blackScreen;
    PlayerController player;

    public bool up;
    public bool down;
    public bool left;
    public bool right;

    float fadeTime = 1;
    bool loadRoom = false;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        blackScreen = new GameObject("Black Screen");
        blackScreen.AddComponent<Image>();
        blackScreen.transform.parent = FindObjectOfType<Canvas>().transform;

        blackScreen.GetComponent<RectTransform>().anchorMin = Vector2.zero;
        blackScreen.GetComponent<RectTransform>().anchorMax = Vector2.one;

        blackScreen.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        blackScreen.GetComponent<RectTransform>().offsetMax = Vector2.zero;

        blackScreen.GetComponent<Image>().color = Color.clear;
    }

    void IsPlayerInBounds()
    {
        if (transform.position.x + (size.x / 2) > player.transform.position.x &&
                transform.position.x - (size.x / 2) < player.transform.position.x &&
                transform.position.y + (size.y / 2) > player.transform.position.y &&
                transform.position.y - (size.y / 2) < player.transform.position.y)
        {
            loadRoom = true;
            Stats.canMove = false;
        }
    }

    void Update()
    {
        IsPlayerInBounds();

        if (loadRoom)
        {
            fadeTime -= Time.deltaTime;
            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            blackScreen.GetComponent<Image>().color = Color.Lerp(blackScreen.GetComponent<Image>().color, Color.black, Time.deltaTime * 4);

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
        #endif
    }
}
