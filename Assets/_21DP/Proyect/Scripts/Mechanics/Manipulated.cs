using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manipulated : Interactable
{
    Rigidbody rb;
    bool isGrabed = false;

    private void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E) && isGrabed)
            Release();
    }

    public override void OnGrab(Transform parent)
    {
        rb.useGravity = false;
        rb.isKinematic = true;
        transform.SetParent(parent);
        isGrabed = true;
    }

    private void Release()
    {
        rb.useGravity = true;
        rb.isKinematic = false;
        transform.SetParent(null);
        isGrabed = false;
    }

    public bool IsGrabed()
    {
        return isGrabed;
    }
}
