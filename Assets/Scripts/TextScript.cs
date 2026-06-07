using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

// [AI OVERVIEW] Per-object hidden scripture text. Registers in CandleTextInteraction.listOfTexts; drives TextMeshPro from secretTexts by light level (lightThresHolds). Shift/ResetShift nudge transform for multi-slot word alignment. Called by CandleTextInteraction.RevealCheck and configured by TextAutoFillTool.
public class TextScript : MonoBehaviour
{

    public List<string> secretTexts = new List<string>() { "", "hello" };
    public List<float> lightThresHolds = new List<float>() { 10, 20 };

    private TextMeshPro textMesh;
    private List<float> totalShiftAmounts = new List<float>();
    private int currentShiftLevel = 0;
    private void Awake()
    {
        textMesh = GetComponent<TextMeshPro>();

        CandleTextInteraction.listOfTexts.Add(this);
        foreach(var text in secretTexts)
        {
            totalShiftAmounts.Add(0f);
        }
    }

    public void Shift(float shiftAmount,int shiftLevel)
    {
        this.transform.position.Set(this.transform.position.x + shiftAmount, this.transform.position.y, this.transform.position.z);
        totalShiftAmounts[shiftLevel] += shiftAmount;
        currentShiftLevel = shiftLevel;
    }

    public void ResetShift()
    {
        this.transform.position.Set(this.transform.position.x - totalShiftAmounts[currentShiftLevel], this.transform.position.y, this.transform.position.z);
        for (int i = 0; i < totalShiftAmounts.Count; i++)
        {
            totalShiftAmounts[i] = 0f;
        }
        currentShiftLevel = 0;
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
