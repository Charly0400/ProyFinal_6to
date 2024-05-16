using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        // Dibuja un cubo de wireframe usando el tamaño y posición del collider del cubo
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            Gizmos.DrawWireCube(transform.position + boxCollider.center, boxCollider.transform.localScale);
        }
    }
}
