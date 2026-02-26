using UnityEngine;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public Toggle musicToggle;
    public Toggle sfxToggle;

    void Start()
    {
        musicToggle.isOn = PlayerPrefs.GetInt("Music", 1) == 1;
        sfxToggle.isOn = PlayerPrefs.GetInt("SFX", 1) == 1;

        musicToggle.onValueChanged.AddListener((value) =>
        {
            AudioManager.Instance.ToggleMusic(value);
        });

        sfxToggle.onValueChanged.AddListener((value) =>
        {
            AudioManager.Instance.ToggleSFX(value);
        });
    }
}