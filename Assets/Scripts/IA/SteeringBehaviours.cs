using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteeringBehaviours : MonoBehaviour //Aiudado por ChatGPT
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

    public void Arrive(BasicAgent t_agent)
    {
        float distance = Vector3.Distance(t_agent.transform.position, t_agent.aTarget.transform.position);
        if (distance < t_agent.slowingFactor)
        {
            float speed = Mathf.Lerp(0, t_agent.maxSpeed, distance / t_agent.slowingFactor);
            Vector3 desiredVel = (t_agent.aTarget.transform.position - t_agent.transform.position).normalized * speed;
            Vector3 steering = t_agent.CalculateVelocity(desiredVel);
            t_agent.ApplyBehavior(steering);
        } 
    }

    public void Wander(BasicAgent t_agent, float displacement, float radius)
    {
        Vector3 wanderForce = t_agent.rb.velocity.normalized * displacement + Random.insideUnitSphere * radius;
        Vector3 steering = t_agent.CalculateVelocity(wanderForce.normalized * t_agent.maxSpeed);
        t_agent.ApplyBehavior(steering);
    }

    public void Pursuit(BasicAgent t_agent)
    {
        float T = 3f; // Predict future position in 3 seconds
        Rigidbody targetRb = t_agent.aTarget.GetComponent<Rigidbody>(); // Obtiene el Rigidbody del target
        Vector3 futurePosition = t_agent.aTarget.transform.position + targetRb.velocity * T;
        Vector3 desiredVel = (futurePosition - t_agent.transform.position).normalized * t_agent.maxSpeed;
        Vector3 steering = t_agent.CalculateVelocity(desiredVel);
        t_agent.ApplyBehavior(steering);
        Arrive(t_agent); // Optionally call Arrive to slow down when near target
    }

    public void Evade(BasicAgent t_agent)
    {
        float T = 3f; // Predict future position in 3 seconds
        Rigidbody targetRb = t_agent.aTarget.GetComponent<Rigidbody>(); // Obtiene el Rigidbody del target
        Vector3 futurePosition = t_agent.aTarget.transform.position + targetRb.velocity * T;
        Vector3 desiredVel = (t_agent.transform.position - futurePosition).normalized * t_agent.maxSpeed;
        Vector3 steering = t_agent.CalculateVelocity(desiredVel);
        t_agent.ApplyBehavior(steering);
    }

    /*public void FollowPath(BasicAgent t_agent, PathFollowing path) //Aiuda ChatGPT
    {
        if (path.waypoints.Count == 0) return;

        // Asumir que t_agent tiene un índice actual del waypoint que está siguiendo
        if (t_agent.currentWaypointIndex < 0 || t_agent.currentWaypointIndex >= path.waypoints.Count)
            t_agent.currentWaypointIndex = 0; // reiniciar o iniciar el índice

        Transform targetWaypoint = path.waypoints[t_agent.currentWaypointIndex];
        Seek(t_agent, targetWaypoint); // Usar el comportamiento Seek para moverse hacia el waypoint actual

        // Comprobar si el t_agente está cerca del waypoint para cambiar al siguiente
        if (Vector3.Distance(t_agent.transform.position, targetWaypoint.position) < t_agent.waypointTolerance)
        {
            t_agent.currentWaypointIndex = (t_agent.currentWaypointIndex + 1) % path.waypoints.Count; // pasar al siguiente waypoint, ciclar al principio
        }
    }*/
}
