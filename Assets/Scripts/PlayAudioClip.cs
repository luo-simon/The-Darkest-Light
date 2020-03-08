using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioClip : MonoBehaviour
{
    public AudioSource audioSource;

    void PlayAudio()
    {
        audioSource.enabled = true;
    }
}
