using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Palancas : MonoBehaviour
{
    bool virado = false;
    public bool podeVirar = true;

    public GameObject bola;

    public Material bolaDeligado;
    public Material bolaLigado;

    public GameObject controlador;
    IEnumerator mudar()
    {
        yield return new WaitForSeconds(.75f);
        podeVirar = true;
        virado = !virado;

        if (virado)
        {
            bola.GetComponent<Renderer>().material = bolaLigado;
        }
        else
        {
            bola.GetComponent<Renderer>().material = bolaDeligado;
        }

        controlador.GetComponent<PalancasPuzzle>().receberSignal(gameObject, virado);
    }
    public void Palanca()
    {
        if (podeVirar)
        {
            podeVirar = false;
            if(!virado)
            {
                StartCoroutine (mudar());
            }
            else
            {
                StartCoroutine (mudar());
            }
        }
    }


}
