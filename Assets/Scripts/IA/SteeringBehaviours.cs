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

    /*public void FollowPath(BasicAgent agent, Path path)
    {
        if (path.waypoints.Count == 0) return;

        // Asumir que agent tiene un índice actual del waypoint que está siguiendo
        if (agent.currentWaypointIndex < 0 || agent.currentWaypointIndex >= path.waypoints.Count)
            agent.currentWaypointIndex = 0; // reiniciar o iniciar el índice

        Transform targetWaypoint = path.waypoints[agent.currentWaypointIndex];
        Seek(agent, targetWaypoint); // Usar el comportamiento Seek para moverse hacia el waypoint actual

        // Comprobar si el agente está cerca del waypoint para cambiar al siguiente
        if (Vector3.Distance(agent.transform.position, targetWaypoint.position) < agent.waypointTolerance)
        {
            agent.currentWaypointIndex = (agent.currentWaypointIndex + 1) % path.waypoints.Count; // pasar al siguiente waypoint, ciclar al principio
        }
    }*/
}
