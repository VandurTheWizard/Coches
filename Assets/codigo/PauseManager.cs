using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [Header("References")]
    public GameObject menu;
    public GameObject pauseMenu;
    public GameObject settingsMenu;
    public Slider volumeSliderMusic;
    public Slider volumeSliderSFX;


    void Start()
    {
    }

    private bool isPaused = false;

    public void ChangeActiveState(bool state)
    {
        isPaused = state;
        menu.SetActive(isPaused);
        pauseMenu.SetActive(isPaused);
        settingsMenu.SetActive(false);
    }

    public void OpenSettings()
    {
        settingsMenu.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsMenu.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void SetMusicVolume(float value)
    {
    }

    public void SetSFXVolume(float value)
    {
    }
    
    
}
