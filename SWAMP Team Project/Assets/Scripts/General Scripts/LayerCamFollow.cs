using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerCamFollow : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.position = FindObjectOfType<CameraController>().transform.position;
    }
}
