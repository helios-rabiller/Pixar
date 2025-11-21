using UnityEngine;
using System.Collections;   
using System.Collections.Generic;
using UnityEngine.UI;

public class Health_system : MonoBehaviour
{
    public Slider barrevie;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int pv)
    {
        barrevie.maxValue = pv;
        barrevie.value = pv;
        gradient.Evaluate(1f);
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int pv)
    {
        barrevie.value = pv;
        fill.color = gradient.Evaluate(barrevie.normalizedValue);
    }
}
