using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject Camera;
    public float[] CameraPositionsX;
    public float[] CameraPositionsY;
    private int OnWhichCamera;
    private bool isCamerasOn = false;

    public GameObject CamerasMap;
    public GameObject NotCamerasUI;

    public AudioSource cameraChangeSound;

    public CameraMovement cameraMovement;

    public void TurnCamerasOn()
    {
        if (!isCamerasOn)
        {
            isCamerasOn = true;
            NotCamerasUI.SetActive(false);
        }
        else
        {
            isCamerasOn = false;
            NotCamerasUI.SetActive(true);
            Camera.transform.position = new Vector3(0, 26 * cameraMovement.CamPos, -10);
        }

        if (isCamerasOn)
        {
            CamerasMap.SetActive(true);
            Camera.transform.position = new Vector3(CameraPositionsX[OnWhichCamera], CameraPositionsY[OnWhichCamera], -10);
        }
        else
        {
            CamerasMap.SetActive(false);
        }

        cameraChangeSound.pitch = Random.Range(0.7f, 1.1f);
        cameraChangeSound.Play();
    }

    public void MoveCamera(int WhichCamera)
    {
        OnWhichCamera = WhichCamera;

        if (isCamerasOn)
        {
            CamerasMap.SetActive(true);
            Camera.transform.position = new Vector3(CameraPositionsX[OnWhichCamera], CameraPositionsY[OnWhichCamera], -10);
        }
        else
        {
            CamerasMap.SetActive(false);
        }

        cameraChangeSound.pitch = Random.Range(0.7f, 1.1f);
        cameraChangeSound.Play();
    }
}
