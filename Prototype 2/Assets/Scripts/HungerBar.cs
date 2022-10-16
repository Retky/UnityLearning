using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHunger(int hunger)
    {
        slider.maxValue = hunger;
        fill.color = gradient.Evaluate(1f);
    }

    public void SetHunger(int hunger)
    {
        slider.value = hunger;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
