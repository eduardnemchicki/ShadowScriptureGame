using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// [AI OVERVIEW] Main menu / pause UI controller: toggles TMP_Text and Credits groups by MenuNames, plays itemSelectSound, loads levels via SceneManager from SceneAsset. static currentOpenMenu read by OpenMainMenuScript; driven by MenuButtonClick.
public class MenuManager : MonoBehaviour
{
    [SerializeField] private List<TMP_Text> LevelSelectElements = new List<TMP_Text>();
    [SerializeField] private TMP_Text GoBackButton;
    [SerializeField] private TMP_Text GoBackToOptionsButton;
    [SerializeField] private TMP_Text CurrentPageNameText;
    [SerializeField] private List<TMP_Text> MainMenuElements = new List<TMP_Text>();
    [SerializeField] private List<TMP_Text> OptionsMenuElements = new List<TMP_Text>();
    [SerializeField] private List<TMP_Text> Options_SoundMenuElements = new List<TMP_Text>();
    [SerializeField] private List<TMP_Text> Options_ControlsMenuElements = new List<TMP_Text>();
    [SerializeField] private GameObject CreditsTextElement;

    [SerializeField] private AudioClip itemSelectSound;
    [SerializeField] private AudioSource audioSource;

    public static MenuNames currentOpenMenu { get; private set; }
    public static MenuNames subMenuLastOpened { get; private set; }
    public void GoToSubmenu(MenuNames goToName)
    {
        audioSource.clip = itemSelectSound;
        audioSource.Play();

        bool credits = false;
        bool mainMenu = false;
        bool levelSelect = false;
        bool backToMenuButton = false;
        bool backToOptionsButton = false;
        bool options = false;
        bool options_Sound = false;
        bool options_Controls = false;

        switch (goToName)
        {
            case MenuNames.MainMenu:

                CurrentPageNameText.text = "Main Menu";
                mainMenu = true;

                break;

            case MenuNames.Credits:
                CurrentPageNameText.text = "Credits";
                backToMenuButton = true;
                credits = true;
                break;

            case MenuNames.LevelSelect:
                CurrentPageNameText.text = "Level Select";
                backToMenuButton = true;
                levelSelect = true;
                break;

            case MenuNames.Options:
                CurrentPageNameText.text = "Options";
                backToMenuButton = true;
                options = true;
                break;

            case MenuNames.Exit:
                ExitGame();
                break;

            case MenuNames.Options_Sound:
                CurrentPageNameText.text = "Sound";
                backToOptionsButton = true;
                options_Sound = true;
                break;

            case MenuNames.Options_Controls:
                CurrentPageNameText.text = "Controls";
                backToOptionsButton = true;
                options_Controls = true;
                break;

            default:
                CurrentPageNameText.text = "Main Menu";
                mainMenu = true;
                break;
        }

        foreach (var levelElement in LevelSelectElements)
        {
            levelElement.gameObject.SetActive(levelSelect);
        }
        foreach (var menuElement in MainMenuElements)
        {
            menuElement.gameObject.SetActive(mainMenu);
        }
        foreach (var optionsElement in OptionsMenuElements)
        {
            optionsElement.gameObject.SetActive(options);
        }
        foreach (var options_SoundElement in Options_SoundMenuElements)
        {
            options_SoundElement.gameObject.SetActive(options_Sound);
        }
        foreach (var options_ControlsElement in Options_ControlsMenuElements)
        {
            options_ControlsElement.gameObject.SetActive(options_Controls);
        }
        GoBackButton.gameObject.SetActive(backToMenuButton);
        GoBackToOptionsButton.gameObject.SetActive(backToOptionsButton);
        CreditsTextElement.gameObject.SetActive(credits);

        currentOpenMenu = goToName;
    }



    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting"); // This line is for testing in the editor, as Application.Quit() won't work in the editor
    }
    public void LoadLevel(string levelSceneName)
    {
        audioSource.clip = itemSelectSound;
        audioSource.Play();
        SceneManager.LoadScene(levelSceneName, LoadSceneMode.Single);
    }
}
