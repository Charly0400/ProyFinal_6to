using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactors;


public class PuzzleManager : MonoBehaviour
{
    public Animator door_Animator;
    [SerializeField]
    private GameObject portalToActivate;
    [SerializeField]
    //private UIManager uiManagerRef;
    public int puzzleSteps = 0;
    private int actualPuzzleSteps = 0;
    [SerializeField]
    private UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor[] Sockets;
    private void PuzzleDone()
    {
        Debug.Log("EndGAME");
        door_Animator.Play("Cuarto_Final");
        portalToActivate.gameObject.SetActive(true); 
    }

    public void StepDone(UnityEngine.XR.Interaction.Toolkit.Interactors.XRSocketInteractor Socket) {
        UnityEngine.XR.Interaction.Toolkit.Interactables.IXRSelectInteractable objectEnteringSocket = Socket.GetOldestInteractableSelected();
        if (actualPuzzleSteps < puzzleSteps - 1)
        {
            actualPuzzleSteps++;
            //uiManagerRef.UIAugmenter();   
        }

        else if (actualPuzzleSteps == puzzleSteps - 1)
        {
            PuzzleDone();
        }
       
    }
}
