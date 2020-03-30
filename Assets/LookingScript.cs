using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingScript : MonoBehaviour
{
    public Camera camera;
    bool mouseClicked;
    bool activatedPressed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        activatedPressed = Input.GetKeyDown("space");
        mouseClicked = Input.GetMouseButtonDown(0);
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (mouseClicked == true)
        {
            if (Physics.Raycast(ray, out hit))
            {
                Transform Enemy = hit.transform;

                Enemy.gameObject.GetComponent<HealthEnemy>().health_of_enemy--; 
                //Destroy(Enemy.gameObject);
                //Enemy.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                // Do something with the object that was hit by the raycast.
            }
        }
        if (activatedPressed == true)
        {
            if (Physics.Raycast(ray, out hit))
            {
                Transform Enemy = hit.transform;

                
                Enemy.gameObject.GetComponent<WinGameOver>().GameOver();
                Enemy.gameObject.GetComponent<HealthEnemy>().health_of_enemy--;
            }
        }
    }
}
