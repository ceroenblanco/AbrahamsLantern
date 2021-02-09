using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Detonador : MonoBehaviour
{
    public bool destroyOnTrigger = false;

    public UnityEvent accion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            accion.Invoke();

            if (destroyOnTrigger)
                gameObject.SetActive(false);
        }
    }
}
