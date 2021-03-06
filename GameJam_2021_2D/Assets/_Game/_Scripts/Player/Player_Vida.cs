﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class Player_Vida : MonoBehaviour
{
    public Light2D luz;
    public Image img;
    public Slider sldr_vida;

    public int vidaInicial, vidaActual, vidaMax;

    public bool invencible;
    public float tiempoInvencible;
    float t_inv = 0;

    private void Start()
    {
        vidaMax = vidaInicial;

        vidaActual = vidaMax;

        luz.pointLightOuterRadius = vidaActual;

        sldr_vida.maxValue = vidaMax;
        Actualizar_BarraVida(vidaActual);
    }

    private void Update()
    {
        if (img != null && img.color.a > 0)
        {
            Color newColor = img.color;

            newColor.a -= 5 * Time.deltaTime;

            img.color = newColor;
        }

        if (invencible && t_inv > 0)
        {
            t_inv -= Time.deltaTime;

            if (t_inv <= 0)
            {
                invencible = false;
            }
        }
    }

    void Actualizar_RadioLuz ()
    {
        luz.pointLightOuterRadius = vidaActual;
    }

    void Actualizar_BarraVida (int newValor)
    {
        sldr_vida.value = newValor;
    }

    public void SumarVida (int newValor)
    {
        if (newValor > 0 && vidaActual < vidaMax)
        {
            vidaActual += newValor;

            if (vidaActual > vidaMax)
                vidaActual = vidaMax;

            if (img != null)
            {
                img.color = Color.green;

                img.color = new Color(img.color.r, img.color.g, img.color.b, .5f);
            }

            Actualizar_BarraVida(vidaActual);
            Actualizar_RadioLuz();
        }
    }

    public void RestarVida (int newValor)
    {
        if (newValor > 0 && vidaActual > 0)
        {
            vidaActual -= newValor;

            Actualizar_BarraVida(vidaActual);
            Actualizar_RadioLuz();

            if (vidaActual <= 0)
            {
                FindObjectOfType<Ctrl_Main>().GameOver();
            }
            else
            {
                if (img != null)
                {
                    img.color = Color.red;

                    img.color = new Color(img.color.r, img.color.g, img.color.b, .5f);
                }

                invencible = true;

                if (tiempoInvencible > 0)
                    t_inv = tiempoInvencible;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemigo") && !invencible)
            RestarVida(1);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemigo") && !invencible)
            RestarVida(1);
    }
}
