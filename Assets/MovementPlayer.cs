using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
     private Rigidbody m_rigidbody;
    public float PlayerSpeed;
    // Start is called before the first frame update
    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_rigidbody.velocity += new Vector3(0, 0, PlayerSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_rigidbody.velocity -= new Vector3(0, 0, PlayerSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_rigidbody.velocity -= new Vector3(PlayerSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_rigidbody.velocity += new Vector3(PlayerSpeed, 0, 0);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            m_rigidbody.AddForce(new Vector3(0, 50.0f, 0));
        }
    }
}
