using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGestureGrab : MonoBehaviour
{
    [SerializeField]
    GameObject[] GestureComponents;
    [SerializeField]
    GameObject[] HandComponents;
    bool SwitchBetweenHandAndGestureBool;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SwitchGestureGrabMethod();
    }

    void DisableHandComponent()
    {
        foreach (GameObject item in HandComponents)
        {
            item.SetActive(false);
        }
    }

    void DisableGestureComponent()
    {
        foreach (GameObject item in GestureComponents)
        {
            item.SetActive(false);
        }
    }
    void SwitchGestureGrabMethod()
    {
        if (OVRInput.GetDown(OVRInput.Button.Two))
        {
            if (SwitchBetweenHandAndGestureBool)
            {
                DisableHandComponent();
                foreach (GameObject item in GestureComponents)
                {
                    item.SetActive(true);
                }
            }
            else
            {
                DisableGestureComponent();
                foreach (GameObject item in HandComponents)
                {
                    item.SetActive(true);
                }
            }
            SwitchBetweenHandAndGestureBool = !SwitchBetweenHandAndGestureBool;
            Debug.Log("Pressed button B");
        }

    }
}
