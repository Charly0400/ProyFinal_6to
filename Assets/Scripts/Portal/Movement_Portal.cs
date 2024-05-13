using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement_Portal : MonoBehaviour
{
    public float speed = 2f; // Velocidad de movimiento del objeto
    public float leftLimit = -5f; // Límite izquierdo de movimiento relativo al punto inicial del objeto
    public float rightLimit = 5f; // Límite derecho de movimiento relativo al punto inicial del objeto
    private bool movingRight = true; // Indica si el objeto se está moviendo hacia la derecha
    private float initialX; // Posición inicial en el eje X del objeto

    void Start()
    {
        // Guarda la posición inicial del objeto en el eje X
        initialX = transform.position.x;
    }

    void Update()
    {
        // Calcula los límites de movimiento basados en la posición inicial del objeto
        float adjustedLeftLimit = initialX + leftLimit;
        float adjustedRightLimit = initialX + rightLimit;

        // Mueve el objeto en la dirección adecuada
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // Si el objeto alcanza un límite, invierte la dirección de movimiento
        if (transform.position.x <= adjustedLeftLimit || transform.position.x >= adjustedRightLimit)
        {
            speed = -speed;
        }
    }
}
