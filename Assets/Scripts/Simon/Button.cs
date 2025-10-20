using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Content.Interaction;

public class Button : MonoBehaviour {
    public int idCube;
    public float intensidadLuz;
    public Light luz;
    public bool desactivando;
    public bool desactivado;
    public AudioClip sonido;
    public Controlador controlador;
    public XRPushButton button;

    // Variables para control de pulsaciones
    private bool puedeSerActivadoPorUsuario = true;
    private bool activacionEnCurso = false;

    void Start() {
        if (luz != null)
            intensidadLuz = luz.intensity;

        if (button != null) {
            // Solo conectar onPress para las pulsaciones del usuario
            button.onPress.AddListener(OnButtonPressedByUser);
        }
        else
            Debug.LogError("XRPushButton no encontrado en " + gameObject.name);

        if (controlador == null)
            Debug.LogError("Controlador no asignado en " + gameObject.name);
    }

    // Este m�todo es solo para cuando el USUARIO presiona f�sicamente el bot�n
    public void OnButtonPressedByUser() {
        if (!puedeSerActivadoPorUsuario) {
            Debug.LogWarning("BOTON " + idCube + " - Ignorando pulsaci�n f�sica (no es turno del usuario)");
            return;
        }

        if (activacionEnCurso) {
            Debug.LogWarning("BOTON " + idCube + " - Ignorando pulsaci�n f�sica (activaci�n en curso)");
            return;
        }

        Debug.Log("BOTON " + idCube + " - Pulsaci�n f�sica del usuario");
        ActivarCuboPorUsuario();
    }

    // Este m�todo es para cuando el CONTROLADOR activa el bot�n (muestra secuencia)
    public void ActivarCuboPorControlador() {
        Debug.Log("BOTON " + idCube + " - Activado por Controlador (mostrar secuencia)");
        StartCoroutine(ActivarCuboCoroutine(false)); // false = no es pulsaci�n de usuario
    }

    // Este m�todo es para cuando el USUARIO pulsa f�sicamente el bot�n
    private void ActivarCuboPorUsuario() {
        Debug.Log("BOTON " + idCube + " - Activado por Usuario (pulsaci�n f�sica)");
        StartCoroutine(ActivarCuboCoroutine(true)); // true = es pulsaci�n de usuario
    }

    private IEnumerator ActivarCuboCoroutine(bool esPulsacionUsuario) {
        if (activacionEnCurso) {
            Debug.LogWarning("BOTON " + idCube + " - Activaci�n ignorada (ya en curso)");
            yield break;
        }

        activacionEnCurso = true;

        // Resetear estados visuales
        desactivado = false;
        desactivando = false;

        // Activar luz
        if (luz != null) {
            luz.intensity = intensidadLuz;
            luz.gameObject.SetActive(true);
            Debug.Log("BOTON " + idCube + " - Luz activada");
        }

        // Solo notificar al controlador si es una pulsaci�n del usuario
        if (esPulsacionUsuario && controlador != null && controlador.turnoUsuario) {
            Debug.Log("BOTON " + idCube + " - Notificando al Controlador");
            controlador.ClickUsuario(idCube);
        }
        else if (esPulsacionUsuario) {
            Debug.LogWarning("BOTON " + idCube + " - Pulsaci�n de usuario ignorada (no es turno)");
        }

        // Reproducir sonido
        if (sonido != null) {
            AudioSource.PlayClipAtPoint(sonido, Vector3.zero, 1.0f);
            Debug.Log("BOTON " + idCube + " - Sonido reproducido");
        }

        // Esperar y desactivar
        yield return new WaitForSeconds(0.1f);
        DesactivarCubo();

        activacionEnCurso = false;
    }

    public void DesactivarCubo() {
        Debug.Log("BOTON " + idCube + " - Iniciando desactivaci�n de luz");
        desactivando = true;
    }

    void Update() {
        if (desactivando && !desactivado && luz != null) {
            luz.intensity = Mathf.Lerp(luz.intensity, 0, 0.065f);

            if (luz.intensity <= 0.02f) {
                luz.intensity = 0;
                desactivado = true;
                desactivando = false;
                Debug.Log("BOTON " + idCube + " - Luz completamente apagada");
            }
        }
    }

    // M�todos para que el Controlador controle el estado
    public void PermitirPulsacionesDeUsuario(bool permitir) {
        puedeSerActivadoPorUsuario = permitir;
        Debug.Log("BOTON " + idCube + " - Pulsaciones de usuario " + (permitir ? "PERMITIDAS" : "BLOQUEADAS"));
    }
}