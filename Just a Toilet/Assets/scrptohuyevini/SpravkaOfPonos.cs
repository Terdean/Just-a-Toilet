using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpravkaOfPonos : MonoBehaviour
{
    public GameObject Spravka; // ������� ���� �� ���� ������ �������� �������, �� ������� �������� ������ �� ��������. ��� �� ������� ������ ���� ���� ���� ������, ��� ���� �������� �� ������ - �� ����� ������ ����.

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
