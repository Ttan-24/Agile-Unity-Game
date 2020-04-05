using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public int timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Timer: " + timer;
        if (Time.frameCount % 60 == 0)
        {
            timer--;
        }
        if (timer <= 0)
        {
            //SceneManager.LoadScene("WinScreen");
        }
    }
}
