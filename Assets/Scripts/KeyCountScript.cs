using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCountScript : MonoBehaviour
{
    public static int KeyCount;
    // Start is called before the first frame update
    void Start()
    {
        KeyCount = PlayerPrefs.GetInt("startKeys");
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Text>().text = "Key Count: " + KeyCount;
    }
}
