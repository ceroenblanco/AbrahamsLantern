using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Vida : MonoBehaviour
{
    public GameObject explosion;

    public void RecibirDaño ()
    {
        GameObject go_explo = (GameObject)Instantiate(explosion, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
