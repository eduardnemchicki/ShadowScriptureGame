using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class TextScript : MonoBehaviour
{

    public List<string> secretTexts = new List<string>() { "", "hello" };
    public List<float> lightThresHolds = new List<float>() { 10, 20 };

    private TextMeshPro textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();

        CandleTextInteraction.listOfTexts.Add(this);
    }
    public void RevealCheck(float currentLightLvl)
    {
        var acceptableLightLvls = lightThresHolds.FindAll(x => x > currentLightLvl);
        if (secretTexts.Count > 0)
        {
            if (acceptableLightLvls.Count > 0)
            {
                var newLightLvl = acceptableLightLvls.Min();
                int textIndex = lightThresHolds.IndexOf(newLightLvl);
                if (textIndex >= secretTexts.Count)
                {
                    textMesh.text = secretTexts.Last();
                }
                else
                {
                    textMesh.text = secretTexts[textIndex];
                }
            }
            else
            {
                textMesh.text = secretTexts.Last();
            }
        }
        
    }

}
