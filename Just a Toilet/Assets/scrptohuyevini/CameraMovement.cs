using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject cameraObj;
    public float CamPos = 0;

    public GameObject UpButton;
    public GameObject DownButton;

    public GameObject UpUI;
    public GameObject DaunUI;
    public GameObject FrontUI;

    void Update()
    {
        if (CamPos == 1)
        {
            UpButton.SetActive(false);

            UpUI.SetActive(true);
            DaunUI.SetActive(false);
            FrontUI.SetActive(false);
        }
        else if (CamPos == 0)
        {
            UpButton.SetActive(true);
            DownButton.SetActive(true);

            UpUI.SetActive(false);
            DaunUI.SetActive(false);
            FrontUI.SetActive(true);
        }
        else if (CamPos == -1)
        {
            DownButton.SetActive(false);

            UpUI.SetActive(false);
            DaunUI.SetActive(true);
            FrontUI.SetActive(false);
        }
    }

    public void lookUp()
    {
        cameraObj.transform.position = cameraObj.transform.position + new Vector3(0, 26);
        CamPos++;
    }

    public void loodDown()
    {
        cameraObj.transform.position = cameraObj.transform.position - new Vector3(0, 26);
        CamPos--;
    }
}
