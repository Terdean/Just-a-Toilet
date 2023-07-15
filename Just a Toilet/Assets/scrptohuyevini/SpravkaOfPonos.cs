using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpravkaOfPonos : MonoBehaviour
{
    public GameObject Spravka; // Справка сама по себе должна являться кнопкой, на которую наложили спрайт со справкой. Ещё на спрайты должно быть дано ясно понять, что если кликнуть по экрану - то можно начать игру.

    void Start()
    {
        Spravka.SetActive(false);

        if (!PlayerPrefs.HasKey("NightNum"))
        {
            Time.timeScale = 0;
            Spravka.SetActive(true);
        }
    }

    public void SkipSpravka()
    {
        Time.timeScale = 1;
        Spravka.SetActive(false);
    }
}
