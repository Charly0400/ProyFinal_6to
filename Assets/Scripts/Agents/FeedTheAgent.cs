using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedTheAgent : MonoBehaviour
{
    Compa�iaAgent tucan;

    void Start()
    {
        tucan = GameObject.Find("Tucan").GetComponent<Compa�iaAgent>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            tucan.feed(gameObject.transform);
        }
    }
}
