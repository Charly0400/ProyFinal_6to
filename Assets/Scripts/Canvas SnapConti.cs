
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class CanvasSnapConti : MonoBehaviour
{

    [SerializeField]
    private XROrigin XROriginReference;
    private bool ChangeRotationBool = false;
    private bool RotationContinuos = true;
    private bool RotationSnap = false;
    public void ChangeRotationFunction()
    {
        ChangeRotationBool = !ChangeRotationBool;
        if (ChangeRotationBool)
        {
            RotationContinuos = !RotationContinuos;
            RotationSnap = !RotationSnap;
            XROriginReference.GetComponent<ContinuousTurnProviderBase>().enabled = RotationContinuos;
            XROriginReference.GetComponent<SnapTurnProviderBase>().enabled = RotationSnap;
        }
        else
        {
            RotationContinuos = !RotationContinuos;
            RotationSnap = !RotationSnap;
            XROriginReference.GetComponent<ContinuousTurnProviderBase>().enabled = RotationContinuos;
            XROriginReference.GetComponent<SnapTurnProviderBase>().enabled = RotationSnap;
        }



    }
}