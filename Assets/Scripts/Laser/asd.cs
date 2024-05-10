using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class asd : MonoBehaviour {

    public XRKnob knobInteractable; // El XR Knob que controlará la rotación
    public GameObject cristal;
    private float initialAngle = 0f; // Ángulo inicial para la rotación

    private void Start()
    {
        // Aseguramos que tenemos el componente XRKnob desde este GameObject
        knobInteractable = GetComponent<XRKnob>();
        if (knobInteractable == null)
        {
            Debug.LogError("XRKnob component not found on the object!");
        }

        // Establecer el ángulo inicial según la rotación actual de 'cristal'
        if (cristal != null)
        {
            initialAngle = cristal.transform.eulerAngles.y;
        }
        else
        {
            Debug.LogError("Cristal GameObject is not assigned!");
        }
    }

    void Update()
    {
        if (cristal != null && knobInteractable != null)
        {
            // Calcula el ángulo total de rotación basándote en el valor del knob
            float targetAngle = initialAngle + knobInteractable.value * 360f; // Suponiendo que el valor del knob es un porcentaje [0, 1]
            cristal.transform.rotation = Quaternion.Euler(0, targetAngle, 0);
        }
    }


    /*
    
    public XRKnob knobInteractable; // El XR Knob que controlará la rotación
    public GameObject cristal;
  
    private void Start() {
        knobInteractable = GetComponent<XRKnob>();
    }

    void Update() {

        cristal.transform.Rotate(Vector3.up * knobInteractable.value);
    }
    */
}

