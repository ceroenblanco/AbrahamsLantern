﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PickUp : MonoBehaviour
{
    public Animator anim;

    public UnityEvent OnPickUp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            OnPickUp.Invoke();

            gameObject.SetActive(false);

            anim.SetFloat("Linterna", 1);
        }
    }
}
