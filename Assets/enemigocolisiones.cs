using UnityEngine;
using UnityEngine.SceneManagement;

public class enemigocolisiones : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Colisión con el jugador detectada");
            SceneManager.LoadScene("lose");
        }
    }
}
