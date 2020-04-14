using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolScript : MonoBehaviour
{
    public float speed = 5.0f;
    public Transform[] moveSpots;
    private int randomSpot;
    private float waitTime;
    public Transform player;
    public float startWaitTime = 1.0f;
    public string walkMode;

    // Start is called before the first frame update
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length - 1);
        waitTime = startWaitTime;
        player = GameObject.FindWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) < 20.0f)
        {
            walkMode = "attack";
        }
        else
        {
            walkMode = "patrol";
        }
        if (walkMode == "patrol")
        {
            speed = 5.0f;
            transform.position = Vector3.MoveTowards(transform.position, moveSpots[randomSpot].position, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length - 1);
                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else if (walkMode == "attack")
        {
            speed = 30.0f;
            if (Vector3.Distance(transform.position, player.position) > 5.0f)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
            }
        }
    }
}
