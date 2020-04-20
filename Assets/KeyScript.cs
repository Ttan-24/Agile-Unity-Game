using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour
{
    public GameObject KeyCountText;
    // Start is called before the first frame update
    void Start()
    {
        KeyCountText = GameObject.Find("KeyCountText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddKey()
    {
        KeyCountScript.KeyCount++;
        Destroy(gameObject);
    }
}
