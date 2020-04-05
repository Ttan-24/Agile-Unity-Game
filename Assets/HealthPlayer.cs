using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlayer : MonoBehaviour
{
    public int Health;
    GameObject Player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Damage(int ammount)
    {
        Health -= ammount;
        if (Health <= 0)
        {
            Player.GetComponent<LoseGameOver>().GameOver();
        }
    }
}
