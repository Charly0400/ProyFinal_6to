using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooting_Range : MonoBehaviour
{
    public Animator portal_Animator;
    public GameObject[] targets;
    public GameObject finalEventObject; // Objeto que se activará cuando se completen todos los objetivos

    private int destroyedTargetsCount = 0;
    private bool finalEventActivated = false;

    void Start()
    {

    }

    public void CheckAllTargetsDestroyed()
    {
        destroyedTargetsCount++;
        Debug.Log(destroyedTargetsCount);

        // Verificar si se han destruido todos los objetivos
        if (destroyedTargetsCount >= targets.Length && !finalEventActivated)
        {
            finalEventActivated = true;
            portal_Animator.Play("Open_ShootinfPortal_1");
        }
    }
}
