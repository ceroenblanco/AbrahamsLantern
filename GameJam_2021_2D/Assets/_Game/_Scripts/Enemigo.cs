using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator anim;

    public float velocidad;
    [Range(-1, 1)]
    public int dir_x = 0, dir_y = 0;
    public float duracionMov;

    float t = 0;

    private void Start()
    {
        Actualizar_Anim();
    }

    private void Update()
    {
        t += Time.deltaTime;

        if (t >= duracionMov)
        {
            t = 0;

            dir_x = -dir_x;
            dir_y = -dir_y;

            Actualizar_Anim();
        }

        rb.MovePosition((Vector2)transform.position + (new Vector2(dir_x, dir_y) * velocidad * Time.deltaTime));
    }

    void Actualizar_Anim ()
    {
        anim.SetFloat("Dir x", dir_x);
        anim.SetFloat("Dir y", dir_y);
    }
}
