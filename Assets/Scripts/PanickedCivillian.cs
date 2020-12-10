using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanickedCivillian : MonoBehaviour
{
    public AudioClip[] clips;

    public Animator animator;
    float walkSpeed = 2.5f;
    float time;
    AudioSource audio;
    int index = 0;

    bool isPanicking = false;
    bool hasSpoken = false;


    // Start is called before the first frame update
    void Start()
    {


        audio = GetComponent<AudioSource>();

        animator = gameObject.GetComponent<Animator>();
    }        

    // Update is called once per frame
    void Update()
    {
        if (index == 11)
            index = 0;
        time += Time.deltaTime;

        if ((time > 60 && time < 70) || animator.GetBool("TakeInitiative"))
        {
            isPanicking = true;
            Panic();
        }

        CalmDown();


    }

    void Panic()
    {
        animator.SetBool("TakeInitiative", true);
        if (animator.GetBool("TakeInitiative") && animator.GetBool("IsPanicking") == false)
            transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime * walkSpeed);


        Speak();

    }


    void Speak()
    {
        if (!hasSpoken)
        {
            audio.clip = clips[index];
            audio.Play();
            hasSpoken = true;
        }
    }

    void CalmDown()
    {
        if ((time > 71 && isPanicking == true) && (animator.GetBool("TakeInitiative") == true && animator.GetBool("IsPanicking") == true)) //condition for handsignal
        {
            animator.SetBool("GoBack", true);
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * walkSpeed);
            index++;

        }

        if(isPanicking == true && (animator.GetBool("TakeInitiative") == false && animator.GetBool("IsPanicking") == false))
        {
            isPanicking = false;
            time = 0;
            hasSpoken = false;
        }
    }
    
}
