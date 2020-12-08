using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class DrillMove : LocomotionProvider
{
    public List<XRController> controllers = null;

    bool triggerValue;

    public MovementProvider moveScript;

    public int boostSpeed = 30;

    public GameObject drillBit;

    public float drillSpeed = 1000;

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
        }
            
    }

    private void DrillSpin(bool triggerValue)
    {
        if (triggerValue == true)
        {
            moveScript.speed = boostSpeed; // adjust the movescript speed

            drillBit.transform.transform.Rotate(0, 0, -Time.deltaTime * drillSpeed);
        }
    }
}