using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//new enums that are being used. Should make them easier to find
// [AI OVERVIEW] Shared enums: MenuNames (MenuManager, MenuButtonClick, OpenMainMenuScript), ControlNames (ControlList, ControlsUsage), PuzzleObjectType (ClickableObject, VictroryCondition assets, GameEvents.puzzleElementClicked).
public enum MenuNames
{
    MainMenu,
    Credits,
    LevelSelect,
    Options,
    Exit,
    ToNewLevel,
    Options_Sound,
    Options_Controls,
}
public enum ControlNames
{
    TakePaper = 0,
    SelectThingie = 1,
    PauseMenu = 2,
    HighlightText = 3,
}
public enum PuzzleObjectType
{
    CandlesLit = 0,
    CandlesNotLit = 1,
    Chain = 2,
    Cage = 3,
    Barrel = 4,
}