using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerKeys : MonoBehaviour
{
    int currentKeys = 0;
    // Start is called before the first frame update
    void Start()
    {
        incrementKeys();
    }

    private void incrementKeys()
    {
        currentKeys++;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
