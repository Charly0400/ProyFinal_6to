using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : MonoBehaviour
{
    public static int cubes;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Rocks")
        {
            cubes++;
            Debug.Log(cubes);
            Destroy(gameObject);

        }
    }


}
