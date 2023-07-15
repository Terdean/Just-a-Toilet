using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DoorScript : MonoBehaviour
{
    public bool isDoorOpen;

    static float stinkMetr;
    public float stinkMetrTimer;
    public float stinkMetrTimerStart;
    public float stinkMetrAdd;
    public float stinkMetrRemove;

    public Animator animator;

    public AudioSource Source;

    public Text percentOfStink;

    private float govnaplivTimer = 15;
    private float screamerTimer = 7;
    public GameObject Govnapliv;
    public GameObject Screamer; // Обычно объект выключен
    public AudioSource ScreamerSound;
    private bool isGovnoProsochilos = false;
    public GameObject AllUI;
    public GameObject AllEnemies;
    public AudioSource GovnaplivMusica;
    public GameObject AnotherDarkness;
    public GameObject CameraPos;

    public MenuScript ScenesManager;

    private void Start()
    {
        stinkMetr = 0;
    }

    void Update()
    {
        if(!isDoorOpen)
        {
            stinkMetrTimer -= Time.deltaTime;
            if (stinkMetrTimer <= 0)
            {
                if (stinkMetr < 100)
                {
                    stinkMetr += stinkMetrAdd;

                    percentOfStink.text = Convert.ToString(Mathf.Round(stinkMetr)) + "%";
                }

                stinkMetrTimer = stinkMetrTimerStart;
            }
        }
        else if (isDoorOpen)
        {
            stinkMetrTimer -= Time.deltaTime;
            if (stinkMetrTimer <= 0)
            {
                if(stinkMetr > 0)
                {
                    stinkMetr -= stinkMetrRemove;
                }
                stinkMetrTimer = stinkMetrTimerStart;

                percentOfStink.text = Convert.ToString(Mathf.Round(stinkMetr)) + "%";
            }
        }

        if(stinkMetr >= 100 || isGovnoProsochilos)
        {
            if(!isGovnoProsochilos)
            {
                Govnapliv.SetActive(true);
                GovnaplivMusica.Play();
                AnotherDarkness.SetActive(true);

                AllUI.SetActive(false);
                AllEnemies.SetActive(false);

                isGovnoProsochilos = true;

                CameraPos.transform.position = new Vector3(0, 0, -10);
            }

            Govnapliv.transform.position += new Vector3(0, 0.004f, 0);

            if (govnaplivTimer > 0)
            {
                govnaplivTimer -= Time.deltaTime;
            }
            
            if (screamerTimer > 0 && govnaplivTimer <= 0)
            {
                if (screamerTimer == 7)
                {
                    Screamer.SetActive(true);
                    ScreamerSound.Play();
                    GovnaplivMusica.Stop();
                }

                screamerTimer -= Time.deltaTime;
            }
            else if(screamerTimer <= 0 && govnaplivTimer <= 0)
            {
                ScenesManager.SceneChange(0);
            }
        }
    }

    public void ChangeDoor()
    {
        isDoorOpen = !isDoorOpen;
        animator.SetBool("isDoorOpened", isDoorOpen);

        Source.pitch = UnityEngine.Random.Range(0.7f, 1.1f);
        Source.Play();
    }
}
