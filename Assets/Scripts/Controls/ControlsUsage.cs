using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

// [AI OVERVIEW] Reads ControlList key bindings each frame: Space toggles GameEvents.paperToggle (paper/instrument state), Escape invokes GameEvents.pauseMenuToggle. Entry point for player input that drives ObjectMoveScript, ClickableObject, candle scripts, and pause menu.
public class ControlsUsage : MonoBehaviour
{
    [SerializeField] private OpenMainMenuScript mainMenuScript;
    bool paperIsUp;
    bool objectsHighlighted;
    bool controlsChanging;
    public static bool menuCantBeToggled;

    void Awake()
    {
        ControlList.LoadControlsFromFile();
    }
    void Start()
    {
        paperIsUp = true;
        objectsHighlighted = false;
        controlsChanging = false;
        menuCantBeToggled = false;
        GameEvents.blockMenuButtons.AddListener(x => controlsChanging = x);
    }

    void Update()
    {
        if (Input.GetKeyDown(ControlList.controlsDictionary[ControlNames.TakePaper]) && !mainMenuScript.menuIsOpen && !controlsChanging && !menuCantBeToggled)
        {
            GameEvents.paperToggle.Invoke(paperIsUp);
            paperIsUp=!paperIsUp;
        }
        
        if (Input.GetKeyDown(ControlList.controlsDictionary[ControlNames.PauseMenu]) && !controlsChanging && !menuCantBeToggled) 
        {
            GameEvents.pauseMenuToggle.Invoke();
        }
        
        if (Input.GetKey(ControlList.controlsDictionary[ControlNames.HighlightText]) && !paperIsUp && !mainMenuScript.menuIsOpen && !controlsChanging)
        {
            objectsHighlighted = true;
            GameEvents.objectHighlightToggle.Invoke(true);
        }
        else if(objectsHighlighted)
        {
            GameEvents.objectHighlightToggle.Invoke(false);
            objectsHighlighted = false;
        }
    }
}
