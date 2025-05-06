using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class SaveSettings
{
    public float masterVolume;
    public float musicVolume;
    public float soundVolume;
    public float speechVolume;
}

public class Settings : MonoBehaviour
{
    public SaveSettings settingsInfo;

    public Slider masterVolume;
    public Slider musicVolume;
    public Slider soundVolume;
    public Slider speechVolume;

    void Start()
    {
        settingsInfo.masterVolume = masterVolume.value;
        settingsInfo.musicVolume = musicVolume.value;
        settingsInfo.soundVolume = soundVolume.value;
        settingsInfo.speechVolume = speechVolume.value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Load(SaveSettings newSettings)
    {
        settingsInfo = newSettings;
        masterVolume.value = settingsInfo.masterVolume;
        musicVolume.value = settingsInfo.musicVolume;
        soundVolume.value = settingsInfo.soundVolume;
        speechVolume.value = settingsInfo.speechVolume;
    }
}
