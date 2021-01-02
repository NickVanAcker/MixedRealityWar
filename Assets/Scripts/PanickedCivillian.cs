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
    bool isBeingCalmed = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();

        animator = gameObject.GetComponent<Animator>();

        Speak();
        hasSpoken = false;
        index++;
    }        

    // Update is called once per frame
    void Update()
    {
        if(time < 20)
            isBeingCalmed = false;

        if (index == 11)
            index = 0;
        time += Time.deltaTime;

        if (isBeingCalmed && isPanicking)
        {
           
            CalmDown();
        }


        if (isBeingCalmed == false)
        {
            if ((time > 60 && time < 62) || animator.GetBool("TakeInitiative"))
            {
                isPanicking = true;
                Panic();
            }
        }
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

    public void CalmDown()
    {
        isBeingCalmed = true;
        if ((isBeingCalmed == true && isPanicking == true) &&(animator.GetBool("TakeInitiative") == true && animator.GetBool("IsPanicking") == true)||(animator.GetBool("TakeInitiative") == false && animator.GetBool("IsPanicking"))) //condition for handsignal
        {
            animator.SetBool("TakeInitiative", false);
            transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime * walkSpeed);
        }

        if (isPanicking == true && (animator.GetBool("TakeInitiative") == false && animator.GetBool("IsPanicking") == false))
        {
            isPanicking = false;
            time = 0;
            hasSpoken = false;
            index++;
            isBeingCalmed = false;
        }
    }
    
}
