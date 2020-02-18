using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
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
        Movement = Player.gameObject.transform.position - gameObject.transform.position;
        Movement = Movement.normalized * moveSpeed * Time.deltaTime;
        gameObject.transform.position += Movement;
    }
}
