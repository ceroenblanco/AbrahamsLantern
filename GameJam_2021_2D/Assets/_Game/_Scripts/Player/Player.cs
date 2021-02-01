using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public GameObject t_linterna1, t_linterna2, t_linterna3, t_linterna4;
    public GameObject go_pasos;

    public float velocidad = 1;

    void Update()
    {
        Vector3 dir = Vector3.zero/*, rot = t_linterna.rotation.eulerAngles*/;

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            dir.y = 1;

            //rot.z = 0;

            if (!t_linterna1.activeSelf)
            {
                t_linterna2.SetActive(false);
                t_linterna3.SetActive(false);
                t_linterna4.SetActive(false);

                t_linterna1.SetActive(true);
            }
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            dir.y = -1;

            //rot.z = 180;

            if (!t_linterna2.activeSelf)
            {
                t_linterna1.SetActive(false);
                t_linterna3.SetActive(false);
                t_linterna4.SetActive(false);

                t_linterna2.SetActive(true);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            dir.x = 1;

            //rot.z = 270;

            if (!t_linterna3.activeSelf)
            {
                t_linterna1.SetActive(false);
                t_linterna2.SetActive(false);
                t_linterna4.SetActive(false);

                t_linterna3.SetActive(true);
            }
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            dir.x = -1;

            //rot.z = 90;

            if (!t_linterna4.activeSelf)
            {
                t_linterna1.SetActive(false);
                t_linterna2.SetActive(false);
                t_linterna3.SetActive(false);

                t_linterna4.SetActive(true);
            }
        }

        if (dir.x != 0 || dir.y != 0)
        {
            //t_linterna.rotation = Quaternion.Euler(rot);

            rb.MovePosition(transform.position + (dir * velocidad/* * Time.deltaTime*/));

            if (!go_pasos.activeSelf)
                go_pasos.SetActive(true);
        }
        else
        {
            if (go_pasos.activeSelf)
                go_pasos.SetActive(false);
        }

        anim.SetFloat("y", dir.y);
        anim.SetFloat("x", dir.x);
    }
}
