using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport_Rokcs : MonoBehaviour
{
    [SerializeField] private Transform transformPosition;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Rocks"))
        {
            other.gameObject.transform.position = transformPosition.position;
            Debug.Log("ROCK");
        }
    }


}
