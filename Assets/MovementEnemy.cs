using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{

    public bool shouldBeLookedAtToMove;
    private bool lookedAt = false;

    private void Moving() 
    {
        Movement = Player.gameObject.transform.position - gameObject.transform.position;
        Movement = Movement.normalized * moveSpeed * Time.deltaTime;
        gameObject.transform.position += Movement;
    }

    // Update is called once per frame
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

    public GameObject Player;
    public float moveSpeed;
   
    Vector3 Movement = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovingCondition();
    }
}
