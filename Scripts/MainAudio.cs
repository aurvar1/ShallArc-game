using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudio : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip game2;
    public AudioClip game3;

    void Update()
    {
        if (Time.time >= 60 && Time.time <= 62)
        {
            audio.clip = game2;
            audio.Play();
        }
        if (Time.time >= 120 && Time.time <= 122)
        {
            audio.clip = game3;
            audio.Play();
        }
    }
}
