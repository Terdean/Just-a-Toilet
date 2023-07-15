using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NightTimer : MonoBehaviour
{
    public Text text; //“екст изначально должен уже гласить У12 PMФ
    public string[] textOfTime;

    public float nightTimer = 60;
    public int whichMinutePassed;

    public NightDifficultyChange NightDifficulty;
    public MenuScript ScenesManager;

    public AudioSource endingSound;
    public GameObject EndingScreen; //ќбычно этот объект должен быть выключен, пока игрок не доживЄт до 6 утра
    public float endingTimer = 2;
    public GameObject AllUI;
    public GameObject AllEnemies;

    void Update()
    {
        if (nightTimer >= 0)
        {
            nightTimer -= Time.deltaTime;
        }
        else
        {
            nightTimer = 60;

            whichMinutePassed++;
            text.text = textOfTime[whichMinutePassed];
        }

        if (whichMinutePassed >= 6)
        {
            if (endingTimer == 8) //если изменишь скример таймер не забудь помен€ть и это
            {
                EndingScreen.SetActive(true);
                AllUI.SetActive(false);
                AllEnemies.SetActive(false);

                endingSound.pitch = Random.Range(0.7f, 1.1f);
                endingSound.Play();

                NightDifficulty.whichNightIsNow++;

                if (NightDifficulty.whichNightIsNow < 5)
                {
                    PlayerPrefs.SetInt("NightNum", NightDifficulty.whichNightIsNow);
                    PlayerPrefs.SetInt("CreditsButton", 1);
                    PlayerPrefs.Save();
                }
            }

            if (endingTimer >= 0)
            {
                endingTimer -= Time.deltaTime;
            }
            else
            {
                if (NightDifficulty.whichNightIsNow < 5)
                {
                    ScenesManager.SceneChange(1);
                }
                else
                {
                    ScenesManager.SceneChange(2);
                }
            }
        }
    }
}
