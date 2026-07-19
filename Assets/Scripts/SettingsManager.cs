using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSlider;
    public Slider musicSlider;
    public Slider sfxSlider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1f);
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1f);
        sfxSlider.value = PlayerPrefs.GetFloat("SfxVolume", 1f);

        SetMasterVolume(masterSlider.value);
        SetMusicVolume(musicSlider.value);
        SetSfxVolume(sfxSlider.value);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat(
            "MasterVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f);

        PlayerPrefs.SetFloat("MasterVolume", value);
    }

    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat(
            "MusicVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f);

        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void SetSfxVolume(float value)
    {
        audioMixer.SetFloat(
            "SfxVolume", Mathf.Log10(Mathf.Max(value, 0.0001f)) * 20f);

        PlayerPrefs.SetFloat("SfxVolume", value);
    }



}

