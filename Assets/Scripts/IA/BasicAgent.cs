using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAgent : MonoBehaviour
{
    public BasicAgent aTarget;
    public Rigidbody rb;
    public float maxSpeed = 5f;
    public float maxForce = 10f;
    public float slowingFactor = 0.5f;
    public float mass = 1f;

    [System.NonSerialized] public SteeringBehaviours behaviours;

    [SerializeField] Vector3 eyesposition; 
    [SerializeField] float eyesRadius;

    void Start()
    {
        behaviours = new SteeringBehaviours();
    }

    void FixedUpdate()
    {
        perceptionManager();
    }

    void perceptionManager()
    {
        eyesPerception();
        earsPerception();
    }

    void eyesPerception()
    {
        Collider[] agentsViewed = Physics.OverlapSphere(eyesposition, eyesRadius);
        foreach (Collider agent in agentsViewed)
        {
            if (agent.CompareTag("Agent"))
            {

            }
        }
    }

    void earsPerception()
    {

    }

    public Vector3 CalculateVelocity(Vector3 desiredVelocity)
    {
        Vector3 steering = desiredVelocity - rb.velocity;
        steering = Vector3.ClampMagnitude(steering, maxForce);
        steering /= mass;
        return Vector3.ClampMagnitude(rb.velocity + steering, maxSpeed);
    }

    public void ApplyBehavior(Vector3 force)
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(force);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(eyesposition, eyesRadius);
    }

}
