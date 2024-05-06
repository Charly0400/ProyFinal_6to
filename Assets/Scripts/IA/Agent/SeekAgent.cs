using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAgent : BasicAgent
{
    void Update()
    {
        behaviours.Seek(aTarget);
    }
}
