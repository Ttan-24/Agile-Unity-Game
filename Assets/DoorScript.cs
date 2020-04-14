using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject KeyCountText;
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
