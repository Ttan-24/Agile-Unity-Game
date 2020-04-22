using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Numerics;
using System.Runtime.InteropServices;
using System.IO;
using TMPro;
using System.Reflection;
using UnityEngine.UIElements;

public class MenuController : MonoBehaviour
{
    #region Default Values
    [Header("Default Menu Values")]
    [SerializeField] private float defaultBrightness;
    [SerializeField] private float defaultVolume;
    [SerializeField] private int defaultSen;
    [SerializeField] private bool defaultInvertY;
    [SerializeField] private int menuNumber;

    [Header("Scenes To Load")]
    public string maze;
    //private string levelToLoad;

    #endregion

    #region Menu Dialogs
    [Header("Main Menu Components")]
    [SerializeField] private GameObject menuDefaultCanvas;
    [SerializeField] private GameObject GeneralSettingsCanvas;
    [SerializeField] private GameObject graphicsMenu;
    [SerializeField] private GameObject soundMenu;
    [SerializeField] private GameObject gameplayMenu;
    [SerializeField] private GameObject controlsMenu;
    [SerializeField] private GameObject confirmationMenu;
    [Space(10)]
    [Header("High Score Fields")]
    //[SerializeField] private GameObject noSaveDialog;
    [SerializeField] private GameObject newGameDialog;
    [SerializeField] private GameObject highScoreGameDialog; //loadGameDialog
    [Space(10)]
    [Header("Username Fields")]
    [SerializeField] private GameObject inputUsername;
    [SerializeField] private Text usernameWarning;
    [SerializeField] private string username;
    #endregion

    #region Slider Linking
    [Header("Menu Sliders")]
    [SerializeField] private Text controllerSenText;
    [SerializeField] private UnityEngine.UI.Slider controllerSenSlider;
    public float controlSenFloat = 2f;
    [Space(10)]
    [SerializeField] private Brightness brightnessEffect;
    [SerializeField] private UnityEngine.UI.Slider brightnessSlider;
    [SerializeField] private Text brightnessText;
    [Space(10)]
    [SerializeField] private Text volumeText;
    [SerializeField] private UnityEngine.UI.Slider volumeSlider;
    [Space(10)]
    [SerializeField] private UnityEngine.UI.Toggle invertYToggle;
    [Space(10)]
    [SerializeField] private Text selectText;
    [SerializeField] private UnityEngine.UI.Image mousePointerIcon;
    [SerializeField] private Text cancelText;
    [SerializeField] private UnityEngine.UI.Image escKeyIcon;
    #endregion

    #region High Score Entries
    [Header("High Score")]
    [SerializeField] private Transform entryContainer;
    [SerializeField] private Transform entryTemplate;
    private List<HighScoreEntry> highScoreEntryList;
    private List<Transform> highScoreEntryTransformList;
    #endregion

    #region Initialisation - Button Selection & Menu Order
    private void Start()
    {
        menuNumber = 1;
    }
    #endregion

    //MAIN SECTION
    #region Confrimation Box
    public IEnumerator ConfirmationBox()
    {
        confirmationMenu.SetActive(true);
        yield return new WaitForSeconds(1);
        confirmationMenu.SetActive(false);
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuNumber == 2 || menuNumber == 7 || menuNumber == 8) //2 - settings, 7 - new game; 8 - high score;
            {
                GoBackToMainMenu();
                ClickSound();
            }

            else if (menuNumber == 3 || menuNumber == 4 || menuNumber == 5) //3 = graphics menu; 4 - sound menu; 5 - gameplay menu
            {
                GoBackToOptionsMenu();
                ClickSound();
            }

            else if (menuNumber == 6) //6 - controls menu
            {
                GoBackToGameplayMenu();
                ClickSound();
            }
        }
    }

    private void ClickSound()
    {
        GetComponent<AudioSource>().Play();
    }

    #region Menu Mouse Clicks
    public void  MouseClick(string buttonType)
    {
        if (buttonType == "Controls")
        {
            gameplayMenu.SetActive(false);
            controlsMenu.SetActive(true);

            menuNumber = 6;
        }

        if (buttonType == "Graphics")
        {
            GeneralSettingsCanvas.SetActive(false);
            graphicsMenu.SetActive(true);
            selectText.gameObject.SetActive(false);
            mousePointerIcon.gameObject.SetActive(false);
            cancelText.gameObject.SetActive(false);
            escKeyIcon.gameObject.SetActive(false);
            menuNumber = 3;
        }

        if (buttonType == "Sound")
        {
            GeneralSettingsCanvas.SetActive(false);
            soundMenu.SetActive(true);
            selectText.gameObject.SetActive(false);
            mousePointerIcon.gameObject.SetActive(false);
            cancelText.gameObject.SetActive(false);
            escKeyIcon.gameObject.SetActive(false);
            menuNumber = 4;
        }

        if (buttonType == "Gameplay")
        {
            GeneralSettingsCanvas.SetActive(false);
            gameplayMenu.SetActive(true);
            selectText.gameObject.SetActive(false);
            mousePointerIcon.gameObject.SetActive(false);
            cancelText.gameObject.SetActive(false);
            escKeyIcon.gameObject.SetActive(false);
            menuNumber = 5;
        }

		if(buttonType == "Exit")
		{
			Debug.Log("YES QUIT!");
			Application.Quit();
		}
	
		if(buttonType == "Settings")
		{
            menuDefaultCanvas.SetActive(false);
            GeneralSettingsCanvas.SetActive(true);
            menuNumber = 2;
        }
	
		if(buttonType == "HighScore")
		{
            menuDefaultCanvas.SetActive(false);
            highScoreGameDialog.SetActive(true);
            selectText.gameObject.SetActive(false);
            mousePointerIcon.gameObject.SetActive(false);
            cancelText.gameObject.SetActive(false);
            escKeyIcon.gameObject.SetActive(false);
            menuNumber = 8;

            //Add players to leaderboard from the file
            entryTemplate.gameObject.SetActive(false);
            highScoreEntryList = new List<HighScoreEntry>(); //create high score list
            string path = System.IO.Path.GetFullPath(Directory.GetCurrentDirectory() + @"\leaderboard.txt"); //get path to txt file
            System.IO.StreamReader file = new System.IO.StreamReader(path); //read file
            string line; //current line in the file
            string[] nameAndScore; //get name and score separately
            int count = 0;
            while ((line = file.ReadLine()) != null && count < 7 ) //display max 7 entries
            {
                nameAndScore = line.Split(','); //separate name and score
                highScoreEntryList.Add(new HighScoreEntry { name = nameAndScore[0], score = System.Int32.Parse(nameAndScore[1]) });
                count++;
            }

            highScoreEntryTransformList = new List<Transform>();
            //create new high score entry based on the list read from file
            foreach(HighScoreEntry highScoreEntry in highScoreEntryList)
            {
                CreateHighScoreEntry(highScoreEntry, entryContainer, highScoreEntryTransformList);
            }
        }
        
        if (buttonType == "NewGame")
		{
            menuDefaultCanvas.SetActive(false);
            newGameDialog.SetActive(true);
            selectText.gameObject.SetActive(false);
            mousePointerIcon.gameObject.SetActive(false);
            cancelText.gameObject.SetActive(false);
            escKeyIcon.gameObject.SetActive(false);
            menuNumber = 7;
        }
    }
    #endregion

    #region High Score Create Entries
    private void CreateHighScoreEntry(HighScoreEntry highScoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 70.0f;
        
        Transform entryTransform = Instantiate(entryTemplate, container);
        entryTransform.tag = "clone";
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new UnityEngine.Vector2(0, -templateHeight * transformList.Count - 100);
        entryTransform.gameObject.SetActive(true);

        int currentPos = transformList.Count + 1;
        int score = highScoreEntry.score;
        string name = highScoreEntry.name;

        entryTransform.Find("posText").GetComponent<Text>().text = currentPos.ToString() + ".";
        entryTransform.Find("scoreText").GetComponent<Text>().text = score.ToString();
        entryTransform.Find("nameText").GetComponent<Text>().text = name;

        transformList.Add(entryTransform);
    }
    //Single entry in high score table
    private class HighScoreEntry
    {
        public string name;
        public int score;
    }
    #endregion

    #region Volume Sliders Click
    public void VolumeSlider(float volume)
    {
        AudioListener.volume = volume;
        volumeText.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        Debug.Log(PlayerPrefs.GetFloat("masterVolume"));
        StartCoroutine(ConfirmationBox());
    }
    #endregion

    #region Brightness Sliders Click
    public void BrightnessSlider(float brightness)
    {
        brightnessEffect.brightness = brightness;
        brightnessText.text = brightness.ToString("0.0");
    }

    public void BrightnessApply()
    {
        PlayerPrefs.SetFloat("masterBrightness", brightnessEffect.brightness);
        Debug.Log("Brightness" + " " + PlayerPrefs.GetFloat("masterBrightness"));
        StartCoroutine(ConfirmationBox());
    }
    #endregion

    #region Controller Sensitivity
    public void ControllerSen()
    {
        controllerSenText.text = controllerSenSlider.value.ToString("0");
        controlSenFloat = controllerSenSlider.value;
    }
    #endregion

    public void GameplayApply()
    {
        #region Invert
        if (invertYToggle.isOn) //Invert Y ON
        {
            PlayerPrefs.SetInt("masterInvertY", 1);
            Debug.Log("Invert" + " " + PlayerPrefs.GetInt("masterInvertY"));
        }

        else if (!invertYToggle.isOn) //Invert Y OFF
        {
            PlayerPrefs.SetInt("masterInvertY", 0);
            Debug.Log(PlayerPrefs.GetInt("masterInvertY"));
        }
        #endregion

        #region Controller Sensitivity
        PlayerPrefs.SetFloat("masterSen", controlSenFloat);
        Debug.Log("Sensitivity" + " " + PlayerPrefs.GetFloat("masterSen"));
        #endregion

        StartCoroutine(ConfirmationBox());
    }

    #region ResetButton
    public void ResetButton(string GraphicsMenu)
    {
        if (GraphicsMenu == "Brightness")
        {
            brightnessEffect.brightness = defaultBrightness;
            brightnessSlider.value = defaultBrightness;
            brightnessText.text = defaultBrightness.ToString("0.0");
            BrightnessApply();
        }

        if (GraphicsMenu == "Audio")
        {
            AudioListener.volume = defaultVolume;
            volumeSlider.value = defaultVolume;
            volumeText.text = defaultVolume.ToString("0.0");
            VolumeApply();
        }

        if (GraphicsMenu == "Graphics")
        {
            controllerSenText.text = defaultSen.ToString("0");
            controllerSenSlider.value = defaultSen;
            controlSenFloat = defaultSen;

            invertYToggle.isOn = false;

            GameplayApply();
        }
    }
    #endregion

    #region Dialog Options
    public void ClickNewGameDialog(string ButtonType)
    {
        if (ButtonType == "Confirm")
        {
            //username validation
            username = inputUsername.GetComponent<InputField>().text.ToString();
            if (username == "")
            {
                usernameWarning.GetComponent<Text>().text = "Username cannot be null";
                usernameWarning.GetComponent<Text>().color = Color.red;
                Debug.Log("Username cannot be null");
            }
            else if (username.Length > 10)
            {
                usernameWarning.GetComponent<Text>().text = "Username is too long (maximum 10 characters)";
                usernameWarning.GetComponent<Text>().color = Color.red;
                Debug.Log("Username is too long (maximum 10 characters)");
            }
            else if (username.ToLower().Contains("fuck") || username.ToLower().Contains("whore") || username.ToLower().Contains("dick") || 
                username.ToLower().Contains("shit") || username.ToLower().Contains("asshole") || username.ToLower().Contains("bitch") || username.ToLower().Contains("cunt") ||
                username.ToLower().Contains("nigga") || username.ToLower().Contains("nigger"))
            {
                usernameWarning.GetComponent<Text>().text = "Your username include forbidden world";
                usernameWarning.GetComponent<Text>().color = Color.red;
                Debug.Log("Your username include forbidden world.");
            }
            else if (username.Contains(","))
            {
                usernameWarning.GetComponent<Text>().text = "The username cannot contain comma";
                usernameWarning.GetComponent<Text>().color = Color.red;
                Debug.Log("The username cannot contain comma");
            }
            else
            {
                PlayerPrefs.SetString("username", username); //save username
                //load maze
                SceneManager.LoadScene(maze);
            }            
        }

        if (ButtonType == "Back")
        {
            inputUsername.GetComponent<InputField>().text = "";
            usernameWarning.GetComponent<Text>().text = "Username must be maximum 10 characters long.";
            usernameWarning.GetComponent<Text>().color = new Color32(125,125,125,255);

            GoBackToMainMenu();
        }
    }

    public void ClickHighScoreDialog(string ButtonType)
    {
        if (ButtonType == "No")
        {
            var clones = GameObject.FindGameObjectsWithTag("clone");
            foreach (var clone in clones) //delete clones
            {
                Destroy(clone);
            }

            GoBackToMainMenu();
        }
    }
    #endregion

    #region Back to Menus
    public void GoBackToOptionsMenu()
    {
        GeneralSettingsCanvas.SetActive(true);
        graphicsMenu.SetActive(false);
        soundMenu.SetActive(false);
        gameplayMenu.SetActive(false);
        selectText.gameObject.SetActive(true);
        mousePointerIcon.gameObject.SetActive(true);
        cancelText.gameObject.SetActive(true);
        escKeyIcon.gameObject.SetActive(true);

        GameplayApply();
        BrightnessApply();
        VolumeApply();

        menuNumber = 2;
    }

    public void GoBackToMainMenu()
    {
        menuDefaultCanvas.SetActive(true);
        selectText.gameObject.SetActive(true);
        mousePointerIcon.gameObject.SetActive(true);
        cancelText.gameObject.SetActive(true);
        escKeyIcon.gameObject.SetActive(true);
        newGameDialog.SetActive(false);
        highScoreGameDialog.SetActive(false);
        GeneralSettingsCanvas.SetActive(false);
        graphicsMenu.SetActive(false);
        soundMenu.SetActive(false);
        gameplayMenu.SetActive(false);
        menuNumber = 1;
    }

    public void GoBackToGameplayMenu()
    {
        controlsMenu.SetActive(false);
        gameplayMenu.SetActive(true);
        menuNumber = 5;
    }

    public void ClickQuitOptions()
    {
        GoBackToMainMenu();
    }

    public void ClickNoSaveDialog()
    {
        GoBackToMainMenu();
    }
    #endregion
}
