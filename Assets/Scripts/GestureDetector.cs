using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[System.Serializable]
public struct Gesture
{
    public string name;
    public List<Vector3> fingerData;
    public UnityEvent onRecongnized;
}
public class GestureDetector : MonoBehaviour
{
    public float treshold = 0.1f;
    public OVRSkeleton skeleton;
    public List<Gesture> gestures;
    private List<OVRBone> fingerBones;
    private Gesture previousGesture;
    private bool thereAreBones;
    public Text infoText;
    // Start is called before the first frame update
    void Start()
    {
        fingerBones = new List<OVRBone>(skeleton.Bones);
        previousGesture = new Gesture();
    }

    // Update is called once per frame
    void Update()
    {

        if (!thereAreBones)
        {
            FindBones();
        }

        if (thereAreBones)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Save();
            }
        }

        Gesture currentGesture = Recognize();
        bool hasRecognized = !currentGesture.Equals(new Gesture());

        if (hasRecognized && !currentGesture.Equals(previousGesture))
        {
            Debug.Log("Current Gesture: " + currentGesture.name);
            infoText.text = currentGesture.name;
            previousGesture = currentGesture;
            currentGesture.onRecongnized.Invoke();
        }
    }


    void Save()
    {
        Gesture g = new Gesture();
        g.name = "New Gesture";

        List<Vector3> data = new List<Vector3>();

        foreach (var bone in fingerBones)
        {
            data.Add(skeleton.transform.InverseTransformPoint(bone.Transform.position));
        }

        g.fingerData = data;

        gestures.Add(g);
    }

    Gesture Recognize()
    {
        Gesture currentGesture = new Gesture();
        float currentMin = Mathf.Infinity;

        foreach (var gesture in gestures)
        {
            float sumDistance = 0;
            bool isDiscarded = false;
            for (int i = 0; i < fingerBones.Count; i++)
            {
                Vector3 currentData = skeleton.transform.InverseTransformPoint(fingerBones[i].Transform.position);
                float distance = Vector3.Distance(currentData, gesture.fingerData[i]);
                if (distance > treshold)
                {
                    isDiscarded = true;
                    break;
                }

                sumDistance += distance;
            }

            if (!isDiscarded && sumDistance < currentMin)
            {
                currentMin = sumDistance;
                currentGesture = gesture;
            }
        }
        return currentGesture;
    }

    void FindBones()
    {
        if (skeleton.Bones.Count > 0)
        {
            fingerBones = new List<OVRBone>(skeleton.Bones);
            thereAreBones = true;
        }
    }
}
