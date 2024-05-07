using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class asd : MonoBehaviour {
    public class RotatingObject : MonoBehaviour {
        public XRBaseInteractable knobInteractable; // El XR Knob que controlará la rotación
        public float rotationSpeed = 10f; // Velocidad de rotación

        private bool isInteracting = false; // Bandera para saber si se está interactuando con el knob

        void Update() {
            if (isInteracting) {
                //float rotationAmount = knobInteractable.selectingInteractor.transform.localRotation.z * rotationSpeed * Time.deltaTime;
                //transform.Rotate(Vector3.up, rotationAmount);
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
}
