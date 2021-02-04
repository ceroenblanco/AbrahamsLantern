using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject go_pasos;

    public float velocidad = 1;

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
}