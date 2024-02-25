using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{

    [SerializeField] Slider soundSlider;
    [SerializeField] AudioMixer masterMixer;
    [SerializeField] TextMeshProUGUI percent;

    // Start is called before the first frame update
    void Start()
    {
        // SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
    }

    public void SetVolume(float _value)
    {
        if (_value < 1) {
            _value = .001f;
        }

        RefreshSlider(_value);
        // PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);
    }

    public void SetVolumeFromSlider()
    {
        SetVolume(soundSlider.value);
    }

    public void RefreshSlider(float _value)
    {
        soundSlider.value = _value;
    }

    public string VolumeToString(float _value)
    {
        return Math.Floor(_value).ToString() + "%";
    }

    public void UpdatePercent() {
        percent.text = VolumeToString(soundSlider.value);
    }
}
