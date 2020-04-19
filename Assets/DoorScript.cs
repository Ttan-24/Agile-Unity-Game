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

        if (KeyCountText.gameObject.GetComponent<KeyCountScript>().KeyCount > 0)
        {
            if (gameExit)
            {
                //PlaceHolderForWin
                string path = Application.dataPath + "/leaderboard.txt";
                string text = 
                    timer.gameObject.GetComponent<Text>().text +
                    ": "+ 
                    username.gameObject.GetComponent<Text>().text;

                File.WriteAllText(path, text);
                SceneManager.LoadScene("WinScene");
            }
            else
            {
                KeyCountText.gameObject.GetComponent<KeyCountScript>().KeyCount--;
                Destroy(gameObject);
            }
        }



    }
}
