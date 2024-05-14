using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIMenuManager : MonoBehaviour
{
    public Animator portal_Animator;
    public void startGame()
    {
        portal_Animator.Play("Open_CanvasPortal");
    }

    public void Exit()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
