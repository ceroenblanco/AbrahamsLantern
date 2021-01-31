using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSwitch_ctrl : MonoBehaviour
{
    public DoorSwitch[] switchs;

    public UnityEvent OnActivate;

    public void Activar ()
    {
        foreach (var door in switchs)
        {
            if (!door.on_off)
            {
                return;
            }
        }

        OnActivate.Invoke();
    }
}
