using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    RaycastHit hit;
    public Transform ground;
  

    void Update()
    {
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
        {
            //Debug.Log(hit.distance);

            if (hit.transform == ground)
            {
                Debug.Log("This is ground");
            }
        } 
    }
}
