using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSphere : MonoBehaviour
{
    Rigidbody sphereRb;
    AudioSource audioSource;
    [SerializeField] float speed;

    SoundManager soundManager;

    void Start()
    {
        sphereRb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

        if (sphereRb == null)
        {
            Debug.Log("Rigidbody is null");
        }

        if (audioSource == null)
        {
            Debug.Log("AudioSource is null");
        }

        if (soundManager == null)
        {
            Debug.Log("SoundManager is null");
        }

        audioSource.clip = soundManager.loops[Random.Range(0, soundManager.loops.Length)];
        audioSource.volume = Random.Range(0.7f, 1.0f);
        audioSource.Play();

        speed = Random.Range(0.5f, 1.0f);

        StartCoroutine(MovementZ());
        StartCoroutine(MovementX());
        StartCoroutine(MovementY());
        StartCoroutine(ChangeSpeed());

        Vector3 initDirection = new Vector3(0, 0, -1);

        sphereRb.AddRelativeForce(initDirection * speed, ForceMode.Impulse); 
    }

    private void Update()
    {
        if (sphereRb.velocity.z > 3.0)
        {
            sphereRb.AddRelativeForce(0, 0, -2);
        }

        if (sphereRb.velocity.z < -3.0)
        {
            sphereRb.AddRelativeForce(0, 0, 2);
        }

        if (sphereRb.velocity.x > 3.0)
        {
            sphereRb.AddRelativeForce(-2, 0, 0);
        }

        if (sphereRb.velocity.x < -3.0)
        {
            sphereRb.AddRelativeForce(2, 0, 0);
        }
    }

    IEnumerator MovementZ()
    {
        while (true)
        {
            if (transform.position.z <= -27)
            {
                Vector3 direction = new Vector3(0, 0, 1);
                sphereRb.AddForce(direction * speed, ForceMode.Force);
            }

            else if (transform.position.z >= 27)
            {
                Vector3 direction = new Vector3(0, 0, -1);
                sphereRb.AddForce(direction * speed, ForceMode.Force);
            }

            else if (transform.position.z > -27 && transform.position.z < 27)
            {
                Vector3 currentVelocity = sphereRb.velocity.normalized;
                sphereRb.AddForce(currentVelocity, ForceMode.Force);
            }

            yield return null;
        }
    }

    IEnumerator MovementX()
    {
        while (true)
        {
            if (transform.position.x <= -27)
            {
                Vector3 direction = new Vector3(1, 0, 0);
                sphereRb.AddForce(direction * speed, ForceMode.Force);
            }

            else if (transform.position.x >= 27)
            {
                Vector3 direction = new Vector3(-1, 0, 0);
                sphereRb.AddForce(direction * speed, ForceMode.Force);
            }

            else if (transform.position.x > -27 && transform.position.x < 27)
            {
                Vector3 currentVelocity = sphereRb.velocity.normalized;
                sphereRb.AddForce(currentVelocity, ForceMode.Force);
            }

            yield return null;
        }
    }

    IEnumerator MovementY()
    {
        while (true)
        {
            if (transform.position.y <= -15)
            {
                Vector3 direction = new Vector3(0, 1, 0);
                sphereRb.AddForce(direction * speed, ForceMode.Force);
            }

            else if (transform.position.y >= 35)
            {
                Vector3 direction = new Vector3(0, -1, 0);
                sphereRb.AddForce(direction * speed, ForceMode.Force);
            }

            yield return null;
        }
    }

    IEnumerator ChangeSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(5);

            speed = Random.Range(0.5f, 1.2f);
        }
    }
}
