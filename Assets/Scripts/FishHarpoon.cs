using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class FishHarpoon : MonoBehaviour
{
    public GameObject fish1Prefab;

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Harpoon")
        {
            // destroyFish = false;
            Debug.Log("Harpooned!");
            // this.transform.parent = other.transform;
            GameObject clone = Instantiate(fish1Prefab, other.transform); // create an instance of the blood splatter
        }
    }
}
