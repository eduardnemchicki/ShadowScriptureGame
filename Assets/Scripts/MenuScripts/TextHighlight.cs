using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class TextHighlight : MonoBehaviour
{
    [SerializeField] private Color elementToggledColor = Color.cyan;

    private TextMeshPro textElement;
    private Color defaultColor;
    void Awake()
    {
        this.textElement = this.GetComponent<TextMeshPro>();
        defaultColor = textElement.color;
    }

    public void toggleColor(bool colorShouldBeDefault)
    {
        textElement.color = colorShouldBeDefault ? defaultColor : elementToggledColor;
    }
    private void OnMouseEnter()
    {
        this.toggleColor(false);
    }

    private void OnMouseExit()
    {
        this.toggleColor(true);
    }
    //private void OnMouseDown()
    //{
    //    this.toggleColor(false);
    //}
}
