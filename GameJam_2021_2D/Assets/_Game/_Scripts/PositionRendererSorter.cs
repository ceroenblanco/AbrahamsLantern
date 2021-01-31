using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRendererSorter : MonoBehaviour
{
    public Renderer renderer;
    [SerializeField]
    int sortingOrderBase = 5000;
    [SerializeField]
    int offset = 0;

    private void LateUpdate()
    {
        renderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
    }
}
