using UnityEngine;
using UnityEngine.SceneManagement;

public class Elviscolsion : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("win");
        }
    }
}
