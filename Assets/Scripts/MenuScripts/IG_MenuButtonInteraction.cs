using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class IG_MenuButtonInteraction : MonoBehaviour
{
    //just a copy of MenuButtonInteraction class, but for use with IG_MenuManager

    [SerializeField] private IG_TextHighlight textHighlight;
    [SerializeField] private SceneAsset sceneToOpen;
    [SerializeField] private MenuNames buttonType;
    [SerializeField] private IG_MenuManager menuItemSelectorScript;

    private void Awake()
    {
        if (textHighlight == null) // if i get too lasy to assign it all by hand
        {
            textHighlight = this.gameObject.GetComponent<IG_TextHighlight>();
        }
    }


    private void OnMouseDown()
    {
        textHighlight.toggleColor(false);

        if (buttonType == MenuNames.ToNewLevel)
        {
            menuItemSelectorScript.LoadLevel(sceneToOpen);
        }
        else
        {
            menuItemSelectorScript.GoToSubmenu(buttonType);
        }
    }
}
