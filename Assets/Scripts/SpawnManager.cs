using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject spherePrefab;
    void Start()
    {
        StartCoroutine(SpawnSpheres());
    }


    IEnumerator SpawnSpheres()
    {
        int sphereNumber = Random.Range(5, 16);

        for (int i = 0; i <= sphereNumber; i++)
        {
            float randomX = Random.Range(-10.0f, 10.0f);
            float randomY = Random.Range(2.0f, 18.0f);
            float randomZ = Random.Range(-10.0f, 10.0f);
            float randomRotation = Random.Range(0, 180.0f);
            float randomInterval = Random.Range(1.0f, 7.0f);

            Vector3 startPosition = new Vector3(randomX, randomY, randomZ);

            Instantiate(spherePrefab, startPosition, Quaternion.Euler(randomRotation, randomRotation, randomRotation));

            yield return new WaitForSeconds(randomInterval);
        }
    }
}
