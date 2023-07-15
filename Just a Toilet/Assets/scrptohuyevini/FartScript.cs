using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FartScript : MonoBehaviour
{
    public AudioSource Fart;

    public void ToFart()
    {
        Fart.Play();
    }    
}
