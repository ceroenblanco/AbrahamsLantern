using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Vida : MonoBehaviour
{
    public int cantVida;

    public string nombreSonidoPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<Player_Vida>().SumarVida(cantVida);

            FindObjectOfType<AudioManager>().Play(nombreSonidoPickUp);

            gameObject.SetActive(false);
        }
    }
}
