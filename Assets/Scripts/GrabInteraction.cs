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

    public AudioClip AskForObjective0;
    public AudioClip AskForObjective1;
    public AudioClip AskForObjective2;
    public AudioClip AskForObjective3;

    public AudioClip ThankYouClip;

    private bool HasSpoken = false;

    public AudioClip[] AskForObjectives;


    // Start is called before the first frame update
    void Start()
    {
        AskForObjectives = new AudioClip[4] { AskForObjective0, AskForObjective1, AskForObjective2, AskForObjective3 };

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
                    SayThankYou();
                }

            }
        }

        InstructorSpeaks();
    }

    void InstructorSpeaks()
    {
        if (HasSpoken == false)
        {
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = AskForObjectives[CompletedObjectives];
            Debug.Log(CompletedObjectives);
            audio.PlayDelayed(3);
            HasSpoken = true;
        }
    }
    
    void SayThankYou()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.clip = ThankYouClip;
        audio.PlayDelayed(1);
        HasSpoken = false;
    }
}
