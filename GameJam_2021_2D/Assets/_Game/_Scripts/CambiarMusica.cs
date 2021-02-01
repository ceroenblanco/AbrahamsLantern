using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarMusica : MonoBehaviour
{
    public AudioManager audioManager;
    public string str_Sonido;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && !string.IsNullOrEmpty(str_Sonido))
        {
            FindObjectOfType<AudioManager>().Play(str_Sonido);
        }

        gameObject.SetActive(false);
    }
}
