using Tobii.XR;
using UnityEngine;

public class TobiiStarter : MonoBehaviour
{
    void Awake()
    {
        var settings = new TobiiXR_Settings();
        TobiiXR.Start(settings);
    }
}