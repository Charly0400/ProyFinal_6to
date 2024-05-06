using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour //Aiudado por ChatGPT
{
    public void Seek(BasicAgent agent)
    {
        Vector3 desiredVelocity = (agent.aTarget.transform.position - agent.transform.position).normalized * agent.maxSpeed;
        Vector3 steeringForce = agent.CalculateVelocity(desiredVelocity);
        agent.ApplyBehavior(steeringForce);
    }

    public void Flee(BasicAgent agent)
    {
        Vector3 desiredVelocity = (agent.transform.position - agent.aTarget.transform.position).normalized * agent.maxSpeed;
        Vector3 steeringForce = agent.CalculateVelocity(desiredVelocity);
        agent.ApplyBehavior(steeringForce);
    }

    public void Arrive(BasicAgent agent)
    {
        float distance = Vector3.Distance(agent.transform.position, agent.aTarget.transform.position);
        if (distance < agent.slowingFactor)
        {
            float speed = Mathf.Lerp(0, agent.maxSpeed, distance / agent.slowingFactor);
            Vector3 desiredVelocity = (agent.aTarget.transform.position - agent.transform.position).normalized * speed;
            Vector3 steeringForce = agent.CalculateVelocity(desiredVelocity);
            agent.ApplyBehavior(steeringForce);
        } 
    }

    public void Wander(BasicAgent agent, float displacement, float radius)
    {
        Vector3 wanderForce = agent.rb.velocity.normalized * displacement + Random.insideUnitSphere * radius;
        Vector3 steeringForce = agent.CalculateVelocity(wanderForce.normalized * agent.maxSpeed);
        agent.ApplyBehavior(steeringForce);
    }

    public void Pursuit(BasicAgent agent)
    {
        float T = 3f; // Predict future position in 3 seconds
        Rigidbody targetRb = agent.aTarget.GetComponent<Rigidbody>(); // Obtiene el Rigidbody del target
        Vector3 futurePosition = agent.aTarget.transform.position + targetRb.velocity * T;
        Vector3 desiredVelocity = (futurePosition - agent.transform.position).normalized * agent.maxSpeed;
        Vector3 steeringForce = agent.CalculateVelocity(desiredVelocity);
        agent.ApplyBehavior(steeringForce);
        Arrive(agent); // Optionally call Arrive to slow down when near target
    }

    public void Evade(BasicAgent agent)
    {
        float T = 3f; // Predict future position in 3 seconds
        Rigidbody targetRb = agent.aTarget.GetComponent<Rigidbody>(); // Obtiene el Rigidbody del target
        Vector3 futurePosition = agent.aTarget.transform.position + targetRb.velocity * T;
        Vector3 desiredVelocity = (agent.transform.position - futurePosition).normalized * agent.maxSpeed;
        Vector3 steeringForce = agent.CalculateVelocity(desiredVelocity);
        agent.ApplyBehavior(steeringForce);
    }
}
