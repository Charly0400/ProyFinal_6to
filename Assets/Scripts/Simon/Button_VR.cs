using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class Button_VR : MonoBehaviour
{
    public GameObject cristal;
    public XRPushButton interactable;
    public AudioClip sonido;
    public Controlador controlador;
    public float intensityMultiplier = 1f;

    private float initialIntensity;

    void Start()
    {
        if (interactable == null)
        {
            Debug.LogError("Interactable reference not set!");
            return;
        }

        interactable.onSelectEntered.AddListener(ActivarCuboVR);

        initialIntensity = cristal.GetComponent<Light>().intensity;
    }

    void ActivarCuboVR(UnityEngine.XR.Interaction.Toolkit.Interactors.XRBaseInteractor interactor)
    {
        cristal.SetActive(true);
        cristal.GetComponent<Light>().intensity = initialIntensity * intensityMultiplier;

        if (controlador.turnoUsuario)
        {
            controlador.ClickUsuario(idCube);
        }

        AudioSource.PlayClipAtPoint(sonido, Vector3.zero, 1.0f);

        Invoke("DesactivarCubo", 0.1f);
    }

    public void DesactivarCubo()
    {
        cristal.GetComponent<Light>().intensity = 0;
        cristal.SetActive(false);
    }
}
