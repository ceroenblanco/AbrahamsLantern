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
            Player_Vida playerVida = collision.transform.GetComponent<Player_Vida>();

            if (playerVida != null && playerVida.vidaActual < playerVida.vidaMax)
            {
                playerVida.SumarVida(cantVida);

                FindObjectOfType<AudioManager>().Play(nombreSonidoPickUp);

                gameObject.SetActive(false);
            }

        }
    }
}
