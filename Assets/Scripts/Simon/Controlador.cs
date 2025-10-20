using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour {
    public Button[] cubos;
    public GameObject premio, portal;
    public Animator animator_Portal;
    public List<int> listaAleatoria = new List<int>();

    public bool listaLlena;
    public bool turnoPC;
    public bool turnoUsuario;

    public int contadorPC;
    public int contadorUsuario;
    public int nivelActual;
    public int nivelMaximo = 4;

    [Range(0.5f, 2f)]
    public float velocidad = 1f;

    private Coroutine turnoPCCoroutine;
    private Coroutine esperaCoroutine;

    void Start() {
        Debug.Log("INICIANDO SIMON DICE");
        Reiniciar();
    }

    void LlenarListaAleatoria() {
        listaAleatoria.Clear();
        for (int i = 0; i < 100; i++) {
            listaAleatoria.Add(Random.Range(0, cubos.Length));
        }
        listaLlena = true;

        string secuencia = "Secuencia: ";
        for (int i = 0; i < 10; i++) {
            secuencia += listaAleatoria[i] + " ";
        }
        Debug.Log(secuencia);
    }

    public void IniciarTurnoPC() {
        if (turnoPCCoroutine != null) {
            StopCoroutine(turnoPCCoroutine);
        }
        turnoPCCoroutine = StartCoroutine(TurnoPCCoroutine());
    }

    private IEnumerator TurnoPCCoroutine() {
        yield return new WaitForSeconds(1f);

        while (listaLlena && turnoPC) {
            int colorID = listaAleatoria[contadorPC];
            Debug.Log("PC - Nivel " + nivelActual + ": Mostrando color " + colorID + " (posicion " + (contadorPC + 1) + " de " + nivelActual + ")");

            // Usar el nuevo método para activación por controlador
            cubos[colorID].ActivarCuboPorControlador();
            contadorPC++;

            if (contadorPC < nivelActual) {
                yield return new WaitForSeconds(velocidad);
            }
            else {
                Debug.Log("PC termino secuencia. Turno del usuario para repetir " + nivelActual + " colores");
                CambiarEstado();
                yield break;
            }
        }
    }

    public void ClickUsuario(int idCubo) {
        if (!turnoUsuario) {
            Debug.LogWarning("Ignorando click - no es turno del usuario");
            return;
        }

        int esperado = listaAleatoria[contadorUsuario];
        Debug.Log("Usuario pulso: " + idCubo + ", Esperado: " + esperado + " (posicion " + (contadorUsuario + 1) + " de " + nivelActual + ")");

        if (idCubo != esperado) {
            Debug.LogError("ERROR en posicion " + (contadorUsuario + 1) + ". Pulsaste " + idCubo + " pero debia ser " + esperado);

            if (esperaCoroutine != null) {
                StopCoroutine(esperaCoroutine);
            }
            esperaCoroutine = StartCoroutine(EsperarYReiniciar(0.1f));
            return;
        }

        Debug.Log("Correcto! posicion " + (contadorUsuario + 1) + " de " + nivelActual);
        contadorUsuario++;

        if (contadorUsuario >= nivelActual) {
            Debug.Log("NIVEL " + nivelActual + " COMPLETADO!");

            if (nivelActual >= nivelMaximo) {
                if (esperaCoroutine != null) {
                    StopCoroutine(esperaCoroutine);
                }
                esperaCoroutine = StartCoroutine(EsperarYFinDelJuego(0.1f));
            }
            else {
                nivelActual++;
                CambiarEstado();
            }
        }
    }

    public void CambiarEstado() {
        if (turnoPC) {
            // PC -> Usuario
            turnoPC = false;
            turnoUsuario = true;
            contadorUsuario = 0;

            // Permitir que los usuarios pulsen los botones
            foreach (var cubo in cubos) {
                cubo.PermitirPulsacionesDeUsuario(true);
            }

            Debug.Log("TURNO DEL USUARIO");
            Debug.Log("Repite la secuencia de " + nivelActual + " colores");
        }
        else {
            // Usuario -> PC  
            turnoPC = true;
            turnoUsuario = false;
            contadorPC = 0;

            // Bloquear pulsaciones de usuario durante el turno de la PC
            foreach (var cubo in cubos) {
                cubo.PermitirPulsacionesDeUsuario(false);
            }

            Debug.Log("TURNO DE LA PC");
            Debug.Log("Mostrando secuencia de " + nivelActual + " colores");

            if (esperaCoroutine != null) {
                StopCoroutine(esperaCoroutine);
            }
            esperaCoroutine = StartCoroutine(EsperarYIniciarTurnoPC(1.5f));
        }
    }

    private IEnumerator EsperarYReiniciar(float segundos) {
        yield return new WaitForSeconds(segundos);
        Reiniciar();
    }

    private IEnumerator EsperarYFinDelJuego(float segundos) {
        yield return new WaitForSeconds(segundos);
        FinDelJuego();
    }

    private IEnumerator EsperarYIniciarTurnoPC(float segundos) {
        yield return new WaitForSeconds(segundos);
        IniciarTurnoPC();
    }

    public void Reiniciar() {
        Debug.Log("REINICIANDO JUEGO");

        // Detener todas las corrutinas
        if (turnoPCCoroutine != null) {
            StopCoroutine(turnoPCCoroutine);
            turnoPCCoroutine = null;
        }
        if (esperaCoroutine != null) {
            StopCoroutine(esperaCoroutine);
            esperaCoroutine = null;
        }

        // Bloquear pulsaciones durante el reinicio
        foreach (var cubo in cubos) {
            cubo.PermitirPulsacionesDeUsuario(false);
        }

        contadorPC = 0;
        contadorUsuario = 0;
        nivelActual = 1;
        turnoPC = true;
        turnoUsuario = false;

        LlenarListaAleatoria();

        if (premio != null) premio.SetActive(false);
        if (portal != null) portal.SetActive(false);

        // Solo permitir pulsaciones cuando sea el turno del usuario
        if (turnoUsuario) {
            foreach (var cubo in cubos) {
                cubo.PermitirPulsacionesDeUsuario(true);
            }
        }

        IniciarTurnoPC();
    }

    public void FinDelJuego() {
        Debug.Log("FELICIDADES! GANASTE EL JUEGO");

        if (premio != null) premio.SetActive(true);
        if (portal != null) portal.SetActive(true);
        if (animator_Portal != null) animator_Portal.Play("Open_ButtonPortal_1");

        turnoPC = false;
        turnoUsuario = false;

        // Bloquear pulsaciones al final del juego
        foreach (var cubo in cubos) {
            cubo.PermitirPulsacionesDeUsuario(false);
        }

        // Detener corrutinas
        if (turnoPCCoroutine != null) {
            StopCoroutine(turnoPCCoroutine);
            turnoPCCoroutine = null;
        }
    }
}