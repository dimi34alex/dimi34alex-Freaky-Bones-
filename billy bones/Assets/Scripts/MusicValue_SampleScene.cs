using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicValue_SampleScene : MonoBehaviour
{
    private AudioSource audio;
    public float audio_volume = 1f;

    public void Get_volume()
    {
        audio_volume = MusicValue.data_volume;
    }

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        audio.volume = MusicValue.data_volume;
    }
}
