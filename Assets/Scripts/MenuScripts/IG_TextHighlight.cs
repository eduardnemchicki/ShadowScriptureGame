using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IG_TextHighlight : MonoBehaviour
{
    [SerializeField] private Color elementToggledColor = Color.cyan;

    private TextMeshProUGUI textElement;
    private Color defaultColor;
    void Awake()
    {
        this.textElement = this.gameObject.GetComponent<TextMeshProUGUI>();
        defaultColor = textElement.color;
    }

    public void toggleColor(bool colorShouldBeDefault)
    {
        textElement.color = colorShouldBeDefault ? defaultColor : elementToggledColor;
    }
    private void OnMouseEnter()
    {
        this.toggleColor(false);
        print(elementToggledColor);
    }

    private void OnMouseExit()
    {
        this.toggleColor(true);
        print(defaultColor);

    }
    //private void OnMouseDown()
    //{
    //    this.toggleColor(false);
    //}
}
