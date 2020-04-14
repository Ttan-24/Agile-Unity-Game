using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    public GameObject Player;
    public float moveSpeed;
    public bool shouldBeLookedAtToMove;
    private bool lookedAt = false;

    Vector3 Movement = new Vector3();

    private void Moving()
    {
        Movement = Player.gameObject.transform.position - gameObject.transform.position;
        Movement = Movement.normalized * moveSpeed * Time.deltaTime;
        gameObject.transform.position += Movement;
    }
    public void LookedAt()
    {
        lookedAt = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        
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
    // Update is called once per frame


    void FixedUpdate()
    {
        MovingCondition();
    }
}
