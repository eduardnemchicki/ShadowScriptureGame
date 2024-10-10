using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IG_MenuManager : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> Levels = new List<TextMeshProUGUI>();
    [SerializeField] TextMeshProUGUI GoBackButton;
    [SerializeField] TextMeshProUGUI CurrentPageName;
    [SerializeField] List<TextMeshProUGUI> MainMenuElements = new List<TextMeshProUGUI>();
    [SerializeField] TextMeshProUGUI CreditsTextElement;

    [SerializeField] private AudioClip itemSelectSound;
    [SerializeField] private AudioSource audioSource;

    //public void GoToCredits()
    //{
    //    GoToSubmenu(MenuNames.Credits);

    //}
    //public void GoToLevelSelect()
    //{
    //    GoToSubmenu(MenuNames.LevelSelect);
    //}
    //public void GoToMainMenu()
    //{
    //    GoToSubmenu(MenuNames.MainMenu);
    //}

    public void GoToSubmenu(MenuNames goToName)
    {
        audioSource.clip = itemSelectSound;
        audioSource.Play();

        bool credits = false;
        bool mainMenu = false;
        bool levelSelect = false;
        bool goBackButton = false;

        switch (goToName)
        {
            case MenuNames.MainMenu:
                CurrentPageName.text = "Main Menu";
                mainMenu = true;
                break;

            case MenuNames.Credits:
                CurrentPageName.text = "Credits";
                goBackButton = true;
                credits = true;
                break;

            case MenuNames.LevelSelect:
                CurrentPageName.text = "Level Select";
                goBackButton = true;
                levelSelect = true;
                break;

            case MenuNames.Exit:
                ExitGame();
                break;
        }

        foreach (var levelElement in Levels)
        {
            levelElement.gameObject.SetActive(levelSelect);
        }
        foreach (var menuElement in MainMenuElements)
        {
            menuElement.gameObject.SetActive(mainMenu);
        }
        GoBackButton.gameObject.SetActive(goBackButton);
        CreditsTextElement.gameObject.SetActive(credits);

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
