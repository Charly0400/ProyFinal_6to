using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way : MonoBehaviour
{
    public Looked door;
    public Looked door2;

    public void OpenTheWaaay()
    {
       door.OpenLock();
        door2.OpenLock();
        
    }
    
}
