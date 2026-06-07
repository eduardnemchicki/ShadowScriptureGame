using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [AI OVERVIEW] Static dictionary mapping ControlNames to KeyCode defaults (Mouse0, Space, Escape). Used by ControlsUsage; ChangeControlButton allows runtime rebinding for options UI (not wired in current scripts).
public static class ControlList
{
    public static Dictionary<ControlNames, KeyCode> controlsDictionary { get; private set; }
        = new Dictionary<ControlNames, KeyCode>
        {
            { ControlNames.SelectThingie, KeyCode.Mouse0 },
            { ControlNames.TakePaper, KeyCode.Space },
            { ControlNames.PauseMenu, KeyCode.Escape },
            { ControlNames.HighlightText, KeyCode.LeftShift }
        };


    public static void ChangeControlButton(ControlNames name, KeyCode newButton)
    {
        controlsDictionary[name] = newButton;
    }
}
