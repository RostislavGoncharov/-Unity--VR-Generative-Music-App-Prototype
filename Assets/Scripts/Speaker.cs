using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speaker : MonoBehaviour
{
    private AudioSource audioSource;
    private SoundManager soundManager;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        audioSource.clip = soundManager.loops[Random.Range(0, soundManager.loops.Length)];
        audioSource.Play();
    }
}
