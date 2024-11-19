using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class Cookis : MonoBehaviour {
    public Transform cookiesSpawn;
    Compa�iaAgent tucan;
    public GameObject cookies;
    XRSocketInteractor sX;
    public GameObject player;


    void Start () {
        tucan = GameObject.Find("Tucan_Acompa�ante").GetComponent<Compa�iaAgent>();
        sX = GetComponent<XRSocketInteractor>();
    }

    public void Feed() {
        tucan.feed(player.gameObject.transform);
        IXRSelectInteractable objectEnteringSocket = sX.GetOldestInteractableSelected();
        //objectEnteringSocket.transform.gameObject.SetActive(false);
        //Destroy(objectEnteringSocket.transform.gameObject);

    }

    public void SapwnCookies() {

        //socket.SetActive(false);
        GameObject tempBullet = Instantiate(cookies, cookiesSpawn.position, Quaternion.identity);

    }
}
