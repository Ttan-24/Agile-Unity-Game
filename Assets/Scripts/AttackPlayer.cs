using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AttackPlayer : MonoBehaviour
{
    public GameObject player;
    public float range;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(this.transform.position, player.transform.position);
        if (dist <= range)
        {
            //Game Over for player


            SceneManager.LoadScene("LoseScene");
            //tests distance
            //throw new System.Exception(dist.ToString());
        }
    }
}
