using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class Player_Vida : MonoBehaviour
{
    public Light2D light;

    public int vidaInicial, vidaActual, vidaMax;

    private void Start()
    {
        vidaMax = vidaInicial;

        vidaActual = vidaMax;

        light.pointLightOuterRadius = vidaActual;
    }

    public void RestarVida (int newValor)
    {
        if (newValor > 0)
        {
            vidaActual -= newValor;

            light.pointLightOuterRadius = vidaActual;
        }
    }
}
