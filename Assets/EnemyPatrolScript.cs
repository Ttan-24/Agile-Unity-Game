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

    public bool shouldBeLookedAtToMove;
    private bool lookedAt = false;

    public float distToWalkTowards;
    // Start is called before the first frame update

    private void Moving()
    {
        speed = 3.0f;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + 5, player.position.z), speed * Time.deltaTime);

    }
    public void LookedAt()
    {
        lookedAt = true;
    }
    private void MovingCondition()
    {
        if (lookedAt)
        {
            if (shouldBeLookedAtToMove)
            {
                //move
                Moving();
            }
            else
            {
                //don't move
            }

        }
        else
        {
            if (shouldBeLookedAtToMove)
            //regular actions
            {
                //don't move
            }
            else
            {
                Moving();
                //move
            }
        }
        lookedAt = false;

    }
    void Start()
    {
        randomSpot = Random.Range(0, moveSpots.Length - 1);
    }
        
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
                MovingCondition();
            }
        }
}
