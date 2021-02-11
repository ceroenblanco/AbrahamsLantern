using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Linterna linterna;
    public Animator anim;
    public GameObject go_signo, go_pasos;

    public float velocidad = 1;
    [Space]
    public UnityEvent OnActive;
    public UnityEvent OnDeactive;

    private void Start()
    {
        OnActive.AddListener(delegate { LinternaOn(); });
        OnDeactive.AddListener(delegate { LinternaOff(); });
    }

    void Update()
    {
        Vector3 dir = Vector3.zero;

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            dir.y = 1;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            dir.y = -1;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            dir.x = 1;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            dir.x = -1;
        }

        if (dir.x != 0 || dir.y != 0)
        {
            rb.MovePosition(transform.position + dir * (velocidad * Time.deltaTime));

            if (!go_pasos.activeSelf)
                go_pasos.SetActive(true);

            anim.SetFloat("y", dir.y);
            anim.SetFloat("x", dir.x);

            anim.SetBool("EnMovimiento", true);
        }
        else
        {
            if (go_pasos.activeSelf)
                go_pasos.SetActive(false);

            anim.SetBool("EnMovimiento", false);
        }
    }

    void LinternaOn ()
    {
        if (anim.GetFloat("Linterna") > 0)
            linterna.enabled = true;
    }

    void LinternaOff ()
    {
        if (anim.GetFloat("Linterna") > 0)
            linterna.enabled = false;
    }

    public void Actualizar_Signo (bool newBool)
    {
        go_signo.SetActive(newBool);
    }
}