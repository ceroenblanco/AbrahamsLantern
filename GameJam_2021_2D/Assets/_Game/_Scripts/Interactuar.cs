using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactuar : MonoBehaviour
{
    public Player player;

    public bool activado = false, playerEnArea;

    public UnityEvent OnActivate;

    private void Update()
    {
        if (!activado && playerEnArea && Input.GetButtonDown("Jump"))
        {
            activado = true;

            OnActivate.Invoke();

            player.go_signo.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerEnArea = true;

            player = collision.transform.GetComponent<Player>();

            if (!activado)
                player.go_signo.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player == null && collision.transform.CompareTag("Player"))
        {
            playerEnArea = true;

            player = collision.transform.GetComponent<Player>();

            if (!activado)
                player.go_signo.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerEnArea = false;

            if (!activado)
                player.go_signo.SetActive(false);
        }
    }
}
