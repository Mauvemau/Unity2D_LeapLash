using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField]
    private Text powerMarker;

    public void UpdatePower(int amount)
    {
        powerMarker.text = "Power: " + amount;
    }

    private void Awake()
    {
        if (!powerMarker)
        {
            foreach (Transform t in transform)
            {
                if (t.name == "PowerMarker")
                {
                    powerMarker = t.GetComponent<Text>();
                }
            }
        }
    }

}
