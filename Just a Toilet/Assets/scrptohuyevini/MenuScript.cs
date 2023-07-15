using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public AudioSource buttonSound;

    public void SceneChange(int sceneNum)
    {
        SceneManager.LoadScene(sceneNum);
        buttonSound.pitch = Random.Range(0.7f, 1.1f);
        buttonSound.Play();
    }

    public void Quit()
    {
        Application.Quit();
        buttonSound.pitch = Random.Range(0.7f, 1.1f);
        buttonSound.Play();
    }

    public void StartNewGame()
    {
        PlayerPrefs.DeleteKey("NightNum");
        SceneManager.LoadScene(1);
        buttonSound.pitch = Random.Range(0.7f, 1.1f);
        buttonSound.Play();
    }
}
