using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Socket : MonoBehaviour {
    [Header("Rocks")]
    [SerializeField]
    public GameObject rock;
    public Transform rockTransform;
    XRSocketInteractor sX;


    // Start is called before the first frame update
    void Start() {
        sX = GetComponent<XRSocketInteractor>();

    }
    public void Rocks() {

        //socket.SetActive(false);
        GameObject tempBullet = Instantiate(rock, rockTransform.position, Quaternion.identity);

        /*
         * IXRSelectInteractable objectEnteringSocket = sX.GetOldestInteractableSelected();
        Destroy(objectEnteringSocket.transform.gameObject);*/


    }
}
