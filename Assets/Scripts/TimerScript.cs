using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    public static int timer = 0;
    public float interval = 1.0f;
    public int add10sec = 0; //0 = false; 1 = true, anything else = false
    public int subtract10sec = 0; //0 = false; 1 = true, anything else = false

    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("add10sec", 0); //false at the beggining
        PlayerPrefs.SetInt("subtract10sec", 0); //false at the beggining
        timer = PlayerPrefs.GetInt("startTimer");
    }

    // Update is called once per frame
    void Update()
    {
        add10sec = PlayerPrefs.GetInt("add10sec");
        subtract10sec = PlayerPrefs.GetInt("subtract10sec");
        gameObject.GetComponent<Text>().text = "Timer: " + timer / 60 + "m " + timer % 60 + "s";

        //bonus time from riddles (-/+ 10 seconds)
        if (add10sec == 1)
        {
            timer += 10; //add 10 seconds
            PlayerPrefs.SetInt("add10sec", 0); //change to false
        }
        if (subtract10sec == 1)
        {
            timer -= 10; //subtract 10 seconds
            PlayerPrefs.SetInt("subtract10sec", 0); //change to false
        }


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
