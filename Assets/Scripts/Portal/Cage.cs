using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    public Animator portal_Animator;

    public int CubesNecesary;


    // Update is called once per frame
    void Update()
    {
        if (Container.cubes == CubesNecesary)
        {
            portal_Animator.Play("Open_PortalsPorta_1l");
            gameObject.SetActive(false);
            
        }
    }
}
