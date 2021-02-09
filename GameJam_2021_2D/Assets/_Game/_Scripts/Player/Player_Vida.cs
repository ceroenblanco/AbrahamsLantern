using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class Player_Vida : MonoBehaviour
{
    public Light2D light;
    public Image img;

    public int vidaInicial, vidaActual, vidaMax;

    public bool invencible;
    public float tiempoInvencible;
    float t_inv = 0;

    private void Start()
    {
        vidaMax = vidaInicial;

        vidaActual = vidaMax;

        light.pointLightOuterRadius = vidaActual;
    }

    private void Update()
    {
        if (img.color.a > 0)
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
        light.pointLightOuterRadius = vidaActual;
    }

    public void SumarVida (int newValor)
    {
        if (newValor > 0)
        {
            vidaActual += newValor;

            img.color = Color.green;

            img.color = new Color(img.color.r, img.color.g, img.color.b, 1);
        }
    }

    public void RestarVida (int newValor)
    {
        if (newValor > 0 && vidaActual > 0)
        {
            vidaActual -= newValor;

            Actualizar_RadioLuz();

            img.color = Color.red;

            img.color = new Color(img.color.r, img.color.g, img.color.b, 1);

            invencible = true;

            if (tiempoInvencible > 0)
                t_inv = tiempoInvencible;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Enemigo") && !invencible)
            RestarVida(1);
    }
}
