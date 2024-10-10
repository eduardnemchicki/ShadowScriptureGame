using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMenuScene : MonoBehaviour
{
    [SerializeField] GameObject menuToOpen;
    //[SerializeField] SceneAsset menuScene;
    private bool menuIsOpen = false;

    void Start()
    {
        GameEvents.pauseMenuToggle.AddListener(OpenClosePauseMenu);
    }

    private void OpenClosePauseMenu()
    {
        if (menuIsOpen) //closing the pause menu
        {
            Time.timeScale = 1.0f;
            menuToOpen.SetActive(false);
        }
        else //opening pause menu
        {
            Time.timeScale = 0f;
            menuToOpen.SetActive(true);
            //SceneManager.LoadScene(menuScene.name, LoadSceneMode.Additive);
        }

        menuIsOpen = !menuIsOpen;
    }
}
