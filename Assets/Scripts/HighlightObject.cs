using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighlightObject : MonoBehaviour
{
    private GameObject[] Objectives;
    public GameObject Effect;

    // Start is called before the first frame update
    void Start()
    {
        Objectives = GameObject.FindGameObjectsWithTag("Objective");
        Effect = gameObject;
        
    }

    // Update is called once per frame
    void Update()
    {
        Objectives = GameObject.FindGameObjectsWithTag("Objective");
        Vector3 ObjectPos = Objectives[0].transform.position;
        ObjectPos = new Vector3(ObjectPos.x, ObjectPos.y + 0.4f, ObjectPos.z);
        Effect.transform.position = ObjectPos;
    }
}
