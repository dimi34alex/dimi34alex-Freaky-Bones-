using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicValue : MonoBehaviour
{
    private AudioSource audio;
    public static float audio_volume = 1f;
    public static float data_volume;

    public void SetVolume(float vol)
    {
        audio_volume = vol;
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        audio.volume = audio_volume;
        data_volume = audio_volume;
    }
}

/*public static class VolumeData
{
    public static float data_volume = MusicValue.audio_volume;
}*/