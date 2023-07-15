using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class PhoneGuy : MonoBehaviour
{
    public AudioSource[] phoneReplicues;
    public AudioSource phoneRingtone;
    public GameObject SkipButton;

    private float waitUntilCall = 4;
    private bool isReplicueStarted = false;
    public bool StopIt = false;

    private void Start()
    {
        phoneRingtone.Play();
    }

    private void Update()
    {
        if(waitUntilCall > 0)
        {
            waitUntilCall -= Time.deltaTime;
        }
        else
        {
            if(!isReplicueStarted)
            {
                isReplicueStarted = true;

                if (PlayerPrefs.HasKey("NightNum"))
                {
                    phoneReplicues[PlayerPrefs.GetInt("NightNum")].pitch = Random.Range(0.9f, 1.1f);
                    phoneReplicues[PlayerPrefs.GetInt("NightNum")].Play();
                }
                else
                {
                    phoneReplicues[0].pitch = Random.Range(0.9f, 1.1f);
                    phoneReplicues[0].Play();
                }
            }
        }

        if(StopIt == true)
        {
            phoneReplicues[PlayerPrefs.GetInt("NightNum")].Stop();
            phoneReplicues[0].Stop();
        }
    }

    public void skipReplicue()
    {
        if (PlayerPrefs.HasKey("NightNum"))
        {
            phoneReplicues[PlayerPrefs.GetInt("NightNum")].Stop();
        }
        else
        {
            phoneReplicues[0].Stop();
        }

        phoneRingtone.Stop();
        SkipButton.SetActive(false);
        StopIt = true;
    }
}
