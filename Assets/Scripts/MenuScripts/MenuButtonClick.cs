using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

// [AI OVERVIEW] UI click handler for menu TMP labels. On click resets TextHighlight and calls MenuManager.GoToSubmenu or LoadLevel (MenuNames.ToNewLevel + SceneAsset). Requires TextHighlight on same GameObject; serialized MenuManager reference.
[RequireComponent(typeof(TextHighlight))]
public class MenuButtonClick : MonoBehaviour, IPointerClickHandler
{
    //just a copy of MenuButtonInteraction class, but for use with MenuManager

    [SerializeField] private TextHighlight textHighlight;
    [SerializeField] private string sceneNameToOpen;
    [SerializeField] private MenuNames buttonType;
    [SerializeField] private MenuManager menuItemSelectorScript;
    bool isBlocked;
    public void OnPointerClick(PointerEventData eventData)
    {
        if(isBlocked) return;

        textHighlight.toggleColor(false);

        if (buttonType == MenuNames.ToNewLevel)
        {
            menuItemSelectorScript.LoadLevel(sceneNameToOpen);
        }
        else
        {
            menuItemSelectorScript.GoToSubmenu(buttonType);
        }
    }

    private void Awake()
    {
        if (textHighlight == null) // if i get too lasy to assign it all by hand
        {
            isBlocked = false;
            textHighlight = this.gameObject.GetComponent<TextHighlight>();
            GameEvents.blockMenuButtons.AddListener(x => isBlocked = x);
        }
    }
}
