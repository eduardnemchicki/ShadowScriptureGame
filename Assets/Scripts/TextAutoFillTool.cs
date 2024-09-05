using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TextAutoFillTool : MonoBehaviour
{
    [SerializeField] private List<TextScript> textScripts = new List<TextScript>();
    [SerializeField] private List<string> fullTexts = new List<string>();
    [SerializeField] private List<float> thresholds = new List<float>();

    [SerializeField] private int lettersPerSlot = 4;

    public bool randomTextScramble = false;
    public bool randomThresh = false;
    [SerializeField] private float maxThresh = 50;
    [SerializeField] private float minThresh = 10;

    private void Start()
    {
        if (randomTextScramble)
        {

        }
        else
        {
            FillAllTexts();
        }
        if (randomThresh)
        {

        }
        else
        {
            FillAllThresholds();
        }
    }

    private void FillAllTexts()
    {
        foreach (TextScript script in textScripts)
        {
            script.secretTexts.Clear();
            //script.lightThresHolds.Clear();
        }
        
        for ( int i = 0; i < fullTexts.Count; i++)
        {
            string textToInsert = fullTexts[i].PadRight(lettersPerSlot * textScripts.Count);
            for (int j = 0; j < textScripts.Count; j++)
            {
                textScripts[j].secretTexts.Add(textToInsert.Substring(j*lettersPerSlot,lettersPerSlot));
                //textScripts[j].lightThresHolds.Add(thresholds[i]);
            }
        }
    }
    private void FillAllThresholds()
    {
        foreach (TextScript script in textScripts)
        {
            script.lightThresHolds.Clear();
        }

        for (int i = 0; i < thresholds.Count; i++)
        {
            for (int j = 0; j < textScripts.Count; j++)
            {
                textScripts[j].lightThresHolds.Add(thresholds[i]);
            }
        }

    }
}
