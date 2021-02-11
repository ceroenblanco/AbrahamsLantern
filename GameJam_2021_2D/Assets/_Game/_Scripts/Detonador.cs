using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detonador : MonoBehaviour
{
    public bool destroyOnTrigger = false;
    public int usos;

    public UnityEvent accion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (usos > 0 && collision.transform.CompareTag("Player"))
        {
            print($"{transform.name} activado");

            usos--;

            accion.Invoke();

            if (destroyOnTrigger)
                gameObject.SetActive(false);
        }
    }
}
