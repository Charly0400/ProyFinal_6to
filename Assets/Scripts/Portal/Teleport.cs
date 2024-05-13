using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private Transform transformPosition;
    public Material skybox1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.transform.position = transformPosition.position;
            Debug.Log("HOLA");

            RenderSettings.skybox =  skybox1;
        }
    }


}
