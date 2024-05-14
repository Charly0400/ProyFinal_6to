using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class PuzzleManager : MonoBehaviour
{
    public Animator door_Animator;
    [SerializeField]
    private GameObject portalToActivate;
    [SerializeField]
    public int puzzleSteps = 0;
    private int actualPuzzleSteps = 0;
    private int UICounter;
    [SerializeField]
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor[] Sockets;
    [SerializeField] private TextMeshProUGUI textoUI; // Referencia al componente Text
    private void PuzzleDone()
    {
        Debug.Log("EndGAME");
        door_Animator.Play("Cuarto_Final");
        portalToActivate.gameObject.SetActive(true); 
    }

    public void StepDone(UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor Socket)
    {
        UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable objectEnteringSocket = Socket.GetOldestInteractableSelected();
        if (actualPuzzleSteps < puzzleSteps - 1)
        {
            actualPuzzleSteps++;
            UICounter++;
            UpdateUI(); // Actualiza el texto del UI
        }
        else if (actualPuzzleSteps == puzzleSteps - 1)
        {
            PuzzleDone();
        }
    }

    private void UpdateUI()
    {
        if (textoUI != null)
        {
            textoUI.text = "Counter: " + UICounter.ToString();
        }
        else
        {
            Debug.LogWarning("TextoUI no asignado en el Inspector.");
        }
    }
}
