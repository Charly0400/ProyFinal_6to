using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class TerritoryAgent : BasicAgent
{
    [SerializeField] AgressiveAgentStates agentState;
    string currentAnimationStateName;
    [SerializeField] Rigidbody rb;
    bool enemyInTerrytory = false;
    Animator animator;

    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agentState = AgressiveAgentStates.Idle;
        currentAnimationStateName = "";
    }

    void Update() {
        decisionManager();
    }

    void decisionManager() {
        AgressiveAgentStates newState;
        if (target == null) {
            newState = AgressiveAgentStates.Idle;
        }
        else if (enemyInTerrytory) {
            newState = AgressiveAgentStates.Seeking;
            if (Vector3.Distance(transform.position, target.position) < stopThreshold) {
                newState = AgressiveAgentStates.Attack;
            }
        }
        else {
            newState = AgressiveAgentStates.Returning;
        }
        changeAgentState(newState);
        movementManager();
    }

    void changeAgentState(AgressiveAgentStates t_newState) {
        if (agentState == t_newState) {
            return;
        }
        agentState = t_newState;
    }

    void movementManager() {
        switch (agentState) {
            case AgressiveAgentStates.Idle:
                idle();
                break;
            case AgressiveAgentStates.Seeking:
                pursuiting();
                break;
            case AgressiveAgentStates.Attack:
                attacking();
                break;
            case AgressiveAgentStates.Returning:
                returning();
                break;
        }
    }

    private void  pursuiting () {
        maxVel *= 2;
        rb.velocity = SteeringBehaviours.seek(this, target.position);
        rb.velocity = SteeringBehaviours.arrival(this, target.position, slowingRadius, stopThreshold);
        if (Vector3.Distance(transform.position, target.position) <= slowingRadius)
        {
            if (!currentAnimationStateName.Equals("walk"))
            {
                animator.Play("Crocodile_Walk 0", 0);
                currentAnimationStateName = "walk";
            }
        }
        maxVel /= 2;
    }

    private void attacking() {
        if (!currentAnimationStateName.Equals("attack")) {
            animator.Play("Crocodile_Attack_1 0", 0);
            currentAnimationStateName = "attack";
        }
    }

    private void idle() {
        if (!currentAnimationStateName.Equals("idle")) {
            animator.Play("Crocodile_Idle 0", 0);
            currentAnimationStateName = "idle";
        }
        rb.velocity = Vector3.zero;
    }

    private void returning() {
        if (!currentAnimationStateName.Equals("walk")) {
            animator.Play("Crocodile_Walk 0", 0);
            currentAnimationStateName = "walk";
        }
        rb.velocity = SteeringBehaviours.seek(this, target.position);
        if (Vector3.Distance(transform.position, target.position) <= slowingRadius) {
            target = null;
        }
    }

    public void isEnemyInside() {
        enemyInTerrytory = !enemyInTerrytory;
    }

    public void setTarget(Transform t_target) {
        target = t_target;
    }

    private enum AgressiveAgentStates {
        Idle,
        Seeking,
        Attack,
        Returning
    }
}
