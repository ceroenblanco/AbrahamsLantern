using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactuable_PuertaPadres : MonoBehaviour
{
    public bool activado = false;

    public Interactuable_PuertaPadres otraPuerta;

    public AudioSource audioSource;

    public void Activar ()
    {
        if (!activado)
        {
            activado = true;

            if (otraPuerta.activado)
            {
                audioSource.Play();
            }
        }
    }
}
