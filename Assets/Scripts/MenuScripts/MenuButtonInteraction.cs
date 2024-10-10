using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuButtonInteraction : MonoBehaviour
{
    [SerializeField] private TextHighlight textHighlight;
    [SerializeField] private SceneAsset sceneToOpen;
    [SerializeField] private MenuNames buttonType;
    [SerializeField] private MenuItemManagementScript menuItemSelectorScript;

    private void Awake()
    {
        if (textHighlight == null) // if i get too lasy to assign it all by hand
        {
            textHighlight = this.gameObject.GetComponent<TextHighlight>();
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
