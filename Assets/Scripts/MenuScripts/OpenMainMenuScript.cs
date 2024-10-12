using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenMainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject menuToOpen;
    [SerializeField] MenuManager menuManager;
    private bool menuIsOpen = false;

    void Start()
    {
        GameEvents.pauseMenuToggle.AddListener(OpenClosePauseMenu);

        menuIsOpen = menuToOpen.activeSelf;

    }

    private void OpenClosePauseMenu()
    {
        if (MenuManager.currentOpenMenu != MenuNames.MainMenu && menuIsOpen)
        {
            menuManager.GoToSubmenu(MenuNames.MainMenu);
            return;
        }

        if (menuIsOpen) //closing the pause menu
        {
            Time.timeScale = 1.0f;
            menuToOpen.SetActive(false);
        }
        else //opening pause menu
        {
            Time.timeScale = 0f;
            menuToOpen.SetActive(true);
            menuManager.GoToSubmenu(MenuNames.MainMenu);
        }

        menuIsOpen = !menuIsOpen;
    }
    private void OpenClosePauseMenu(bool setState)
    {
        menuIsOpen = !setState;
        OpenClosePauseMenu();
    }
    
}
