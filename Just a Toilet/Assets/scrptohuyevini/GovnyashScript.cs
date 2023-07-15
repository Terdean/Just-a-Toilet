using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GovnyashScript : MonoBehaviour
{
    public Transform futurePos;

    public GameObject Screamer;
    private float screamerTimer = 7; //если изменишь скример таймер не забудь поменять и ниже
    public AudioSource ScreamerSound;
    public MenuScript ScenesManager;

    public DoorScript SeatOfTOLCHOK;

    public GameObject OtherEnemy1;
    public GameObject OtherEnemy2;
    public GameObject OtherEnemy3;

    public NightTimer WakieWakieTime;

    void Update()
    {
        if (transform.position.y >= 20 || screamerTimer != 7) //если изменишь скример таймер не забудь поменять и это
        {
            if (screamerTimer == 7) //если изменишь скример таймер не забудь поменять и это
            {
                Screamer.SetActive(true);

                ScreamerSound.pitch = Random.Range(0.9f, 1.1f);
                ScreamerSound.Play();

                OtherEnemy1.SetActive(false);
                OtherEnemy2.SetActive(false);
                OtherEnemy3.SetActive(false);
            }

            if (screamerTimer > 0)
            {
                screamerTimer -= Time.deltaTime;
            }
            else
            {
                ScenesManager.SceneChange(0);
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -25.5f, 0), 0.002f);
    }

    public void MovePoopBack() //Этот метод нужно накладывать на кнопку
    {
        if(SeatOfTOLCHOK.isDoorOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -29, 0), 0.1f);
        }
    }
}
