using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedTheAgent : MonoBehaviour {
    CompañiaAgent tucan;

    void Start() {
        tucan = GameObject.Find("Tucan_Acompañante").GetComponent<CompañiaAgent>();
    }
    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.G)) {
            tucan.feed(gameObject.transform);
        }
    }
}
