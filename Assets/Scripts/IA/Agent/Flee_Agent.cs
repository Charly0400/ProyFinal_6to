using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee_Agent : BasicAgent
{ 
    void Update()
    {
        behaviours.Flee(aTarget);
    }
}
