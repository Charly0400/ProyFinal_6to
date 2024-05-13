using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    public int CubesNecesary;


    // Update is called once per frame
    void Update()
    {
        if (Container.cubes == CubesNecesary)
        {
            
            gameObject.SetActive(false);
            
        }
    }
}
