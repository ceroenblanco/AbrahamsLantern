using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum tipoSwitch { apagar, encender}

public class BG_Switch : MonoBehaviour
{
    public GameObject bg;

    public tipoSwitch tipo;

    public string str_sonidoCerrar, str_sonidoAbrir;

    AudioManager audioManager;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            switch (tipo)
            {
                case tipoSwitch.apagar:
                    if (bg.activeSelf)
                    {
                        bg.SetActive(false);

                        if (!string.IsNullOrEmpty(str_sonidoCerrar))
                        {
                            if (!audioManager)
                                audioManager = FindObjectOfType<AudioManager>();

                            if (audioManager)
                                audioManager.Play(str_sonidoCerrar);
                        }
                    }
                    break;
                case tipoSwitch.encender:
                    if (!bg.activeSelf)
                    {
                        bg.SetActive(true);

                        if (!string.IsNullOrEmpty(str_sonidoAbrir))
                        {
                            if (!audioManager)
                                audioManager = FindObjectOfType<AudioManager>();

                            if (audioManager)
                                audioManager.Play(str_sonidoAbrir);
                        }
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
