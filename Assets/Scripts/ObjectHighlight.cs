using System.Collections.Generic;
using UnityEngine;

public class ObjectHighlight : MonoBehaviour
{
    private Material highlightMat;

    private List<Material> defaultMats = new List<Material>();

    // This script duplicates the highlighting functionality of ClickableObject, but is designed to be attached to any GameObjects that do not use the ClickableObject script. 
    // probably either should shift functionality from there to here, or make this script a subclass of ClickableObject.
    void Start()
    {
        highlightMat = CommonItemHager.highlightMat;
        GameEvents.objectHighlightToggle.AddListener(HighLight);
    }

    private void HighLight(bool shouldHighlight)
    {
        if (shouldHighlight)
        {
            foreach (var renderer in this.gameObject.GetComponentsInChildren<Renderer>())
            {
                renderer.material = highlightMat;
            }
        }
        else
        {
            int i = 0;
            foreach (var renderer in this.gameObject.GetComponentsInChildren<Renderer>())
            {
                renderer.material = defaultMats[i];
                i++;
            }
        }
    }
}
