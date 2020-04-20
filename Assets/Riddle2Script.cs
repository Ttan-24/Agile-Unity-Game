using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityScript.Steps;
using System;

public class Riddle2Script : MonoBehaviour
{
    #region Answers
    [Header("Questions & Answer")]
    [SerializeField] private GameObject answerInput;
    [SerializeField] private Text QuestionText;
    [Space(10)]
    #endregion
    
    #region Dialogs & Controls & Scenes to Load
    [Space(10)]
    [Header("Riddle Dialog")]
    [SerializeField] private GameObject riddle2Dialog;
    [SerializeField] private Button submitBtn;
    [Space(10)]
    [Header("Confirmation Dialog")]
    [SerializeField] private GameObject riddle2ConfirmationDialog;
    [SerializeField] private Text topText;
    [SerializeField] private Button backBtn;
    [SerializeField] private Button okBtn;
    [Space(10)]
    [Header("Scenes To Load")]
    public string scene;
    #endregion

    #region Private Variables
    private string correctAnswer;
    private string answer;

    int timer;
    int keyCount;

    [SerializeField] private Text timerText;
    [SerializeField] private Text keyCountText;
    #endregion

    #region Start Function
    void Start()
    {
        timer = PlayerPrefs.GetInt("timer"); //get timer
        keyCount = KeyCountScript.KeyCount; //get key count

        Debug.Log("has stasted");
        string[,] riddleOptions = new string[10, 2] { 
            { "What is full of holes but still holds water?", "sponge" }, 
            { "What becomes wetter the more it dries?", "towel"},
            { "What is always in front of you but can’t be seen?", "future"},
            { "Where can you find cities, towns, shops, and streets but no people?", "map"},
            { "What has a neck but no head?", "bottle"},
            { "What word is spelled wrong in the dictionary?" , "wrong"},
            { "Mr. Blue lives in the Blue house. Mrs. Yellow lives in the Yellow House. Mr. Orange lives in the orange house. Who lives in the White House?", "president"},
            { "What has to be broken before you can use it?" , "egg"},
            { "What goes up but never comes back down?", "age"},
            { "What can you catch but not throw?", "cold"} };
        //random choice
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(0, 9); //indexes in the array

        //generate question
        QuestionText.text = riddleOptions[randomNumber, 0];
        //get correct answer
        correctAnswer = riddleOptions[randomNumber, 1];

        //add on click listeners for each button (answer)
        submitBtn.onClick.AddListener(() => TaskOnClick("submit"));
        okBtn.onClick.AddListener(() => TaskOnClick("ok"));
        backBtn.onClick.AddListener(() => TaskOnClick("back"));

        //display time && key count
        timerText.GetComponent<Text>().text = "Timer: " + timer;
        keyCountText.GetComponent<Text>().text = "Key Count: " + keyCount;
    }
    #endregion
    void TaskOnClick(string buttonType)
    {
        if (buttonType == "submit")
        {
            answer = answerInput.GetComponent<InputField>().text.ToString();
            if (answer.ToLower().Contains(correctAnswer))
            {
                Debug.Log("subsubsub: " + buttonType);
                //time -10sec (bonus)
                PlayerPrefs.SetInt("subtract10sec", 1); //set to true
                timerText.GetComponent<Text>().color = Color.green;

                //increse number of keys
                KeyCountScript.KeyCount++;

                riddle2Dialog.SetActive(false);
                topText.text = "Correct Answer!";
                topText.GetComponent<Text>().color = Color.green;
                riddle2ConfirmationDialog.SetActive(true);
            }
            else
            {
                riddle2Dialog.SetActive(false);
                topText.text = "Incorrect Answer!";
                topText.GetComponent<Text>().color = Color.red;
                riddle2ConfirmationDialog.SetActive(true);
            }
        }
        else if (buttonType == "ok")
        {
            timerText.GetComponent<Text>().color = Color.white;

            if (topText.text.ToLower().Contains("incorrect"))
            {   //come back to the riddle
                riddle2ConfirmationDialog.SetActive(false);
                riddle2Dialog.SetActive(true);
            }
            else
            {
                //come back to the previous scene (maze)
                Screen.lockCursor = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
            }
        }
        else //button type == back
        {
            //come back to the previous screen
            Screen.lockCursor = false;
            UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
        }
    }
}
