using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    public Animator portal_animator;
    public Animator door_animator;
    public GameObject portal;
    public void OpenTheWaaay()
    {
        portal.SetActive(true);
        portal_animator.Play("Open");
        portal_animator.Play("door_3_open");
        Debug.Log("Open");
    }
    

}
