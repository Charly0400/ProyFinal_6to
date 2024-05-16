using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Animator))]

public class EscapeAgent : BasicAgent
{
    [SerializeField] float eyesPerceptRadious, earsPerceptRadious;
    [SerializeField] Transform eyesPercept, earsPercept;
    [SerializeField] AgressiveAgentStates agentState;
    [SerializeField] Rigidbody rb;
    Collider[] perceibed, perceibed2;
    string currentAnimationStateName;
    Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        agentState = AgressiveAgentStates.Idle;
        currentAnimationStateName = "";
    }

    void Update()
    {
        perceptionManager();
        decisionManager();
    }

    void FixedUpdate()
    {
        perceibed = Physics.OverlapSphere(eyesPercept.position, eyesPerceptRadious);
        perceibed2 = Physics.OverlapSphere(earsPercept.position, earsPerceptRadious);
    }

    void perceptionManager()
    {
        if (perceibed != null)
        {
            foreach (Collider tmp in perceibed)
            {
                if (tmp.CompareTag("Player"))
                {
                    target = tmp.transform;
                }
            }
        }
        if (perceibed2 != null)
        {
            foreach (Collider tmp in perceibed2)
            {
                if (tmp.CompareTag("Player"))
                {
                    target = tmp.transform;
                }
            }
        }
    }

    void decisionManager()
    {
        AgressiveAgentStates newState;
        if (target == null)
        {
            newState = AgressiveAgentStates.Idle;
        }
        else
        {
            newState = AgressiveAgentStates.Escape;
            if (Vector3.Distance(transform.position, target.position) > stopThreshold)
            {
                target = null;
            }
        }
        changeAgentState(newState);
        movementManager();
    }

    void changeAgentState(AgressiveAgentStates t_newState)
    {
        if (agentState == t_newState)
        {
            return;
        }
        agentState = t_newState;
    }

    void movementManager()
    {
        switch (agentState)
        {
            case AgressiveAgentStates.Idle:
                idle();
                break;
            case AgressiveAgentStates.Escape:
                escaping();
                break;
        }
    }

    private void idle()
    {
        if (!currentAnimationStateName.Equals("idle"))
        {
            animator.Play("Rabbit_Idle 0", 0);
            currentAnimationStateName = "idle";
        }
        rb.velocity = Vector3.zero;
    }

    private void escaping()
    {
        if (!currentAnimationStateName.Equals("walk"))
        {
            animator.Play("Rabbit_Run 0", 0);
            currentAnimationStateName = "walk";
        }
        if (target == null)
        {
            return;
        }
        rb.velocity = SteeringBehaviours.flee(this, target.position);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(eyesPercept.position, eyesPerceptRadious);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(earsPercept.position, earsPerceptRadious);
    }

    private enum AgressiveAgentStates
    {
        Idle,
        Escape
    }
}