using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [AI OVERVIEW] Scene hook that exposes one serialized Light as static CommonItemHager.candleLight in Awake. Intended for global candle reference (e.g. AltTextScript); parallel to per-scene Light on CandleTextInteraction.
public class CommonItemHager : MonoBehaviour
{
    public Light lightSelector = new Light();
    public Material highlightMatSelector;
    public static Light candleLight;
    public static Material highlightMat;
    private void Awake()
    {
        highlightMat = highlightMatSelector;
        candleLight = lightSelector;
    }
}
