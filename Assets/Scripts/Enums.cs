using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//new enums that are being used. Should make them easier to find
public enum MenuNames
{
    MainMenu,
    Credits,
    LevelSelect,
    Options,
    Exit,
    ToNewLevel
}
public enum ControlNames
{
    TakePaper = 0,
    SelectThingie = 1,
    PauseMenu = 2,
}
public enum PuzzleObjectType
{
    CandlesLit = 0,
    CandlesNotLit = 1,
    Chain = 2,
    Cage = 3,
    Barrel = 4,
}