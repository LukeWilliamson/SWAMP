using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoundaries : MonoBehaviour
{
    public Vector2 size;
    public bool showBounds;

    [Header("Camera Locks")]
    public bool canLook = true;

    public bool lockX = false;
    public bool lockY = false;

    public bool blockX = true;
    public bool blockY = true;

    public Vector2 pos;
    public float moveSpeed = 8;

    void OnDrawGizmos()
    {
        if (showBounds)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(transform.position, size);
        }
    }
}