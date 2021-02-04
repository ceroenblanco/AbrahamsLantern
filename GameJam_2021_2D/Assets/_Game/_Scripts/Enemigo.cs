using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Rigidbody2D rb;

    public float velocidad;
    [Range(-1, 1)]
    public int dir_x = 0, dir_y = 0;
    public float duracionMov;

    float t = 0;

    private void Update()
    {
        t += Time.deltaTime;

        if (t >= duracionMov)
        {
            t = 0;

            dir_x = -dir_x;
            dir_y = -dir_y;
        }

        rb.MovePosition((Vector2)transform.position + (new Vector2(dir_x, dir_y) * Time.deltaTime));
    }
}
