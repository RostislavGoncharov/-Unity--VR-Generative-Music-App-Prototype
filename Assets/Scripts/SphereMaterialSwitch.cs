using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereMaterialSwitch : MonoBehaviour
{
    [SerializeField] private Material matNormal;
    [SerializeField] private Material matGlow;
    MeshRenderer meshRenderer;

   
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        if (meshRenderer != null)
        {
            meshRenderer.material = matNormal;
        } 
    }


    public void SetToGlow()
    {
        meshRenderer.material = matGlow;
    }

    public void SetToNormal()
    {
        meshRenderer.material = matNormal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Socket")
        {
            SetToGlow();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Socket")
        {
            SetToNormal();
        }   
    }
}
