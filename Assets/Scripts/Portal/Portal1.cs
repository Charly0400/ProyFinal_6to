using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal1 : MonoBehaviour
{
    public Animator animatorPortal;
    [SerializeField] private Animator animatorDoor;
    public void Portal_ON()
    {
        animatorPortal.Play("Open");
        animatorPortal.Play("door_3_open");
        Debug.Log("Ok");

    }

}
