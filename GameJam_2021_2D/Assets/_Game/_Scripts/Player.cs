using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;
    public Transform t_linterna;
    public GameObject go_pasos;

    public float velocidad = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = Vector3.zero, rot = t_linterna.rotation.eulerAngles;

        if (Input.GetAxisRaw("Vertical") > 0)
        {
            dir.y = 1;

            rot.z = 0;
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            dir.y = -1;

            rot.z = 180;
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            dir.x = 1;

            rot.z = 270;
        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            dir.x = -1;

            rot.z = 90;
        }

        if (dir.x != 0 || dir.y != 0)
        {
            t_linterna.rotation = Quaternion.Euler(rot);

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
