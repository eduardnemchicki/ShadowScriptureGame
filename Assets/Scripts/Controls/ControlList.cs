using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [AI OVERVIEW] Static dictionary mapping ControlNames to KeyCode defaults (Mouse0, Space, Escape). Used by ControlsUsage; ChangeControlButton allows runtime rebinding for options UI (not wired in current scripts).
public static class ControlList
{
    private static string controlsFilePath = Application.persistentDataPath + "/controls.json";

    public static Dictionary<ControlNames, KeyCode> controlsDictionary { get; private set; }
        = new Dictionary<ControlNames, KeyCode>
        {
            { ControlNames.SelectThingie, KeyCode.Mouse0 },
            { ControlNames.TakePaper, KeyCode.Space },
            { ControlNames.PauseMenu, KeyCode.Escape },
            { ControlNames.HighlightText, KeyCode.LeftShift }
        };
    
    public static void ResetControlsToDefault()
    {
        controlsDictionary[ControlNames.SelectThingie] = KeyCode.Mouse0;
        controlsDictionary[ControlNames.TakePaper] = KeyCode.Space;
        controlsDictionary[ControlNames.PauseMenu] = KeyCode.Escape;
        controlsDictionary[ControlNames.HighlightText] = KeyCode.LeftShift;
        SaveControlsToFile();
    }
    public static void ChangeControlButton(ControlNames name, KeyCode newButton)
    {
        controlsDictionary[name] = newButton;
    }
    public static void SaveControlsToFile()
    {
        string json = JsonUtility.ToJson(controlsDictionary);
        System.IO.File.WriteAllText(controlsFilePath, json);
    }
    public static void LoadControlsFromFile()
    {
        if (System.IO.File.Exists(controlsFilePath))
        {
            string json = System.IO.File.ReadAllText(controlsFilePath);
            ControlList.controlsDictionary = JsonUtility.FromJson<Dictionary<ControlNames, KeyCode>>(json);
        }
    }
}
