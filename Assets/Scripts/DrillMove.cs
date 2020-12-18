using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Rendering.PostProcessing;

public class DrillMove : LocomotionProvider
{
    public List<XRController> controllers = null;

    bool triggerValue;

    public MovementProvider moveScript;

    public int boostSpeed = 30;

    public GameObject drillBit;

    public float drillSpeed = 1000;

    public Camera XRCamera;

    private void Update()
    {
        CheckForInput();
    }


    private void CheckForInput()
    {
        foreach(XRController controller in controllers)
        {
            if (controller.enableInputActions)
                CheckForTrigger(controller.inputDevice);
        }
    }

    private void CheckForTrigger(InputDevice device)
    {
        if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue) && triggerValue)
            DrillSpin(triggerValue);
        else
        {
            moveScript.speed = 5;
            XRCamera.GetComponent<PostProcessVolume>().enabled = false; // turns on the grain effect
        }
            
    }

    private void DrillSpin(bool triggerValue)
    {
        if (triggerValue == true)
        {
            moveScript.speed = boostSpeed; // adjust the movescript speed
            XRCamera.GetComponent<PostProcessVolume>().enabled = true; // turns on the grain effect
            drillBit.transform.Rotate(0, 0, -Time.smoothDeltaTime * drillSpeed);
        }
    }
}