using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject KeyCountText;
    public GameObject timer;
    public int gameTime;
    public GameObject username;
    public bool gameExit;
    void Start()
    {
        KeyCountText = GameObject.Find("KeyCountText");
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Open()
    {

        if (KeyCountScript.KeyCount > 0)
        {
            if (gameExit)
            {
               
                //PlaceHolderForWin
                string path = Application.dataPath + "/leaderboard.txt";
                string read = System.IO.File.ReadAllText(path);
                int start = 6;
                int end = 1;
                string origin = "";
                origin = System.IO.File.ReadAllText(path);
                int time = PlayerPrefs.GetInt("timer");
                int keyCount = KeyCountScript.KeyCount;
                int score = keyCount * 100 - time / 2;
                if (score < 1) score = 0;
                if (origin.Length > 1)
                {
                    //for (int i = 7; i < read.Length; i++)
                    //{
                    //    if (origin[i] == ':')
                    //    {
                    //        end = i;
                    //    }
                    //}



                    //origin = origin.Remove(end);
                    //origin = origin.Substring(start);
                    //Debug.Log(origin);
                    //Debug.Log(timer.gameObject.GetComponent<Text>().text.Substring(start));
                    //Debug.Log(timer.gameObject.GetComponent<Text>().text.Substring(start).CompareTo(origin));

                    gameTime = TimerScript.timer;
                    if (gameTime > 0)
                    //if (timer.gameObject.GetComponent<Text>().text.Substring(start).CompareTo(origin) > 0)
                    {
                        string ID = PlayerPrefs.GetString("username");
                        string text =
                        //username.gameObject.GetComponent<Text>().text +
                        ID +
                        "," +
                        //timer.gameObject.GetComponent<Text>().text;
                        score;
                        File.WriteAllText(path, text);

                    }
                }
                else
                {
                    string ID = PlayerPrefs.GetString("username");
                    string text =
                    //username.gameObject.GetComponent<Text>().text +
                    ID +
                    "," +
                    //timer.gameObject.GetComponent<Text>().text;
                    score;
                    File.WriteAllText(path, text);
                }
                
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                KeyCountScript.KeyCount--;
                Destroy(gameObject);
            }
        }



    }
}
