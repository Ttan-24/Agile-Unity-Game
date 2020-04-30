using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody m_rigidbody;
    public float moveSpeed;
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            m_rigidbody.velocity += transform.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            m_rigidbody.velocity -= transform.right * moveSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_rigidbody.velocity += transform.forward * moveSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            m_rigidbody.velocity -= transform.forward * moveSpeed;
        }
        float mouseX = Input.GetAxis("Mouse X");
        transform.Rotate(0, mouseX * rotationSpeed, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_rigidbody.AddForce(new Vector3(0, 1000.0f, 0));
        }

        m_rigidbody.velocity *= 0.92f;
    }
}
