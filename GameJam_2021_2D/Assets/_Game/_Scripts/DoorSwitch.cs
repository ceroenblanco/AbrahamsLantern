using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSwitch : MonoBehaviour
{
    public DoorSwitch_ctrl door_ctrl;
    public bool on_off = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player") && !on_off)
        {
            on_off = true;

            door_ctrl.Activar();
        }
    }
}
