using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public int timer = 0;
    public float interval = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Timer: " + timer / 60 + "m " + timer % 60 + "s";
        if (interval < 0)
        {
            timer++;
            interval = 1.0f;
        }
        else
        {
            interval -= Time.deltaTime;
        }
    }
}
