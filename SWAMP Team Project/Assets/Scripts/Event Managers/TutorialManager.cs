using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public Animator elevator;
    public Animator ratWithSword;
    public Vector2[] triggersSize;
    public Vector2[] triggersPos;
    public bool[] triggered;

    PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();

        if(Stats.tutorialState <= 0)
        {
            elevator.SetTrigger("Hang");
        }
    }

    // Update is called once per frame
    void Update()
    {
        IsPlayerInBounds();

        if(Stats.tutorialState == 1)
        {
            ratWithSword.SetTrigger("Take Sword");
            Stats.tutorialState += 1;
            Stats.canMove = false;
            StartCoroutine(Timer(6.12f));
        }

        if (Stats.tutorialState == 3)
        {
            elevator.SetTrigger("Fall");
            Stats.canMove = true;
        }

        if (Stats.tutorialState == 4)
        {
            ratWithSword.SetTrigger("Enter Vent");
            Stats.tutorialState += 1;
        }

        if (Stats.tutorialState == 6)
        {
            ratWithSword.SetTrigger("Rat On Roof");
            Stats.tutorialState += 1;
        }
    }

    IEnumerator Timer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Stats.tutorialState += 1;
    }

    void IsPlayerInBounds()
    {
        for (int i = 0; i < triggersSize.Length; i++)
        {
            if (triggersPos[i].x + (triggersSize[i].x / 2) > player.transform.position.x &&
                triggersPos[i].x - (triggersSize[i].x / 2) < player.transform.position.x &&
                triggersPos[i].y + (triggersSize[i].y / 2) > player.transform.position.y &&
                triggersPos[i].y - (triggersSize[i].y / 2) < player.transform.position.y && !triggered[i])
            {
                Stats.tutorialState += 1;
                triggered[i] = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < triggersSize.Length; i++)
        {
            if (!triggered[i])
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawWireCube(triggersPos[i], triggersSize[i]);
            }
        }
    }
}
