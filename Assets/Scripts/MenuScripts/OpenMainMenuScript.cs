using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// [AI OVERVIEW] Pause menu toggle on GameEvents.pauseMenuToggle: shows/hides menuToOpen, sets Time.timeScale, resets navigation via MenuManager.GoToSubmenu(MainMenu). Tracks menuIsOpen; returns from submenus to MainMenu when pausing again.
public class OpenMainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject menuToOpen;
    [SerializeField] MenuManager menuManager;
    public bool menuIsOpen { get; private set; } = false;

void Start()
    {
        GameEvents.pauseMenuToggle.AddListener(OpenClosePauseMenu);

        menuIsOpen = menuToOpen.activeSelf;

    }

    private void OpenClosePauseMenu()
    {
        if (MenuManager.currentOpenMenu != MenuNames.MainMenu && menuIsOpen)
        {
            //returning to main menu from submenus when inside pause menu
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
        //this is for the case when we want to open/close menu when it is in the wrong state (usually because of some error)

        if (setState == menuIsOpen)
        {
            OpenClosePauseMenu();
        }
        OpenClosePauseMenu();
    }
    
}
