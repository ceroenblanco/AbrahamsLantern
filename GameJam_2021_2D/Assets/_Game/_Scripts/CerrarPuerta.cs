using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerrarPuerta : MonoBehaviour
{
    public GameObject puerta;

    public bool activado;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!activado)
        {
            puerta.SetActive(true);

            activado = true;
        }
    }
}
