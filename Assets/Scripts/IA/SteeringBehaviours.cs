using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour 
{
    public void Seek(BasicAgent t_agent)
    {
        Vector3 desiredVel = (t_agent.aTarget.transform.position - t_agent.transform.position).normalized * t_agent.maxSpeed;
        Vector3 steering = t_agent.CalculateVelocity(desiredVel);
        t_agent.ApplyBehavior(steering);
    }

    public void Flee(BasicAgent t_agent)
    {
        Vector3 desiredVel = (t_agent.transform.position - t_agent.aTarget.transform.position).normalized * t_agent.maxSpeed;
        Vector3 steering = t_agent.CalculateVelocity(desiredVel);
        t_agent.ApplyBehavior(steering);
    }

    
}
