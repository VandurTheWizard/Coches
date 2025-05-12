using UnityEngine;

public class EffectItem : MonoBehaviour
{
    [Header("Floating Settings")]
    public float floatSpeed = 1f; // Ajusta la velocidad de flotación
    public float floatAmplitude = 0.5f; // Ajusta la amplitud de la flotación (cuanto sube y baja)
    public float rotationSpeed = 50f;

    private Vector3 originalPosition; // Guarda la posición original del objeto

    void Start()
    {
        originalPosition = transform.position; // Guarda la posición inicial en Start
    }

    void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

        float newY = originalPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatAmplitude;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}