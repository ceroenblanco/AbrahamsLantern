﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using UnityEngine.EventSystems;

public class Linterna : MonoBehaviour
{
    public Vector2 dir;

    public Light2D linternaArriba;  // Emisor de luz que ignora la capa "Player" cuando el jugador mira hacia arriba
    public Light2D linternaDemas;   // Emisor de luz que afecta a todas las capas cuando el jugador mira hacia la derecha, izquierda o hacia abajo

    public Slider slr;

    public float velDescarga;

    public bool encendida;

    public Transform posAbajo, posIzquierda, posDerecha;

    public AudioSource audioSource;

    private void Start()
    {
        linternaDemas.gameObject.SetActive(encendida);

        //slr.gameObject.SetActive(encendida);

        if (slr != null)
            slr.value = slr.maxValue;
    }

    private void Update()
    {
        Vector3 newRot = linternaDemas.transform.rotation.eulerAngles; ;

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            dir.x = 0;
            dir.y = 1;

            if (encendida)
            {
                linternaDemas.gameObject.SetActive(false);
                linternaArriba.gameObject.SetActive(true);
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            dir.x = 0;
            dir.y = -1;

            linternaDemas.transform.position = posAbajo.position;

            newRot.z = 180;
            linternaDemas.transform.rotation = Quaternion.Euler(newRot);

            if (encendida)
            {
                linternaArriba.gameObject.SetActive(false);
                linternaDemas.gameObject.SetActive(true);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            dir.x = 1;
            dir.y = 0;

            linternaDemas.transform.position = posDerecha.position;

            newRot.z = 270;
            linternaDemas.transform.rotation = Quaternion.Euler(newRot);

            if (encendida)
            {
                linternaArriba.gameObject.SetActive(false);
                linternaDemas.gameObject.SetActive(true);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            dir.x = -1;
            dir.y = 0;

            linternaDemas.transform.position = posIzquierda.position;

            newRot.z = 90;
            linternaDemas.transform.rotation = Quaternion.Euler(newRot);

            if (encendida)
            {
                linternaArriba.gameObject.SetActive(false);
                linternaDemas.gameObject.SetActive(true);
            }
        }
        //-------------------------------------------------------------------------------------------------
        if (Input.GetMouseButtonDown(0))
        {
            EventSystem eventSystem = EventSystem.current;

            if (!eventSystem.IsPointerOverGameObject())
            {
                audioSource.Play();

                encendida = !encendida;

                if (dir.y > 0)
                    linternaArriba.gameObject.SetActive(encendida);
                else
                    linternaDemas.gameObject.SetActive(encendida);

                //slr.gameObject.SetActive(encendida);

                //if (!encendida)
                //    slr.value = slr.maxValue;
            }
        }


        if (encendida)
        {
            if (slr != null)
                slr.value -= (velDescarga * Time.deltaTime);

            if (slr != null && slr.value <= 0)
            {
                encendida = false;

                if (dir.y > 0)
                    linternaArriba.gameObject.SetActive(encendida);
                else
                    linternaDemas.gameObject.SetActive(encendida);

                //slr.gameObject.SetActive(encendida);

                //slr.value = slr.maxValue;
            }
        }
        else if (slr != null && slr.value < slr.maxValue)
        {
            slr.value += ((velDescarga * 2) * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        int layer = LayerMask.GetMask("Player");

        layer = ~layer;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, linternaDemas.pointLightOuterRadius, layer);

        if (hit.collider != null)
        {
            print($"{hit.collider.transform.name}");

            if (encendida)
            {
                if (hit.collider.transform.GetComponent<Enemigo_Vida>())
                    hit.collider.transform.GetComponent<Enemigo_Vida>().RecibirDaño();
            }

            Debug.DrawLine(transform.position, hit.point, Color.yellow);
        }
        else
        {
            Debug.DrawRay(transform.position, dir * linternaDemas.pointLightOuterRadius, Color.yellow); 
        }
    }
}
