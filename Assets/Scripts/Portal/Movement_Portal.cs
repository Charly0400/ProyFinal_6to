using UnityEngine;

public class Movement_Portal : MonoBehaviour {
    [Header("Configuración de Movimiento")]
    public float speed = 2f;
    public float leftLimit = -5f;
    public float rightLimit = 5f;

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool movingRight = true;

    void Start() {
        // Guardar posición inicial
        initialPosition = transform.position;

        // Establecer posición objetivo inicial
        targetPosition = initialPosition + Vector3.right * rightLimit;
    }

    void Update() {
        MoveObject();
        CheckBoundaries();
    }

    void MoveObject() {
        // Calcular dirección hacia el objetivo
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Mover hacia el objetivo
        transform.position += direction * speed * Time.deltaTime;
    }

    void CheckBoundaries() {
        // Calcular límites absolutos
        float currentX = transform.position.x;
        float minX = initialPosition.x + leftLimit;
        float maxX = initialPosition.x + rightLimit;

        // Verificar si llegó al límite derecho
        if (movingRight && currentX >= maxX - 0.1f) {
            movingRight = false;
            targetPosition = initialPosition + Vector3.right * leftLimit;
        }
        // Verificar si llegó al límite izquierdo
        else if (!movingRight && currentX <= minX + 0.1f) {
            movingRight = true;
            targetPosition = initialPosition + Vector3.right * rightLimit;
        }
    }

    // Método opcional para debug visual en el Editor
    void OnDrawGizmosSelected() {
        Vector3 currentPos = Application.isPlaying ? initialPosition : transform.position;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(currentPos + Vector3.right * leftLimit, 0.3f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(currentPos + Vector3.right * rightLimit, 0.3f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(currentPos + Vector3.right * leftLimit, currentPos + Vector3.right * rightLimit);
    }
}