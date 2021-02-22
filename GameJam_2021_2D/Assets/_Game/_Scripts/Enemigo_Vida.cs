using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Vida : MonoBehaviour
{
    public GameObject explosion;

    Enemigo enemigo;

    private void Start()
    {
        enemigo = GetComponent<Enemigo>();
    }

    public void RecibirDaño ()
    {
        //GameObject go_explo = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);

        //Destroy(gameObject);

        if (!enemigo.incapacitado)
            enemigo.Incapacitar();
    }
}
