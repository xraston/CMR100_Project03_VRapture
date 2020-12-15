using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ShootHarpoon : MonoBehaviour
{
    public List<XRController> controllers = null;
    public bool triggerValue;
    public bool buttonValue;

    public float speedOut;
    public float speedIn;

    public GameObject spool;
    public int spoolSpeed = 180;

    public FishHarpoon fishScript;

    public void Update()
    {
        CheckForInput();
    }

    public void CheckForInput()
    {
        foreach (XRController controller in controllers)
        {
            if (controller.enableInputActions)
                CheckForTrigger(controller.inputDevice);
                CheckForGrip(controller.inputDevice);
        }
    }

    public void CheckForGrip(InputDevice device)
    {
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out buttonValue) && buttonValue)
            DestroyFish(buttonValue);
    }

    public void DestroyFish(bool buttonValue)
    {
        if (buttonValue == true)
        {
            GameObject[] fishClones = GameObject.FindGameObjectsWithTag("Clone");

            if(fishClones.Length < 10)
            {
                foreach (GameObject go in fishClones)
                {
                    Destroy(go);
                    Debug.Log("Destroy Fish");
                }
            }

        }
        else
        {
            buttonValue = false;
        }
    }

    public void CheckForTrigger(InputDevice device)
    {
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            MoveHarpoon(triggerValue);
        else
        {
            transform.Translate(Vector3.back * speedIn * Time.deltaTime);

            spool.transform.Rotate(-Time.smoothDeltaTime * speedIn * spoolSpeed, 0, 0);

            if (transform.localPosition.z <= 0.1)
            {
                transform.localPosition = new Vector3(0.018f, 0.038f, 0.1f);
                // spool.transform.Rotate(0f, 0f, 0f, Space.Self);
                spool.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }

    public void MoveHarpoon(bool triggerValue)
    {
        if (triggerValue == true)
        {
            transform.Translate(Vector3.forward * speedOut * Time.deltaTime);

            spool.transform.Rotate(Time.smoothDeltaTime * speedOut * spoolSpeed, 0, 0);
            
            if (transform.localPosition.z >= 1)
            {
                transform.localPosition = new Vector3(0.018f, 0.038f, 1);
                // spool.transform.Rotate(0f, 0f, 0f, Space.Self);
                spool.transform.rotation = new Quaternion(0, 0, 0, 0);
            }
        }
    }
}
