using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityScript.Steps;

public class Riddle1Script : MonoBehaviour
{

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
    [Header("Question Texts (Numbers & Symbols)")]
    [SerializeField] private Text finalAnswer;
    [SerializeField] private Text num1Text;
    [SerializeField] private Text num2Text;
    [SerializeField] private Text num3Text;
    [SerializeField] private Text operator1; // + - / * - mathematical symbol
    [SerializeField] private Text operator2; // + - / * - mathematical symbol
    [Space(10)]
    [Header("Control Buttons")]
    [SerializeField] private Button submitBtn;
    [SerializeField] private Button backBtn;

    [SerializeField] private GameObject riddle1Canvas;

    private int correctAnswer;
    private string equation;
    private int chosenAnswer; //selected answer

    #endregion
    void Start()
    {
        //change 'x' to multipy operator (otherwise equation won't work)
        if (operator1.text.ToLower() == "x") operator1.text = "*";
        if (operator2.text.ToLower() == "x") operator2.text = "*";

        //get equation result
        equation = num1Text.text + operator1.text + num2Text.text + operator2.text + num3Text.text;
        Debug.Log(equation);
        correctAnswer = Evaluate(equation);

        //add on click listeners for each button (answer)
        answer1Btn.onClick.AddListener(() => TaskOnClick("answer1"));
        answer2Btn.onClick.AddListener(() => TaskOnClick("answer2"));
        answer3Btn.onClick.AddListener(() => TaskOnClick("answer3"));
        answer4Btn.onClick.AddListener(() => TaskOnClick("answer4"));
        answer5Btn.onClick.AddListener(() => TaskOnClick("answer5"));
        answer6Btn.onClick.AddListener(() => TaskOnClick("answer6"));
        submitBtn.onClick.AddListener(() => TaskOnClick("submit"));
    }

    void TaskOnClick(string buttonType)
    {
        if (buttonType != "submit" && buttonType != "back")
        {
            
            if (buttonType == "answer1") chosenAnswer = int.Parse(answer1Text.text);
            else if (buttonType == "answer2") chosenAnswer = int.Parse(answer2Text.text);
            else if (buttonType == "answer3") chosenAnswer = int.Parse(answer3Text.text);
            else if (buttonType == "answer4") chosenAnswer = int.Parse(answer4Text.text);
            else if (buttonType == "answer5") chosenAnswer = int.Parse(answer5Text.text);
            else chosenAnswer = int.Parse(answer6Text.text);

            finalAnswer.text = chosenAnswer.ToString();
            Debug.Log("Chosen answer: " + chosenAnswer);

            //Output this to console when Button1 or Button3 is clicked
            Debug.Log("You have clicked the button! Type: " + buttonType + " Text: " + answer1Text.text + "Answer:" + correctAnswer);
        }
       else if (buttonType == "submit")
        {
            if (chosenAnswer == correctAnswer)
            {
                Debug.Log("Congrats. Good Answer.");
                riddle1Canvas.SetActive(false);
            }
            else
            {
                Debug.Log("Bad Luck");
            }
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
