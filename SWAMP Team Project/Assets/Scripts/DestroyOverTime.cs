using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{
    public float waitTime;

    void Start()
    {
        StartCoroutine(DestroyTimer());
    }

    IEnumerator DestroyTimer ()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(this.gameObject);
    }
}
