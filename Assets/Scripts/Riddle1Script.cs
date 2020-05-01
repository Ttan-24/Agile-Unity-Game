using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Riddle1Script : MonoBehaviour
{

    #region Elements
    [SerializeField] private GameObject mazeElements;
    [SerializeField] private GameObject riddle1Elements;
    [SerializeField] private GameObject riddle1Box;
    #endregion

    #region Answers
    [Header("Answer Buttons")]
    [SerializeField] private Button answer1Btn;
    [SerializeField] private Button answer2Btn;
    [SerializeField] private Button answer3Btn;
    [SerializeField] private Button answer4Btn;
    [SerializeField] private Button answer5Btn;
    [SerializeField] private Button answer6Btn;
    [Space(10)]
    [Header("Answer Button Texts (Numbers)")]
    [SerializeField] private Text answer1Text;
    [SerializeField] private Text answer2Text;
    [SerializeField] private Text answer3Text;
    [SerializeField] private Text answer4Text;
    [SerializeField] private Text answer5Text;
    [SerializeField] private Text answer6Text;
    [Space(10)]
    #endregion

    #region Question/Equation
    [Header("Question Texts (Numbers & Symbols)")]
    [SerializeField] private Text finalAnswer;
    [SerializeField] private Text num1Text;
    [SerializeField] private Text num2Text;
    [SerializeField] private Text num3Text;
    [SerializeField] private Text operator1; // + - / * - mathematical symbol
    [SerializeField] private Text operator2; // + - / * - mathematical symbol
    #endregion

    #region Dialogs & Controls & Scenes to Load
    [Space(10)]
    [Header("Riddle Dialog")]
    [SerializeField] private GameObject riddle1Dialog;
    [SerializeField] private Button submitBtn;
    [Space(10)]
    [Header("Confirmation Dialog")]
    [SerializeField] private GameObject riddle1ConfirmationDialog;
    [SerializeField] private Text topText;
    [SerializeField] private Button backBtn;
    [SerializeField] private Button okBtn;
    #endregion

    #region Private Variables
    private int correctAnswer;
    private string equation;
    private int chosenAnswer; //selected answer

    private string op1; //operator 1 (converted)
    private string op2; //operator 2 (converted)

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

        string[,] equationOptions = new string[5, 5] { { "30", "-", "20", "/", "2" }, { "3", "+", "5", "x", "4" }, { "4", "/", "2", "x", "2" }, { "5", "x", "-1", "+", "-10"}, {"16", "/", "4", "-", "2" } };
        string[,] equationAnswers = new string[5,6] { { "-20","-10", "0", "5","10","20"}, {"12", "18", "19", "23", "24", "32" }, { "0", "1", "2", "4", "6", "16"}, {"-55", "-15", "0", "5", "15", "55" }, {"-4", "-2", "1", "2", "4", "8" }  };
        //random choice
        System.Random rand = new System.Random();
        int randomNumber = rand.Next(0, 4); //indexes in the array

        //generate equation
        num1Text.text = equationOptions[randomNumber, 0];
        operator1.text = equationOptions[randomNumber, 1];
        num2Text.text = equationOptions[randomNumber, 2];
        operator2.text =  equationOptions[randomNumber, 3];
        num3Text.text = equationOptions[randomNumber, 4];

        //generate possible answers
        answer1Text.text = equationAnswers[randomNumber, 0];
        answer2Text.text = equationAnswers[randomNumber, 1];
        answer3Text.text = equationAnswers[randomNumber, 2];
        answer4Text.text = equationAnswers[randomNumber, 3];
        answer5Text.text = equationAnswers[randomNumber, 4];
        answer6Text.text = equationAnswers[randomNumber, 5];

        //change 'x' to multipy operator (otherwise equation won't work)
        op1 = operator1.text;
        op2 = operator2.text;
        if (operator1.text.ToLower() == "x") op1 = "*";
        if (operator2.text.ToLower() == "x") op2 = "*";

        //get equation result
        equation = num1Text.text + op1 + num2Text.text + op2 + num3Text.text;
        correctAnswer = Evaluate(equation);

        //add on click listeners for each button (answer)
        answer1Btn.onClick.AddListener(() => TaskOnClick("answer1"));
        answer2Btn.onClick.AddListener(() => TaskOnClick("answer2"));
        answer3Btn.onClick.AddListener(() => TaskOnClick("answer3"));
        answer4Btn.onClick.AddListener(() => TaskOnClick("answer4"));
        answer5Btn.onClick.AddListener(() => TaskOnClick("answer5"));
        answer6Btn.onClick.AddListener(() => TaskOnClick("answer6"));
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
        if (buttonType != "submit" && buttonType != "back" && buttonType != "ok")
        {
            if (buttonType == "answer1") chosenAnswer = int.Parse(answer1Text.text);
            else if (buttonType == "answer2") chosenAnswer = int.Parse(answer2Text.text);
            else if (buttonType == "answer3") chosenAnswer = int.Parse(answer3Text.text);
            else if (buttonType == "answer4") chosenAnswer = int.Parse(answer4Text.text);
            else if (buttonType == "answer5") chosenAnswer = int.Parse(answer5Text.text);
            else chosenAnswer = int.Parse(answer6Text.text);

            finalAnswer.text = chosenAnswer.ToString(); //result chosen
        }
       else if (buttonType == "submit")
        {
            if (chosenAnswer == correctAnswer)
            {
                //time -10sec (bonus)
                PlayerPrefs.SetInt("subtract10sec", 1); //set to true
                timerText.GetComponent<Text>().color = Color.green;

                //increse number of keys
                KeyCountScript.KeyCount++;

                riddle1Dialog.SetActive(false);
                topText.text = "Correct Answer!";
                topText.GetComponent<Text>().color = Color.green;
                riddle1ConfirmationDialog.SetActive(true);
            }
            else
            {
                //time +10 sec (don't click if you don't know the answer)
                PlayerPrefs.SetInt("add10sec", 1); //set to true
                timerText.GetComponent<Text>().color = Color.red;
               
                riddle1Dialog.SetActive(false);
                topText.text = "Incorrect Answer!";
                topText.GetComponent<Text>().color = Color.red;
                riddle1ConfirmationDialog.SetActive(true);
            }
        }
        else if (buttonType == "ok")
        {
            timerText.GetComponent<Text>().color = Color.white;

            if (topText.text.ToLower().Contains("incorrect"))
            {   //come back to the riddle
                riddle1ConfirmationDialog.SetActive(false);
                riddle1Dialog.SetActive(true);
            }
            else
            {
                //come back to the previous scene (maze)
                Screen.lockCursor = true;
                mazeElements.SetActive(true);
                riddle1Elements.SetActive(false);
                Destroy(riddle1Box);
            }
        }
        else //button type == back
        {
            //come back to the previous screen
            Screen.lockCursor = true;
            mazeElements.SetActive(true);
            riddle1Elements.SetActive(false);
        }
    }

    //Evaluate() function source: https://stackoverflow.com/questions/6052640/is-there-an-eval-function-in-c
    public static int Evaluate(string expression)
    {
        System.Data.DataTable table = new System.Data.DataTable();
        table.Columns.Add("expression", string.Empty.GetType(), expression);
        System.Data.DataRow row = table.NewRow();
        table.Rows.Add(row);
        return int.Parse((string)row["expression"]);
    }
}
