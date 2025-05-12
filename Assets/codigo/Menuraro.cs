using UnityEngine;

public class Menuraro : MonoBehaviour
{
    public void CambiarEscena(string nombreEscena)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nombreEscena);
    }

    public void SalirJuego()
    {
        Application.Quit();
    }
}
