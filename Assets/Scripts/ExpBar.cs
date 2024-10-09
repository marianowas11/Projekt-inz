using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;

    public void SetMaxXp(float maxXP, float xp)
    {
        slider.maxValue = maxXP;
        slider.value = xp;
    }
    public void SetXp(int xp)
    {
        slider.value = xp;
    }
}
