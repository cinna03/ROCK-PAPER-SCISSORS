using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject homePanel;
    public GameObject howToPlayPanel;
    public GameObject aboutPanel;
    public GameObject settingsPanel;

    [Header("Settings Controls")]
    public Toggle musicToggle;
    public Toggle sfxToggle;

    [Header("Audio")]
    public AudioSource musicSource;      // Background music AudioSource
    public AudioSource[] sfxSources;     // All gameplay sound effects AudioSources

    void Start()
    {
        OpenHome();

        // Initialize toggles
        if (musicToggle != null) 
        {
            musicToggle.isOn = true;
            ToggleMusic(musicToggle.isOn); // ensure music starts correctly
        }

        if (sfxToggle != null)
        {
            sfxToggle.isOn = true;
            ToggleSFX(sfxToggle.isOn); // enable all SFX initially
        }
    }

    // -------------------- Panel Navigation --------------------
    public void OpenHome()
    {
        DisableAll();
        homePanel.SetActive(true);
    }

    public void OpenHowToPlay()
    {
        DisableAll();
        howToPlayPanel.SetActive(true);
    }

    public void OpenAbout()
    {
        DisableAll();
        aboutPanel.SetActive(true);
    }

    public void OpenSettings()
    {
        DisableAll();
        settingsPanel.SetActive(true);
    }

    void DisableAll()
    {
        homePanel.SetActive(false);
        howToPlayPanel.SetActive(false);
        aboutPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    // -------------------- Start / Exit --------------------
    public void StartGame()
    {
        SceneManager.LoadScene("GameScene"); // replace with your GameScene name
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    // -------------------- Settings --------------------
    public void ToggleMusic(bool isOn)
    {
        if (musicSource != null)
        {
            musicSource.mute = !isOn;
            if (isOn && !musicSource.isPlaying)
                musicSource.Play();  // Ensure music resumes if re-enabled
        }
    }

    public void ToggleSFX(bool isOn)
    {
        if (sfxSources != null)
        {
            foreach (var sfx in sfxSources)
            {
                sfx.mute = !isOn;  // mute/unmute each sound effect
            }
        }
    }
}