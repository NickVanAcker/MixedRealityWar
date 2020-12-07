using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBetweenXRAndOVR : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject XRRig;
    public GameObject OVRRig;
    private bool enable;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            enable = !enable;
            if (enable)
            {
                XRRig.gameObject.SetActive(false);
                OVRRig.gameObject.SetActive(true);
            }
            else if (!enable)
            {
                OVRRig.gameObject.SetActive(false);
                XRRig.gameObject.SetActive(true);
            }
        }
    }
}
