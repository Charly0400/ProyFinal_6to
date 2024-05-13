using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class Bullets : MonoBehaviour
{
    [SerializeField]
    private float time = 3f;

    public static event System.Action OnTargetDestroyed;

    private void Update()
    {
        time -= Time.deltaTime;

        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Target") 
        {
            Animator animator = other.gameObject.GetComponent<Animator>();
            if (animator != null )
            {
                animator.Play("Muelto");
            }

            Debug.Log("Objetivo destruido");
            // Destroy(other.gameObject);
            Shooting_Range shootingRange = FindObjectOfType<Shooting_Range>();
            shootingRange.CheckAllTargetsDestroyed();
            Destroy(gameObject);
        }

        
    }

}
