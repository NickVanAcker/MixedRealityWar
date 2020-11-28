using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabInteraction : MonoBehaviour
{
    public GameObject HandL;
    public GameObject[] Objectives;

    public TableToInstructor TTI;

    Vector3 grabPos;
    public int CompletedObjectives;
    public float timeRemaining = 5;
    // Start is called before the first frame update
    void Start()
    {
        HandL = GameObject.FindGameObjectWithTag("hand");
        TTI = GameObject.FindGameObjectWithTag("TTIScript").GetComponent<TableToInstructor>();
    }

    // Update is called once per frame
    void Update()
    {
        Objectives = GameObject.FindGameObjectsWithTag("Objective");


        if (TTI.ObjToGrab != null)
        {
            grabPos = HandL.transform.position;
            grabPos = new Vector3(grabPos.x, grabPos.y - 0.05f, grabPos.z);

            TTI.ObjToGrab.transform.position = grabPos;
            TTI.ObjToGrab.transform.localRotation = new Quaternion(-0.2f,-0.8f, 0.14f, 0.6f);

            if (timeRemaining > 0 && TTI.ObjToGrab.gameObject.tag == "Done")
            {
                timeRemaining -= Time.deltaTime;

                if (timeRemaining < 0.2)
                {
                    Object.Destroy(GameObject.FindGameObjectWithTag("Done"));
                    CompletedObjectives++;
                    timeRemaining = 5;
                }

            }
        }
    }
}
