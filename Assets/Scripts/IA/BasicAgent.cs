using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAgent : MonoBehaviour
{
    SteeringBehaviours behaviours;

    [SerializeField] Vector3 eyesposition;
    [SerializeField] float eyesRadius;

    void Start() {
        behaviours = new SteeringBehaviours();
    }

    void FixedUpdate() {
        perceptionManager();
    }

    void perceptionManager() {
        eyesPerception();
        earsPerception();
    }

    void eyesPerception() {
        Collider[] agentsViewed = Physics.OverlapSphere(eyesposition, eyesRadius);
        foreach (Collider agent in agentsViewed) {
            if (agent.CompareTag("Agent")) {

            }
        }
    }

    void earsPerception() {

    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(eyesposition, eyesRadius);
    }

}
