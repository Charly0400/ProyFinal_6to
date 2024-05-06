using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee_Agent : BasicAgent
{ 
    public void Update()
    {
        behaviours.Flee(aTarget);
    }
}
