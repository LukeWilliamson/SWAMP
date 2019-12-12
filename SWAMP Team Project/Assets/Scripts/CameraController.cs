using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    float lookHeight = 2;
    float lHeight;
    CameraBoundaries roomBounds;

    float height;
    float width;

    float minX;
    float minY;
    float maxX;
    float maxY;

    float xPos;
    float yPos;

    PlayerController player;
    CameraBoundaries[] bounds;
    bool noBounds;

    void Start()
    {
        bounds = FindObjectsOfType<CameraBoundaries>();
        player = FindObjectOfType<PlayerController>();

        if(bounds.Length <= 0)
        {
            noBounds = true;
        }

        height = Camera.main.orthographicSize;
        width = height * Camera.main.aspect;
    }

    void FixedUpdate()
    {
        if (!noBounds)
        {
            IsPlayerInBounds();
            AreBoundsBlocked();
        }

        GetInput();
    }

    void IsPlayerInBounds()
    {
        for (int i = 0; i < bounds.Length; i++)
        {
            if (bounds[i].transform.position.x + (bounds[i].size.x / 2) > player.transform.position.x &&
                bounds[i].transform.position.x - (bounds[i].size.x / 2) < player.transform.position.x &&
                bounds[i].transform.position.y + (bounds[i].size.y / 2) > player.transform.position.y &&
                bounds[i].transform.position.y - (bounds[i].size.y / 2) < player.transform.position.y)
            {
                if (bounds[i] != roomBounds)
                {
                    roomBounds = bounds[i];

                    minX = bounds[i].transform.position.x - (bounds[i].size.x / 2) + width;
                    minY = bounds[i].transform.position.y - (bounds[i].size.y / 2) + height;
                    maxX = bounds[i].transform.position.x + (bounds[i].size.x / 2) - width;
                    maxY = bounds[i].transform.position.y + (bounds[i].size.y / 2) - height;
                }
            }
        }
    }

    void AreBoundsBlocked()
    {
        if (!roomBounds.lockX)
        {
            xPos = Mathf.Clamp(player.gameObject.transform.position.x, minX, maxX);
        }
        else
        {
            xPos = roomBounds.pos.x;
        }

        if (!roomBounds.lockY)
        {
            yPos = Mathf.Clamp(player.gameObject.transform.position.y, minY, maxY);
        }
        else
        {
            yPos = roomBounds.pos.y;
        }

        if (!roomBounds.blockX)
        {
            xPos = player.transform.position.x;
        }

        if (!roomBounds.blockY)
        {
            yPos = player.transform.position.y;
        }
    }

    void GetInput()
    {
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            transform.position = Vector2.Lerp(transform.position, new Vector2(xPos, yPos), Time.deltaTime * roomBounds.moveSpeed);
            transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        else
        {
            if (roomBounds.canLook && player.grounded)
            {
                if (Mathf.Abs(transform.position.y - player.transform.position.y) + lookHeight > 4.5f)
                {
                    lHeight = 4.5f - Mathf.Abs(transform.position.y - player.transform.position.y);
                }
                else
                {
                    lHeight = lookHeight;
                }

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    transform.position = Vector2.Lerp(transform.position, new Vector2(xPos, yPos + lHeight), Time.deltaTime * roomBounds.moveSpeed);
                    transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                }
                else if (Input.GetKey(KeyCode.DownArrow))
                {
                    transform.position = Vector2.Lerp(transform.position, new Vector2(xPos, yPos - lookHeight), Time.deltaTime * roomBounds.moveSpeed);
                    transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                }
                else
                {
                    transform.position = Vector2.Lerp(transform.position, new Vector2(xPos, yPos), Time.deltaTime * roomBounds.moveSpeed);
                    transform.position = new Vector3(transform.position.x, transform.position.y, -10);
                }
            }
            else
            {
                transform.position = Vector2.Lerp(transform.position, new Vector2(xPos, yPos), Time.deltaTime * roomBounds.moveSpeed);
                transform.position = new Vector3(transform.position.x, transform.position.y, -10);
            }
        }
    }
}