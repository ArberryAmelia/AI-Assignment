using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimationControl : MonoBehaviour
{
    public Animator rightHandAnimator;

    public Animator leftHandAnimator;

    public InputActionReference rightControllerTriggerReference;

    public InputActionReference rightControllerGripReference;

    public InputActionReference leftControllerTriggerReference;

    public InputActionReference leftControllerGripReference;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float valueRightTriggerRef = rightControllerTriggerReference.action.ReadValue<float>();
        Debug.Log("rightControllerTriggerReference = " + valueRightTriggerRef);

        float valueRightGripRef = rightControllerGripReference.action.ReadValue<float>();
        Debug.Log("rightControllerGripReference = " + valueRightGripRef);

        float valueLeftTriggerRef = leftControllerTriggerReference.action.ReadValue<float>();
        Debug.Log("leftControllerTriggerReference = " + valueLeftTriggerRef);

        float valueLeftGripRef = leftControllerGripReference.action.ReadValue<float>();
        Debug.Log("leftControllerGripReference = " + valueLeftGripRef);

        if(valueRightTriggerRef > 0f)
        {
            rightHandAnimator.SetInteger("Trigger", 1);
        }
        else if (valueRightTriggerRef < 1f)
        {
            rightHandAnimator.SetInteger("Trigger", 0);
        }

        if(valueRightGripRef > 0f)
        {
            rightHandAnimator.SetInteger("Grip", 1);
        }
        else if (valueRightGripRef < 1f)
        {
            rightHandAnimator.SetInteger("Grip", 0);
        }

        if(valueLeftTriggerRef > 0f)
        {
            leftHandAnimator.SetInteger("Trigger", 1);
        }
        else if(valueLeftTriggerRef < 1f)
        {
            leftHandAnimator.SetInteger("Trigger", 0);
        }

        if(valueLeftGripRef > 0f)
        {
            leftHandAnimator.SetInteger("Grip", 1);
        }
        else if(valueLeftGripRef < 1f)
        {
            leftHandAnimator.SetInteger("Grip", 0);
        }
    }
}
