using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Sources")]
    public AudioSource backgroundMusic;   // Music AudioSource
    public AudioSource sfxSource;         // SFX AudioSource

    [Header("Sound Effects")]
    public AudioClip buttonClickSound;
    public AudioClip winSound;
    public AudioClip loseSound;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        LoadSettings();
    }

    void Start()
    {
        if (!backgroundMusic.isPlaying)
            backgroundMusic.Play();
    }

    // ================= MUSIC =================

    public void ToggleMusic(bool isOn)
    {
        PlayerPrefs.SetInt("Music", isOn ? 1 : 0);
        backgroundMusic.mute = !isOn;

        if (isOn && !backgroundMusic.isPlaying)
            backgroundMusic.Play();
    }

    // ================= SFX =================

    public void ToggleSFX(bool isOn)
    {
        PlayerPrefs.SetInt("SFX", isOn ? 1 : 0);
    }

    public void PlayClick()
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 0) return;

        if (buttonClickSound != null)
            sfxSource.PlayOneShot(buttonClickSound);
    }

    public void PlayWin()
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 0) return;

        if (winSound != null)
            sfxSource.PlayOneShot(winSound);
    }

    public void PlayLose()
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 0) return;

        if (loseSound != null)
            sfxSource.PlayOneShot(loseSound);
    }

    // ================ GENERIC SFX =================
    // Call this from GameManager with any AudioClip
    public void PlaySFX(AudioClip clip)
    {
        if (PlayerPrefs.GetInt("SFX", 1) == 0) return;

        if (clip != null)
            sfxSource.PlayOneShot(clip);
    }

    // ================= LOAD =================

    void LoadSettings()
    {
        int musicPref = PlayerPrefs.GetInt("Music", 1);
        backgroundMusic.mute = (musicPref == 0);
    }
}