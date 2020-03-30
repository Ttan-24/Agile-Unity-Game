using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        // show the end game screem
        //placeholder
        
    }

    public void GameOver() 
    {
        Application.Quit();
    }
}
