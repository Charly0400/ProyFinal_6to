using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wander_Agent : BasicAgent
{
    [SerializeField] private float displacement;
    [SerializeField] private float radius;
    void Update()
    {
        //behaviours.Wander(aTarget, displacement, radius);
    }
}
