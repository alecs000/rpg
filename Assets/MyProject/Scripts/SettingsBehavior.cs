using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsBehavior : MonoBehaviour
{
    [SerializeField] private GameObject _settingsGameObject;
    [SerializeField] private AudioMixerGroup _audioMixerGroup;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _effectsSlider;
    private void Start()
    {
        Time.timeScale = 1;
        float music = PlayerPrefs.GetFloat("Music");
        if (music != 0)
        {
            _audioMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, music));
            _musicSlider.value = music;
        }
        float effects = PlayerPrefs.GetFloat("Effects");
        if (effects != 0)
        {
            _audioMixerGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, effects));
            _effectsSlider.value = effects;
        }
    }
    public void OpenSettings()
    {
        _settingsGameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void CloseSettings()
    {
        _settingsGameObject.SetActive(false);
        Time.timeScale = 1;
    }
    public void ChangeEffects(float volume)
    {
        _audioMixerGroup.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("Effects", volume);
    }
    public void ChangeMusic(float volume)
    {
        _audioMixerGroup.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("Music", volume);
    }
    public void Clear()
    {
        PlayerPrefs.DeleteAll();
    }
}
