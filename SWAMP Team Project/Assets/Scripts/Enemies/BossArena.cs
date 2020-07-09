using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossArena : MonoBehaviour
{
    public EnemyManager boss;
    public GameObject[] doors;
    public Vector3[] closedPos;
    public AudioClip beatBossMusic;
    AudioClip areaMusic;
    Vector3[] openPos = new Vector3[5];

    bool closeDoors = false;
    bool started = false;

    void Start()
    {
        if(boss.GetComponent<SwordRatBoss>() && Stats.beatRatBoss)
        {
            Destroy(this.gameObject);
        }

        for(int i = 0; i < doors.Length; i++)
        {
            openPos[i] = doors[i].transform.localPosition;
        }
    }

    private void Update()
    {
        if(closeDoors)
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].transform.localPosition = Vector3.MoveTowards(doors[i].transform.localPosition, closedPos[i], Time.deltaTime * 10);
            }
        }
        else
        {
            for (int i = 0; i < doors.Length; i++)
            {
                doors[i].transform.localPosition = Vector3.MoveTowards(doors[i].transform.localPosition, openPos[i], Time.deltaTime * 10);
            }
        }
    }

    public void OpenDoors()
    {

        StartCoroutine(BeatBossMusic());
        closeDoors = false;
    }

    IEnumerator BeatBossMusic()
    {
        FindObjectOfType<AudioManager>().GetComponent<AudioSource>().Stop();
        FindObjectOfType<AudioManager>().GetComponent<AudioSource>().clip = beatBossMusic;
        FindObjectOfType<AudioManager>().GetComponent<AudioSource>().Play();

        yield return new WaitForSeconds(beatBossMusic.length);

        FindObjectOfType<AudioManager>().GetComponent<AudioSource>().clip = areaMusic;
        FindObjectOfType<AudioManager>().GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() && !started)
        {
            started = true;
            closeDoors = true;
            areaMusic = FindObjectOfType<AudioManager>().GetComponent<AudioSource>().clip;
            FindObjectOfType<AudioManager>().FadeOut();
            boss.Enter();
        }
    }
}
