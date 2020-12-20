using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HarpoonImpact : MonoBehaviour
{
    public AudioSource wetSplat;

    // Start is called before the first frame update
    void Start()
    {
        wetSplat = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "NVBoidsFishCatchable")
        {
            wetSplat.Play();
        }

        if (collision.gameObject.tag == "Fish0Pref1")
        {
            wetSplat.Play();
        }

        if (collision.gameObject.tag == "NVBoidsFish")
        {
            wetSplat.Play();
        }
    }
}
