using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonItemHager : MonoBehaviour
{
    public Light lightSelector = new Light();

    public static Light candleLight;

    private void Awake()
    {
        candleLight = lightSelector;
    }
}
