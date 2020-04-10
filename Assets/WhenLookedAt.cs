using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhenLookedAt : MonoBehaviour
{
    public bool shouldBeLookedAtToMove;
    private float updateTime = 2;
    private bool lookedAt = false;

    // Update is called once per frame
    public void LookedAt() 
    {
        if (lookedAt)
        {
            updateTime = 2;
        }
        else
        {
            lookedAt = true;
        }
        
    }
    private void MovingCondition() 
    {
        if (lookedAt)
        {
            if (shouldBeLookedAtToMove)
            {
                //move
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
                //move
            }
        }
        if (updateTime < 0)
        {
            lookedAt = false;
        }
            
            

    }
    void Update()
    {
        MovingCondition();
        updateTime -= Time.deltaTime;
    }
}
