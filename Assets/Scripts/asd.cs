using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class asd : MonoBehaviour {

    public XRBaseInteractable knobInteractable; // El XR Knob que controlar� la rotaci�n
    public float rotationSpeed = 10f; // Velocidad de rotaci�n

    private bool isInteracting = false; // Bandera para saber si se est� interactuando con el knob

    void Update() {
        if (isInteracting) {
            if (knobInteractable.interactorsSelecting.Count > 0) {
                // Obtenemos el primer interactor seleccionando
                //XRBaseInteractor interactor = knobInteractable.interactorsSelecting[0];

                // Calculamos la rotaci�n basada en el movimiento del interactor
                //float rotationAmount = interactor.transform.localRotation.z * rotationSpeed * Time.deltaTime;

                // Aplicamos la rotaci�n al objeto
                //transform.Rotate(Vector3.up, rotationAmount);
            }
        }
    }

    private void OnEnable() {
        knobInteractable.selectEntered.AddListener(OnSelectEnter);
        knobInteractable.selectExited.AddListener(OnSelectExit);
    }

    private void OnDisable() {
        knobInteractable.selectEntered.RemoveListener(OnSelectEnter);
        knobInteractable.selectExited.RemoveListener(OnSelectExit);
    }

    void OnSelectEnter(SelectEnterEventArgs args) {
        isInteracting = true;
    }

    void OnSelectExit(SelectExitEventArgs args) {
        isInteracting = false;
    }
    /*/public GameObject cubo;
    public XRKnob ruedita;
    public float value_Ruedita;
    //public Transform ruedita;
    public Transform cubito;

    // Start is called before the first frame update
    void Start()
    {
        value_Ruedita = ruedita.value;
    }

    // Update is called once per frame
    void Update()
    {
        cubito.rotation.SetAxisAngle(cubito.rotation, value_Ruedita);
    }

    public void Funtion() {

    }
    */
}

