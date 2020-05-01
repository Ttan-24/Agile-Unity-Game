using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;

public class UsernameScript : MonoBehaviour
{
    [SerializeField] private Text usernameText;

    // Start is called before the first frame update
    void Start()
    {
        string userID = PlayerPrefs.GetString("username");
        usernameText.GetComponent<Text>().text = "Username: " + userID;
    }
}
