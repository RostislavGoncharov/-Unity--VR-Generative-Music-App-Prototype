using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCube : MonoBehaviour
{
    AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayStem()
    {
        audioSource.Play();
    }

    public void StopStem()
    {
        audioSource.Stop();
    }
}
