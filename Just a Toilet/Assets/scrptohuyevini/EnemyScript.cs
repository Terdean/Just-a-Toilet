using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float movementTimer = 6;
    public float movementTimerMax = 20;

    public int enemyPos = 0;
    public int chancesToGoCloser;
    public int chancesToGoBack;

    private int backNum;
    private int closerNum;

    public int posOfPlayer;

    public DoorScript Door;
    public GameObject Outsidus;

    public GameObject Screamer;
    private float screamerTimer = 7; //если изменишь скример таймер не забудь помен€ть и ниже
    public AudioSource ScreamerSound;

    public float[] EnemyPositionsX;
    public float[] EnemyPositionsY;

    public float[] EnemyScaleWidth;
    public float[] EnemyScaleHight;

    private int howMuchRoomsPassed; //ќтвечает за то сколько комнат пройдЄт враг за ход. Ќужно сделать ещЄ так, чтобы он не мог случайно пройти дальше игрока или зайти к нему, если дверь закрыта. 
    public int speedOfEnemy = 2;
    public int minSpeedOfEnemy = 1;

    public MenuScript ScenesManager;

    public float attackTimer;
    public float attackTimerStart;

    public GameObject OtherEnemy1;
    public GameObject OtherEnemy2;
    public GameObject OtherEnemy3;

    public NightTimer WakieWakieTime;
    public NightNumber night;

    public float goAwayTimer;
    public float goAwayTimerStart;
    public int goAwaySpeed;

    void Update()
    {
        if (movementTimer > 0 && enemyPos < posOfPlayer)
        {
            if(PlayerPrefs.GetInt("NightNum") == 0 || !PlayerPrefs.HasKey("NightNum"))
            {
                if(WakieWakieTime.whichMinutePassed >= 1)
                {
                    movementTimer -= Time.deltaTime;
                }
            }
            else if (PlayerPrefs.GetInt("NightNum") > 0)
            {
                movementTimer -= Time.deltaTime;
            }
        }
        else if (movementTimer <= 0 && enemyPos < posOfPlayer)
        {
            howMuchRoomsPassed = Random.Range(minSpeedOfEnemy, speedOfEnemy);

            movementTimer = Random.Range(5, movementTimerMax);

            closerNum = Random.Range(0, chancesToGoCloser);
            backNum = Random.Range(0, chancesToGoBack);

            if(enemyPos != posOfPlayer - 1)
            {
                if (closerNum > backNum)
                {
                    if (enemyPos + howMuchRoomsPassed >= posOfPlayer - 1)
                    {
                        enemyPos = posOfPlayer - 1;
                    }
                    else
                    {
                        enemyPos += howMuchRoomsPassed;
                    }
                }
                else
                {
                    enemyPos = enemyPos - howMuchRoomsPassed;

                    if (enemyPos < 0)
                    {
                        enemyPos = 0;
                    }
                }
            }

            Outsidus.transform.position = new Vector3(EnemyPositionsX[enemyPos], EnemyPositionsY[enemyPos], 0);
            Outsidus.transform.localScale = new Vector3(EnemyScaleWidth[enemyPos], EnemyScaleWidth[enemyPos], 1);
        }

        if (enemyPos == posOfPlayer - 1)
        {
            if(attackTimer > 0 && Door.isDoorOpen)
            {
                attackTimer -= Time.deltaTime;
            }
            else if (attackTimer <= 0 && Door.isDoorOpen)
            {
                enemyPos = posOfPlayer;
            }

            if (goAwayTimer > 0 && !Door.isDoorOpen)
            {
                goAwayTimer -= Time.deltaTime;
            }
            else if (goAwayTimer <= 0 && !Door.isDoorOpen)
            {
                goAwayTimer = goAwayTimerStart;
                attackTimer = attackTimerStart;
                enemyPos -= goAwaySpeed;
            }
        }

        if (enemyPos == posOfPlayer)
        {
            OtherEnemy1.SetActive(false);
            OtherEnemy2.SetActive(false);
            OtherEnemy3.SetActive(false);

            if (screamerTimer == 7) //если изменишь скример таймер не забудь помен€ть и это
            {
                Screamer.SetActive(true);

                ScreamerSound.pitch = Random.Range(0.9f, 1.1f);
                ScreamerSound.Play();
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
    }
}

