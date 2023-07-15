using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightNumber : MonoBehaviour
{
    public Text nightNumText;

    void Start()
    {
        nightNumText.text = "Night " + Convert.ToString(PlayerPrefs.GetInt("NightNum") + 1);
    }
}
