using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public static List<AudioSource> gameSounds = new List<AudioSource>();// List of audio sources for game sounds, can be partially filled automatically by ClickableObject.cs
    public static List<AudioSource> musicSources = new List<AudioSource>();

    [SerializeField] private List<AudioSource> inspectorMusicSource;
    [SerializeField] private List<AudioSource> inspectorGameSounds;
    [SerializeField] private Slider soundSlider; //they are here only to set them where they should be in the begining. This script has to be referenced in slider component too.
    [SerializeField] private Slider musicSlider;
    private void Start()
    {
        foreach(AudioSource source in inspectorMusicSource)
        {
            if(source != null && !musicSources.Contains(source)) 
            {
                musicSources.Add(source);
            }
        }
        foreach(AudioSource source in inspectorGameSounds)
        {
            if(source != null && !gameSounds.Contains(source)) 
            {
                gameSounds.Add(source);
            }
        }
        var soundVol = PlayerPrefs.GetFloat("SoundVolume");
        var musicVol = PlayerPrefs.GetFloat("MusicVolume");
        SetGameSoundsVolume(soundVol);
        SetMusicVolume(musicVol);
        soundSlider.value = soundVol;
        musicSlider.value = musicVol;
    }
    public static void SetAllToDefault()
    {
        SetGameSoundsVolume(0.75f); //used PlayerPrefs here instead of json as experiment
        PlayerPrefs.SetFloat("MusicVolume", 0.75f);
        PlayerPrefs.SetFloat("SoundVolume", 0.75f);

        PlayerPrefs.Save();
    }
    public static void SetGameSoundsVolume(float volume)
    {
        if (volume < 0f || volume > 1f)
        {
            Debug.LogWarning("Tried to set volume to " + volume.ToString());
            volume = Mathf.Clamp01(volume);
            return;
        }
        PlayerPrefs.SetFloat("SoundVolume", volume);

        foreach (var sound in gameSounds)
        {
            sound.volume = volume;
        }
    }
    public static void SetMusicVolume(float volume)
    {
        if (volume < 0f || volume > 1f)
        {
            Debug.LogWarning("Tried to set volume to " + volume.ToString());
            volume = Mathf.Clamp01(volume);
            return;
        }
        PlayerPrefs.SetFloat("MusicVolume", volume);
        foreach (var music in musicSources)
        {
            music.volume = volume;
        }
    }
}
