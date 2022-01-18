using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    RaycastHit hit;
    [SerializeField] private Transform ground;
    [SerializeField] private GameObject speakerPrefab;
    [SerializeField] private GameObject speakerTransparent;

    private GameObject suggestedPrefab = null;

    bool readyToPlaceSpeaker = false;
    bool collidingWithSpeaker = false;

    void Update()
    {
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit))
        {

            if (hit.transform == ground)
            {
                if (suggestedPrefab != null)
                {
                    Destroy(suggestedPrefab);                   
                }
                suggestedPrefab = Instantiate(speakerTransparent, hit.point, Quaternion.identity);
                readyToPlaceSpeaker = true;

            }

            else
            {
                readyToPlaceSpeaker = false;
                if (suggestedPrefab != null)
                {
                    Destroy(suggestedPrefab);
                }
            }

        }
    }

    public void PlaceSpeaker()
    {
        if (readyToPlaceSpeaker && !collidingWithSpeaker)
        {
            Instantiate(speakerPrefab, suggestedPrefab.transform.position, Quaternion.identity);
            Debug.Log("speaker placed");
        }
    }
}
