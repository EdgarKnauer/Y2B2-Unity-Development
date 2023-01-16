using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;


public class HandController : MonoBehaviour
{
    [SerializeField] private XRNode leftController;
    [SerializeField] private XRNode rightController;

    private bool leftTriggerPressed;
    private bool rightTriggerPressed;

    [SerializeField] private GameObject hand;
    private PlayerController playerController;
    [SerializeField] private Transform grabbedObjHandTransform;
    [SerializeField] private Transform classroomParentTransform;

    private GameObject objLeftHand;
    private GameObject objRightHand;

    [SerializeField] private bool objGrabbedLH = false;
    [SerializeField] private bool objGrabbedRH = false;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        InputDevice leftDevice = InputDevices.GetDeviceAtXRNode(leftController);
        InputDevice rightDevice = InputDevices.GetDeviceAtXRNode(rightController);

        leftDevice.TryGetFeatureValue(CommonUsages.triggerButton, out leftTriggerPressed);
        rightDevice.TryGetFeatureValue(CommonUsages.triggerButton, out rightTriggerPressed);
    }


    private void OnTriggerStay(Collider other)
    {
        if(other.GetComponent<InteractableObject>())
        {
            if (!objGrabbedLH)
            {
                if (leftTriggerPressed && hand.name == "LeftHand Controller" && !other.GetComponent<InteractableObject>().isGrabbed)
                {
                    other.transform.position = grabbedObjHandTransform.position;
                    other.transform.rotation = grabbedObjHandTransform.rotation;
                    other.transform.parent = grabbedObjHandTransform;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                    other.GetComponent<InteractableObject>().isGrabbed = true;

                    playerController.grabbedObjLeftHand = other.gameObject;
                    objLeftHand = other.gameObject;

                    objGrabbedLH = true;
                }
            }

            else
            {
                if (!leftTriggerPressed && hand.name == "LeftHand Controller")
                {
                    if (objLeftHand != null)
                    {
                        other.transform.parent = classroomParentTransform;
                        other.GetComponent<Rigidbody>().isKinematic = false;
                        other.GetComponent<InteractableObject>().isGrabbed = false;

                        playerController.grabbedObjLeftHand = null;
                        objLeftHand = null;
                        objGrabbedLH = false;
                    }
                }
            }

            if (!objGrabbedRH)
            {
                if (rightTriggerPressed && hand.name == "RightHand Controller" && !other.GetComponent<InteractableObject>().isGrabbed)
                {
                    other.transform.position = grabbedObjHandTransform.position;
                    other.transform.rotation = grabbedObjHandTransform.rotation;
                    other.transform.parent = grabbedObjHandTransform;
                    other.GetComponent<Rigidbody>().isKinematic = true;
                    other.GetComponent<InteractableObject>().isGrabbed = true;

                    playerController.grabbedObjRightHand = other.gameObject;
                    objRightHand = other.gameObject;

                    objGrabbedRH = true;
                }
            }

            else
            {
                if (!rightTriggerPressed && hand.name == "RightHand Controller")
                {
                    if (objRightHand != null)
                    {
                        other.transform.parent = classroomParentTransform;
                        other.GetComponent<Rigidbody>().isKinematic = false;
                        other.GetComponent<InteractableObject>().isGrabbed = false;

                        playerController.grabbedObjRightHand = null;
                        objRightHand = null;
                        objGrabbedRH = false;
                    }
                }
            }
        }
    }
}
