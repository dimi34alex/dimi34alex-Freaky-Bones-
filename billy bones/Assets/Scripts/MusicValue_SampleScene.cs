using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicValue_SampleScene : MonoBehaviour
{
    private AudioSource audio;
    public static float audio_volume;

    public void SetVolume(float vol)
    {
        audio_volume = vol;
    }

    public void Get_volume()
    {
        audio_volume = MusicValue.data_volume;
    }

    void Start()
    {
        Get_volume();
        audio = GetComponent<AudioSource>();
        audio.volume = MusicValue.data_volume;
    }

    void Update()
    {
        audio.volume = audio_volume;
    }
}
