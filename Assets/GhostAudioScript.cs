using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostAudioScript : MonoBehaviour
{
    AudioSource audio;
    public float distanceToPlayer;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        audio = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vectorToPlayer = transform.position - player.transform.position;
        distanceToPlayer = vectorToPlayer.magnitude;
        audio.volume = 1.2f - (distanceToPlayer / 50);
    }
}
