using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public GameObject menu;
    public GameObject settings;
    public GameObject credits;

    void Start()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        credits.SetActive(false);
    }

    public void StartGame(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenSettings()
    {
        menu.SetActive(false);
        settings.SetActive(true);
        credits.SetActive(false);
    }

    public void CloseSettings()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        credits.SetActive(false);
    }

    public void OpenCredits()
    {
        menu.SetActive(false);
        settings.SetActive(false);
        credits.SetActive(true);
    }

    public void CloseCredits()
    {
        menu.SetActive(true);
        settings.SetActive(false);
        credits.SetActive(false);
    }

    public void Creditos()
    {
        Debug.Log("Creditos");
    }
}
