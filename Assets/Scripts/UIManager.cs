using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Panels")]
    public GameObject mainMenuUI;  // Drag your Main Menu Canvas here
    public GameObject gameUI;      // Drag your Game Scene Canvas here
    public GameObject howToPlayUI; // Optional
    public GameObject aboutUI;     // Optional
    public GameObject settingsUI;  // Optional

    // Start Game button
    public void StartGame()
    {
        mainMenuUI.SetActive(false);
        gameUI.SetActive(true);
    }

    // Go back to Main Menu
    public void BackToMenu()
    {
        mainMenuUI.SetActive(true);
        gameUI.SetActive(false);
        howToPlayUI?.SetActive(false);
        aboutUI?.SetActive(false);
        settingsUI?.SetActive(false);
    }

    // Open other pages
    public void OpenHowToPlay()
    {
        mainMenuUI.SetActive(false);
        howToPlayUI.SetActive(true);
    }

    public void OpenAbout()
    {
        mainMenuUI.SetActive(false);
        aboutUI.SetActive(true);
    }

    public void OpenSettings()
    {
        mainMenuUI.SetActive(false);
        settingsUI.SetActive(true);
    }
}