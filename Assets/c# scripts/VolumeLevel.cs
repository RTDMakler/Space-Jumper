using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeLevel : MonoBehaviour
{
    private AudioSource audioSource;
    private float musicVolume = 1f;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (PlayerPrefs.HasKey(User.UserName + "audioVolume"))
        {
            audioSource.volume = LoadAndSave.LoadFloat(User.UserName + "audioVolume");
            musicVolume = audioSource.volume;
        }  
    }
    void Update()
    {
        audioSource.volume = musicVolume;
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;
        LoadAndSave.Save(vol, User.UserName+ "audioVolume");
    }
    public void SetVolumeForButtons()
    {
        musicVolume = LoadAndSave.LoadFloat(User.UserName + "audioVolume");
    }
    public float SetVolume()
    {
        musicVolume = LoadAndSave.LoadFloat(User.UserName + "audioVolume");
        return musicVolume;
    }
}

