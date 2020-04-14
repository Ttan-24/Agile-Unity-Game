using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingScript : MonoBehaviour
{
    public Camera camera;
    bool mouseClicked;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseClicked = Input.GetMouseButtonDown(0);
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (mouseClicked == true)
        {
            if (Physics.Raycast(ray, out hit))
            {
                Transform hitObject = hit.transform;

                DoorScript doorScript = hitObject.GetComponent<DoorScript>();
                KeyScript keyScript = hitObject.GetComponent<KeyScript>();
                HealthEnemy healthScript = hitObject.GetComponent<HealthEnemy>();

                if (doorScript != null)
                {
                    float distance = Vector3.Distance(gameObject.transform.position, hitObject.transform.position);
                    if (distance <= 10)
                    {
                        doorScript.Open();
                    }
                }
                if (keyScript != null)
                {
                    keyScript.AddKey();
                }
                if (healthScript != null)
                {
                    healthScript.health_of_enemy--;
                }

                //Destroy(Enemy.gameObject);
                //Enemy.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                // Do something with the object that was hit by the raycast.
            }
        }
    }
}
