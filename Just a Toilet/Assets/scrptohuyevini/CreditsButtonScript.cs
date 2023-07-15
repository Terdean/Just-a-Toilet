using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsButtonScript : MonoBehaviour
{
    public GameObject CreditsButton;

    private void Start()
    {
        CreditsButton.SetActive(false);

        if(PlayerPrefs.HasKey("CreditsButton"))
        {
            if(PlayerPrefs.GetInt("CreditsButton") == 1)
            {
                CreditsButton.SetActive(true);
            }
        }
    }
}
