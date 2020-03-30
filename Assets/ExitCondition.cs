using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitCondition : MonoBehaviour
{
    public Camera camera;
    bool ePressed;
    int keysNeeded;
    int currentKeys;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //when looking at the door and pressing space(placeholder) activates winGameover script
        ePressed = Input.GetKeyDown("space");
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (ePressed)
        {
            if (Physics.Raycast(ray, out hit))
            {
                Transform Enemy = hit.transform;

                Enemy.gameObject.GetComponent<WinGameOver>().GameOver();
            }
        }
    }
}
