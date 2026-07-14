using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using UnityEngine;

// [AI OVERVIEW] Level-setup helper: splits fullTexts across assigned TextScript instances by lettersPerSlot, applies Shift for word-wrap alignment, and copies thresholds into each TextScript.lightThresHolds. Runs on Start; interacts only with serialized TextScript list (no GameEvents).
public class TextAutoFillTool : MonoBehaviour
{
    [SerializeField] private List<TextScript> textScripts = new List<TextScript>(); //list of all text fields that are going to be filled by this.
    [SerializeField] private List<string> fullTexts = new List<string>(); //list of texts to be spread among fields. Every text is going on different "Light level"
    [SerializeField] private List<float> thresholds = new List<float>(); //light levels needed for text to appear 1 number for 1 text from fullTexts.

    [SerializeField] private int lettersPerSlot = 4;

    [SerializeField] private int slotsPerLine = 4; //not used currently
    [SerializeField] private float shiftFactor = 0.02f;

    public bool randomTextScramble = false;
    public bool randomThresh = false;
    [SerializeField] private float maxThresh = 50;  //for random threshold option, not implemented
    [SerializeField] private float minThresh = 10;

    private void Start()
    {
        if (randomTextScramble)
        {
            //scrambling text among different scraps for potential *reasemble a letter from pieces* 
        }
        else
        {
            FillAllTexts();
        }
        if (randomThresh)
        {
            // potential for random thresholds for different parts of text, as a difficulty mechanic
        }
        else
        {
            FillAllThresholds();
        }
    }

    private void FillAllTexts()
    {
        foreach (TextScript textBox in textScripts)
        {
            textBox.secretTexts.Clear();
            textBox.ResetShift();
        }
        
        for ( int i = 0; i < fullTexts.Count; i++)
        {
            string textToInsert = fullTexts[i].PadRight(lettersPerSlot * textScripts.Count);
            bool wordContinues = false;
            int continueCounter = 1;

            for (int j = 0; j < textScripts.Count; j++)
            {
                string textToAdd = textToInsert.Substring(j * lettersPerSlot, lettersPerSlot);
                textScripts[j].secretTexts.Add(textToAdd);
                
                if (wordContinues)
                {
                    float shiftAmount = continueCounter * shiftFactor;
                    textScripts[j].Shift(-shiftAmount,i);

                    continueCounter += 1;
                }
                //var x = textToAdd.Count(char.IsWhiteSpace);
                if (Regex.Matches(textToAdd, @"\s+").Count() % 2 != 0)
                {
                    continueCounter = 1;
                    wordContinues = !wordContinues;
                    textScripts[j].Shift(shiftFactor,i);
                }
                
                
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
