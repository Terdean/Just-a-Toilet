using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CreditsScript : MonoBehaviour
{
    public Vector3 StartPos;
    public Vector3 FinalPos;

    public float speedOfText;

    private void Start()
    {
        transform.position = new Vector3(StartPos.x, StartPos.y);
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(FinalPos.x, FinalPos.y, 0), speedOfText);
        if(transform.position == FinalPos)
        {
            transform.position = StartPos;
        }
    }
}
