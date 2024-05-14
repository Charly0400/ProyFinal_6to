using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    public Animator portal_animator;
    public Animator door_animator;
    public GameObject portal, trofeo;
    public void OpenTheWaaay()
    {
        Debug.Log("Open");
        portal.SetActive(true);
        trofeo.SetActive(true);
        portal_animator.Play("Open_LaserPortal_1");
        Debug.Log(portal_animator);
        door_animator.Play("Open_Laser");
        Debug.Log(door_animator);
    }
    

}
