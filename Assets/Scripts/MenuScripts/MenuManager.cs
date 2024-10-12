using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] List<TMP_Text> LevelSelectElements = new List<TMP_Text>();
    [SerializeField] TMP_Text GoBackButton;
    [SerializeField] TMP_Text CurrentPageNameText;
    [SerializeField] List<TMP_Text> MainMenuElements = new List<TMP_Text>();
    [SerializeField] List<TMP_Text> OptionsMenuElements = new List<TMP_Text>();
    [SerializeField] TMP_Text CreditsTextElement;

    [SerializeField] private AudioClip itemSelectSound;
    [SerializeField] private AudioSource audioSource;

    public static MenuNames currentOpenMenu;

    public void GoToSubmenu(MenuNames goToName)
    {
        audioSource.clip = itemSelectSound;
        audioSource.Play();

        bool credits = false;
        bool mainMenu = false;
        bool levelSelect = false;
        bool goBackButton = false;
        bool options = false;

        switch (goToName)
        {
            case MenuNames.MainMenu:
                CurrentPageNameText.text = "Main Menu";
                mainMenu = true;
                break;

            case MenuNames.Credits:
                CurrentPageNameText.text = "Credits";
                goBackButton = true;
                credits = true;
                break;

            case MenuNames.LevelSelect:
                CurrentPageNameText.text = "Level Select";
                goBackButton = true;
                levelSelect = true;
                break;

            case MenuNames.Options:
                CurrentPageNameText.text = "Options";
                goBackButton = true;
                options = true;
                break;

            case MenuNames.Exit:
                ExitGame();
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
        GoBackButton.gameObject.SetActive(goBackButton);
        CreditsTextElement.gameObject.SetActive(credits);

        currentOpenMenu = goToName;
    }



    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting"); // This line is for testing in the editor, as Application.Quit() won't work in the editor
    }
    public void LoadLevel(SceneAsset levelScene)
    {
        audioSource.clip = itemSelectSound;
        audioSource.Play();
        SceneManager.LoadScene(levelScene.name, LoadSceneMode.Single);
    }
}
