using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Antorcha : MonoBehaviour
{
    public SpriteRenderer rend;
    public Sprite on;

    public void On ()
    {
        rend.sprite = on;
    }
}
