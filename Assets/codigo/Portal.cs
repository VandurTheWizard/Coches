using UnityEngine;

public class Portal : MonoBehaviour
{
    public Vector3 destination;

    void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player")){
            Debug.Log("Player entered the portal");
            other.transform.position = destination;

            // Forzar la actualización de la posición
            other.gameObject.SetActive(false);
            other.gameObject.SetActive(true);
        }
    }
}
