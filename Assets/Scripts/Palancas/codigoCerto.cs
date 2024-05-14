using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class codigoCerto : MonoBehaviour
{
    public Animator portal_Animator;
    public Animator marco_Portal;
    public GameObject portal;

    public IEnumerator Palancas()
    {
        Debug.Log("Open");
        portal.SetActive(true);
        marco_Portal.Play("Marco_Portal");

        // Esperar 4 segundos antes de continuar
        yield return new WaitForSeconds(2f);
        portal.SetActive(true);
        portal_Animator.Play("Open_PalancasPortal_1");
    }
}
