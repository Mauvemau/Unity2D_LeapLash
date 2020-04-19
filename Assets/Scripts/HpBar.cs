using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{

    private Slider slider;
    [SerializeField]
    private Image fill;
    [SerializeField]
    private Gradient gradient;

    public void SetMaxValue(int amount)
    {
        slider.maxValue = amount;
        slider.value = amount;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetValue(int amount)
    {
        slider.value = amount;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void Awake()
    {
        slider = this.gameObject.GetComponent < Slider > ();

        if (!fill)
        {
            foreach (Transform t in transform)
            {
                if (t.name == "Fill")
                {
                    fill = t.GetComponent<Image>();
                }
            }
        }

    }

}
