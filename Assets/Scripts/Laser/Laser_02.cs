using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_02 : MonoBehaviour
{
    int maxBounces = 5;
    private LineRenderer lr;

    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private bool reflecOnlyMirror;

    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, startPoint.position);
    }

    void Update()
    {
        CastLaser(transform.position, transform.forward);
    }

    void CastLaser(Vector3 position, Vector3 direction)
    {
        lr.SetPosition(0, startPoint.position);

        for (int i = 0; i < maxBounces; i++)
        {
            Ray ray = new Ray(position, direction);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 300, 1))
            {
                position = hit.point;
                direction = Vector3.Reflect(direction, hit.normal);
                lr.SetPosition(i + 1, hit.point);

                if (hit.transform.tag != "Mirror" && reflecOnlyMirror)
                {
                    for (int j = (i + 1); j <= 5; j++)
                    {
                       lr.SetPosition(j, hit.point);
                    }

                    var door = hit.transform.gameObject.GetComponent<Way>();

                    if(door != null) door.OpenTheWaaay();
                    break;
                }
     
            }
        }
    }

}

