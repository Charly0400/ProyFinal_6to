using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Shooting_Range : MonoBehaviour
{
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

        // Verificar si se han destruido todos los objetivos
        if (destroyedTargetsCount >= targets.Length && !finalEventActivated)
        {
            // Activar el evento final si todos los objetivos han sido destruidos
            finalEventObject.SetActive(true);
            finalEventActivated = true;
        }
    }
}
