using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int idCube;
    public float intensidadLuz;
    public Light luz;
    public bool desactivando;
    public bool desactivado;
    public AudioClip sonido;
    public Controlador controlador;

    void Start()
    {
        intensidadLuz = luz.intensity;

    }

    public void ActivarCubo()
    {
        desactivado = false;
        desactivado |= false;
        luz.intensity = intensidadLuz;
        luz.gameObject.SetActive (true);

        //LLamar eesta funcion para saber que el usuario a hecho click al cubo
        if (controlador.turnoUsuario)
        {
            controlador.ClickUsuario(idCube);
        }
         
        AudioSource.PlayClipAtPoint(sonido, Vector3.zero, 1.0f);

        Invoke("DesactivarCubo", 0.1f);
    }

    public void DesactivarCubo()
    {
        desactivando = true;
    }

    void Update()
    {
        if (desactivando && !desactivado)
        {
            luz.intensity = Mathf.Lerp(luz.intensity, 0, 0.065f);
        } 
            
        if (luz.intensity <= 0.02)
        {
            luz.intensity = 0;
            desactivado = true;
        }
    }

    void OnMouseDown()
    {
        Debug.Log(name);
        ActivarCubo();
    }
}
