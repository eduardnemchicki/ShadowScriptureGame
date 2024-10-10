using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KeyboardControls : MonoBehaviour
{
    bool paperIsUp;
    // Start is called before the first frame update
    void Start()
    {
        paperIsUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(ControlList.controlsDictionary[ControlNames.TakePaper]))
        {
            GameEvents.paperToggle.Invoke(paperIsUp);
            paperIsUp=!paperIsUp;
        }
        if (Input.GetKeyDown(ControlList.controlsDictionary[ControlNames.PauseMenu])) 
        {
            GameEvents.pauseMenuToggle.Invoke();
        }
    }
}
