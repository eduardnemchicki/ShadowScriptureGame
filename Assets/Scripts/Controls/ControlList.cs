using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ControlNames
{
    TakePaper = 0,
    SelectThingie = 1
}
public static class ControlList
{
    public static Dictionary<ControlNames, KeyCode> controlsDictionary
        = new Dictionary<ControlNames, KeyCode>
        {
            { ControlNames.SelectThingie, KeyCode.Mouse0 },
            { ControlNames.TakePaper, KeyCode.Space }
        };


    public static void ChangeControlButton(ControlNames name, KeyCode newButton)
    {
        controlsDictionary[name] = newButton;
    }
}
