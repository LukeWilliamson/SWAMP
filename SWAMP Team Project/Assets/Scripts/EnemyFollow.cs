using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public bool isTouched = false;
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBTWshots;
    public float startTimeBTWshots;

    public GameObject projectile;
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        timeBTWshots = startTimeBTWshots;
    }

    private void Update()
    {
        
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }else if (Vector2.Distance(transform.position, target.position) < stoppingDistance && (Vector2.Distance(transform.position, target.position) > stoppingDistance))
        {
            transform.position = this.transform.position;
        }else if (Vector2.Distance(transform.position, target.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, -speed * Time.deltaTime);
        }


        if (timeBTWshots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBTWshots = startTimeBTWshots; 
        }
        else
        {
            timeBTWshots -= Time.deltaTime;
        }
    }
 
}
