using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LookingScript : MonoBehaviour
{
    public Camera camera;
    bool mouseClicked;

    [Header("Scenes To Load")]
    public string riddle1;
    public string riddle2;

    private static int timer; //use timer from another script
    private static int keyCount; //use keyCount from another script

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mouseClicked = Input.GetMouseButtonDown(0);
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            Transform hitObject = hit.transform;

            EnemyPatrolScript enemy = hitObject.GetComponent<EnemyPatrolScript>();

            if (enemy != null)

            {
                Debug.Log("reeee");
                enemy.LookedAt();
            }
        }

        if (mouseClicked == true)
        {
            if (Physics.Raycast(ray, out hit))
            {
                Transform hitObject = hit.transform;

                DoorScript doorScript = hitObject.GetComponent<DoorScript>();
                KeyScript keyScript = hitObject.GetComponent<KeyScript>();
                HealthEnemy healthScript = hitObject.GetComponent<HealthEnemy>();
                Riddle1Script riddle1Script = hitObject.GetComponent<Riddle1Script>();
                Riddle2Script riddle2Script = hitObject.GetComponent<Riddle2Script>();

                float distance = hit.distance;
                Debug.Log("Distance from " + hitObject.gameObject.name + ": " + distance);
                if (distance <= 10)
                {
                    if (doorScript != null)
                    {
                        doorScript.Open();
                    }
                    if (keyScript != null)
                    {
                        keyScript.AddKey();
                    }
                    if (healthScript != null)
                    {
                        healthScript.health_of_enemy--;
                    }
                    if (riddle1Script != null)
                    {
                        //open scene
                        //riddleScript.OpenScene();
                        Debug.Log("opened");
                        //Cursor.visible = false;
                        Screen.lockCursor = false;
                        timer = TimerScript.timer;
                        PlayerPrefs.SetInt("timer", timer); //save time and "send" to riddle script
                        keyCount = KeyCountScript.KeyCount;
                        PlayerPrefs.SetInt("timer", timer); //save time and "send" to riddle script
                        SceneManager.LoadScene(riddle1);
                    }
                    if (riddle2Script != null)
                    {
                        //open scene
                        //riddleScript.OpenScene();
                        Debug.Log("opened riddle 2");
                        //Cursor.visible = false;
                        Screen.lockCursor = false;
                        timer = TimerScript.timer;
                        PlayerPrefs.SetInt("timer", timer); //save time and "send" to riddle script
                        keyCount = KeyCountScript.KeyCount;
                        PlayerPrefs.SetInt("timer", timer); //save time and "send" to riddle script
                        SceneManager.LoadScene(riddle2);
                    }
                }

                //Destroy(Enemy.gameObject);
                //Enemy.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
                // Do something with the object that was hit by the raycast.
            }


        }
    }
}
