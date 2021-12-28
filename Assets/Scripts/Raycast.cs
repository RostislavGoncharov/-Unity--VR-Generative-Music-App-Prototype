using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    RaycastHit hit;
    [SerializeField] private Transform ground;
    [SerializeField] private GameObject speakerPrefab;

    private GameObject suggestedPrefab;

    void Update()
    {
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
        {
            //Debug.Log(hit.distance);

            if (hit.transform == ground)
            {
                //Instatntiate the prefab
            }

        } 
    }
}
