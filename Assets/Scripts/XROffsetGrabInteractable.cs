using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable
{
    private Vector3 initalAttackLocalPos;
    private Quaternion initalAttachLocalRot;
    // Start is called before the first frame update
    void Start()
    {
        //Create attach point
        if (!attachTransform)
        {
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;
        }

        initalAttackLocalPos = attachTransform.localPosition;
        initalAttachLocalRot = attachTransform.localRotation;
    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)
    {
        if (interactor is XRDirectInteractor)
        {
            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;
        }
        else
        {
            attachTransform.localPosition = initalAttackLocalPos;
            attachTransform.localRotation = initalAttachLocalRot;

        }
        base.OnSelectEnter(interactor);
    }


}
