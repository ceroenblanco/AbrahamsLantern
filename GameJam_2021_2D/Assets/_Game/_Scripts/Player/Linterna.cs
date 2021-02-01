using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Linterna : MonoBehaviour
{
    public GameObject linterna;

    public Slider slr;

    public float velDescarga;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            linterna.SetActive(!linterna.activeSelf);

            slr.gameObject.SetActive(!slr.gameObject.activeSelf);

            if (linterna.activeSelf)
                slr.value = slr.maxValue;
        }

        if (slr.gameObject.activeSelf)
        {
            slr.value -= (velDescarga * Time.deltaTime);
        }
    }
}
