using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

public class FlashLightScript : MonoBehaviour
{
    public bool isFlashLightTurnedOn = false;

    public GameObject Darkness; //Сам фонарик будет светом, а значит нужно добавить тьму, которую он будет убирать.

    private float flashLightBurnLevel = 0;
    public int flashLightBurnLevelMax;
    private float flashLightRepairTimer = 0;
    public float flashLightRepairTimerStart;

    public AudioSource TurnLightModeSFX;
    public AudioSource BurnSFX;

    public AudioSource EnemySpotedSFX;
    public EnemyScript HT;
    public EnemyScript FK;
    public EnemyScript MOCH;
    public CameraMovement cameraMovement;
    public DoorScript Door;
    public DoorScript TOLCHOK;
    public DoorScript Window;
    public float playEnemySpotedAgainTimer;
    public float playEnemySpotedAgainTimerStart;
    private bool isEnemySpoted = false;

    void Update()
    {
        if (isFlashLightTurnedOn && flashLightBurnLevel < flashLightBurnLevelMax)
        {
            flashLightBurnLevel += Time.deltaTime;

            if(cameraMovement.CamPos == 1 && Window.isDoorOpen && MOCH.enemyPos == MOCH.posOfPlayer - 1 && 
                playEnemySpotedAgainTimer == playEnemySpotedAgainTimerStart)
            {
                EnemySpotedSFX.Play();
                isEnemySpoted = true;
            }

            if (cameraMovement.CamPos == 0 && Door.isDoorOpen && HT.enemyPos == HT.posOfPlayer - 1 &&
                playEnemySpotedAgainTimer == playEnemySpotedAgainTimerStart)
            {
                EnemySpotedSFX.Play();
                isEnemySpoted = true;
            }

            if (cameraMovement.CamPos == -1 && TOLCHOK.isDoorOpen && FK.enemyPos == FK.posOfPlayer - 1 &&
                playEnemySpotedAgainTimer == playEnemySpotedAgainTimerStart)
            {
                EnemySpotedSFX.Play();
                isEnemySpoted = true;
            }
        }
        else if (isFlashLightTurnedOn && flashLightBurnLevel >= flashLightBurnLevelMax)
        {
            isFlashLightTurnedOn = false;
            Darkness.SetActive(true);

            BurnSFX.pitch = Random.Range(0.8f, 1.1f);
            BurnSFX.Play();
        }
        
        if (flashLightRepairTimer > 0 && flashLightBurnLevel >= flashLightBurnLevelMax)
        {
            flashLightRepairTimer -= Time.deltaTime;
        }
        else if (flashLightRepairTimer <= 0 && flashLightBurnLevel >= flashLightBurnLevelMax)
        {
            flashLightRepairTimer = flashLightRepairTimerStart;
            flashLightBurnLevel = 0;
        }

        if(isEnemySpoted)
        {
            playEnemySpotedAgainTimer -= Time.deltaTime;
        }
        else if(playEnemySpotedAgainTimer <= 0)
        {
            isEnemySpoted = false;
            playEnemySpotedAgainTimer = playEnemySpotedAgainTimerStart;
        }
    }

    public void SwitchFlashLightMode()
    {
        if(flashLightBurnLevel < flashLightBurnLevelMax)
        {
            isFlashLightTurnedOn = !isFlashLightTurnedOn;
            Darkness.SetActive(!isFlashLightTurnedOn);

            TurnLightModeSFX.pitch = Random.Range(0.8f, 1.1f);
            TurnLightModeSFX.Play();
        }
    }
}
