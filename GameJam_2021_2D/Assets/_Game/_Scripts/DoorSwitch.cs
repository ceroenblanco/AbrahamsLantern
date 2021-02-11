using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public DoorSwitch_ctrl door_ctrl;
    public AudioSource audioSource;
    public bool on_off = false, playerEnRango = false;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (!on_off && playerEnRango && Input.GetButtonDown("Jump"))
        {
            on_off = true;

            door_ctrl.Activar();

            player.Actualizar_Signo(false);

            audioSource.Play();
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.transform.CompareTag("Player") && !on_off)
    //    {
    //        on_off = true;

    //        door_ctrl.Activar();
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!on_off && collision.transform.CompareTag("Player"))
        {
            playerEnRango = true;

            player.Actualizar_Signo(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!on_off && collision.transform.CompareTag("Player"))
        {
            playerEnRango = true;

            player.Actualizar_Signo(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            playerEnRango = false;

            player.Actualizar_Signo(false);
        }
    }
}
