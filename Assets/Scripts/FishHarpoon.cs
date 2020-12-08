using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishHarpoon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Harpoon")
        {
            Debug.Log("Harpooned!");
            this.transform.parent = other.transform;
        }
    }
}
