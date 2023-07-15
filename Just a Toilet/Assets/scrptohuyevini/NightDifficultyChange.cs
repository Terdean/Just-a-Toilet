using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDifficultyChange : MonoBehaviour
{
    public int whichNightIsNow = 0; //Он будет сохраняться только при успешном окончании ночи. Нужно вставить туда PlayerPrefs и конечно же при нажатии новой игры удалять сохранения и загружать первую ночь.

    public GameObject HishniyTolchok;

    public GameObject FtulKot;
    public GameObject Mochanya;
    public GameObject Govnyash;
    public FlashLightScript FlashLightObj;

    public EnemyCharactiristics[] enemyChar;
    public bool[] GovnyashExistence;
    public int[] FlashLightBurnLevelOfMax;

    void Start()
    {
        if (PlayerPrefs.HasKey("NightNum"))
        {
            whichNightIsNow = PlayerPrefs.GetInt("NightNum");
        }
        
        HishniyTolchok.GetComponent<EnemyScript>().chancesToGoBack = enemyChar[0].chancesBack[whichNightIsNow];
        HishniyTolchok.GetComponent<EnemyScript>().chancesToGoCloser = enemyChar[0].chancesCloser[whichNightIsNow];
        HishniyTolchok.GetComponent<EnemyScript>().movementTimerMax = enemyChar[0].moveTimer[whichNightIsNow];
        HishniyTolchok.GetComponent<EnemyScript>().speedOfEnemy = enemyChar[0].enemySpeed[whichNightIsNow];
        HishniyTolchok.GetComponent<EnemyScript>().minSpeedOfEnemy = enemyChar[0].minEnemySpeed[whichNightIsNow];
        HishniyTolchok.GetComponent<EnemyScript>().attackTimer = enemyChar[0].attackSpeed[whichNightIsNow];
        HishniyTolchok.GetComponent<EnemyScript>().attackTimerStart = enemyChar[0].attackSpeed[whichNightIsNow];
        HishniyTolchok.GetComponent<EnemyScript>().goAwayTimer = enemyChar[0].goAwayTimer[whichNightIsNow];
        HishniyTolchok.GetComponent<EnemyScript>().goAwayTimerStart = enemyChar[0].goAwayTimer[whichNightIsNow];
        HishniyTolchok.GetComponent<EnemyScript>().goAwaySpeed = enemyChar[0].goAwaySpeed[whichNightIsNow];
        HishniyTolchok.SetActive(enemyChar[0].doesEnemyExist[whichNightIsNow]);

        FtulKot.GetComponent<EnemyScript>().chancesToGoBack = enemyChar[1].chancesBack[whichNightIsNow];
        FtulKot.GetComponent<EnemyScript>().chancesToGoCloser = enemyChar[1].chancesCloser[whichNightIsNow];
        FtulKot.GetComponent<EnemyScript>().movementTimerMax = enemyChar[1].moveTimer[whichNightIsNow];
        FtulKot.GetComponent<EnemyScript>().speedOfEnemy = enemyChar[1].enemySpeed[whichNightIsNow];
        FtulKot.GetComponent<EnemyScript>().minSpeedOfEnemy = enemyChar[1].minEnemySpeed[whichNightIsNow];
        FtulKot.GetComponent<EnemyScript>().attackTimer = enemyChar[1].attackSpeed[whichNightIsNow];
        FtulKot.GetComponent<EnemyScript>().attackTimerStart = enemyChar[1].attackSpeed[whichNightIsNow];
        FtulKot.GetComponent<EnemyScript>().goAwayTimer = enemyChar[1].goAwayTimer[whichNightIsNow];
        FtulKot.GetComponent<EnemyScript>().goAwayTimerStart = enemyChar[1].goAwayTimer[whichNightIsNow];
        FtulKot.GetComponent<EnemyScript>().goAwaySpeed = enemyChar[1].goAwaySpeed[whichNightIsNow];
        FtulKot.SetActive(enemyChar[1].doesEnemyExist[whichNightIsNow]);

        Mochanya.GetComponent<EnemyScript>().chancesToGoBack = enemyChar[2].chancesBack[whichNightIsNow];
        Mochanya.GetComponent<EnemyScript>().chancesToGoCloser = enemyChar[2].chancesCloser[whichNightIsNow];
        Mochanya.GetComponent<EnemyScript>().movementTimerMax = enemyChar[2].moveTimer[whichNightIsNow];
        Mochanya.GetComponent<EnemyScript>().speedOfEnemy = enemyChar[2].enemySpeed[whichNightIsNow];
        Mochanya.GetComponent<EnemyScript>().minSpeedOfEnemy = enemyChar[2].minEnemySpeed[whichNightIsNow];
        Mochanya.GetComponent<EnemyScript>().attackTimer = enemyChar[2].attackSpeed[whichNightIsNow];
        Mochanya.GetComponent<EnemyScript>().attackTimerStart = enemyChar[2].attackSpeed[whichNightIsNow];
        Mochanya.GetComponent<EnemyScript>().goAwayTimer = enemyChar[2].goAwayTimer[whichNightIsNow];
        Mochanya.GetComponent<EnemyScript>().goAwayTimerStart = enemyChar[2].goAwayTimer[whichNightIsNow];
        Mochanya.GetComponent<EnemyScript>().goAwaySpeed = enemyChar[2].goAwaySpeed[whichNightIsNow];
        Mochanya.SetActive(enemyChar[2].doesEnemyExist[whichNightIsNow]);
        
        Govnyash.SetActive(GovnyashExistence[whichNightIsNow]);
        FlashLightObj.flashLightBurnLevelMax = FlashLightBurnLevelOfMax[whichNightIsNow];
    }
}
