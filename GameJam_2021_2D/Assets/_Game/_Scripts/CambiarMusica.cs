using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarMusica : MonoBehaviour
{
    public AudioManager audioManager;
    public string musicaSiguiente, musicaAnterior;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && !string.IsNullOrEmpty(musicaSiguiente))
        {
            if (audioManager == null)
            {
                audioManager = FindObjectOfType<AudioManager>();
            }

            if (audioManager != null)
            {
                audioManager.Stop(musicaAnterior);

                audioManager.Play(musicaSiguiente);

                FindObjectOfType<Ctrl_Main>().nombreMusicaActual = musicaSiguiente;
            }
        }

        gameObject.SetActive(false);
    }
}
