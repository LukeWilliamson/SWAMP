using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    LineRenderer lineRend;
    List<Vector2> segments = new List<Vector2>();
    float segmentLength = 0.25f;

    public int length = 10;
    public float width = 0.1f;
    public float gravity = 1;

    PlayerController player;
    bool wait;

    void Start()
    {
        lineRend = GetComponent<LineRenderer>();
        player = FindObjectOfType<PlayerController>();

        for(int i = 0; i < length; i++)
        {
            segments.Add(transform.position - (Vector3.up * segmentLength * i));
        }
    }

    void Update()
    {
        UpdateRope();
        DrawRope();
    }

    void UpdateRope()
    {
        for (int i = 1; i < length; i++)
        {
            segments[i] += Vector2.down * gravity * Time.deltaTime;

            float diff = Vector2.Distance(segments[i - 1], segments[i]);

            if (diff > segmentLength)
            {
                Vector2 dir = (segments[i - 1] - segments[i]).normalized;
                dir *= (diff - segmentLength);
                segments[i] += dir;
            }
            
            if(player.transform.position.x + 0.2f > transform.position.x && player.transform.position.x - 0.2f < transform.position.x && player.transform.position.y < transform.position.y && player.transform.position.y > transform.position.y - segmentLength * length && !wait)
            {
                StartCoroutine(MoveRope());
            }
        }

        segments[0] = transform.position;
    }

    IEnumerator MoveRope()
    {
        wait = true;
        transform.position -= Vector3.left;
        yield return new WaitForEndOfFrame();
        transform.position += Vector3.left;
        yield return new WaitForSeconds(0.2f);
        wait = false;
    }

    void DrawRope()
    {
        lineRend.startWidth = width;
        lineRend.endWidth = width;

        Vector3[] segmentPos = new Vector3[length];

        for (int i = 0; i < length; i++)
        {
            segmentPos[i] = segments[i];
        }

        lineRend.positionCount = length;
        lineRend.SetPositions(segmentPos);
    }

    /*

    void RopePhysics()
    {
        RopeSegment seg = segments[0];
        seg.newPos = transform.position;
        segments[0] = seg;

        for (int i = 0; i < length - 1; i++)
        {
            RopeSegment thisSeg = segments[i];
            RopeSegment nextSeg = segments[i + 1];

            float dist = Vector2.Distance(thisSeg.newPos, nextSeg.newPos);
            float error = Mathf.Abs(dist - segmentLength);
            Vector3 diff = Vector3.zero;

            if (dist > segmentLength)
            {
                diff = (thisSeg.newPos - nextSeg.newPos).normalized;
            }
            else if (dist < segmentLength)
            {
                diff = (nextSeg.newPos - thisSeg.newPos).normalized;
            }

            Vector2 changeAmmount = diff * error;

            if (i != 0)
            {
                thisSeg.newPos -= changeAmmount * error;
                segments[i] = thisSeg;

                nextSeg.newPos += changeAmmount * 0.5f;
                segments[i + 1] = nextSeg;
            }
            else
            {
                nextSeg.newPos += changeAmmount * 0.5f;
                segments[i + 1] = nextSeg;
            }
        }
    }*/

    private void OnDrawGizmosSelected()
    {
        for (int i = 0; i < length; i++)
        {
            #if UNITY_EDITOR
            if (UnityEditor.EditorApplication.isPlaying)
            {
                Gizmos.color = new Color(1, 0.5f, 0);
                Gizmos.DrawWireSphere(segments[i], width);
            }
            #endif
        }
    }
}
