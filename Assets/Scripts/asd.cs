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
  
    private void Start() {
        knobInteractable = GetComponent<XRKnob>();
    }

    void Update() {

        cristal.transform.Rotate(Vector3.up * knobInteractable.value);
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

