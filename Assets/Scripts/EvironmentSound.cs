using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvironmentSound : MonoBehaviour
{

    public AudioClip[] ShootingSound;
    public AudioClip[] ExplossionSound;
    public AudioClip[] Groans;

    private int i = 0;
    private int j = 0;
    private int k = 0;

    private int iMax = 5;
    private int jMax = 8;
    private int kMax = 4;

    private bool hasHappenedI = false;
    private bool hasHappenedJ = false;
    private bool hasHappenedK = false;

    float timeI;
    float timeJ;
    float timeK;
    float time;
    int count = 0;

    AudioSource audio1;
    AudioSource audio2;
    AudioSource audio3;

    // Start is called before the first frame update
    void Start()
    {
        audio3 = gameObject.transform.GetChild(3).GetComponent<AudioSource>();
        audio2 = gameObject.transform.GetChild(1).GetComponent<AudioSource>();
        audio1 = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        timeI += Time.deltaTime;
        timeJ += Time.deltaTime;
        timeK += Time.deltaTime;
        //Debug.Log(time);


        if (!hasHappenedI)
        {
            ShootingSoundClip(i);

        }
        if(timeI > 16 && timeI < 17)
        {
            Debug.Log("done");
            hasHappenedI = false;
            timeI = 0;
            i++;
            if (i == iMax)
                i = 0;
        }

        if (!hasHappenedJ)
        {
            ExplossionSoundClip(j);

        }
<<<<<<< HEAD
        if (timeJ > 12 && timeJ < 13)
=======
        if (timeJ > 21 && timeJ < 22)
>>>>>>> parent of f8b08ee... fixed soundbug
        {
            Debug.Log("done");
            hasHappenedJ = false;
            timeJ = 0;
            j++;
            if (j == jMax)
                j = 0;
        }


        if (!hasHappenedK)
        {
            GroansAndMoansClip(k);

        }
        if (timeK > 13 && timeK < 15)
        {
            Debug.Log("done");
            hasHappenedK = false;
            timeK = 0;
            k++;
            if (k == kMax)
                k = 0;

        }

        if(time > 5)
        {
            count++;
            if (count > 2)
                count = 0;
            ChangeSource();
        }
    }


    void ShootingSoundClip(int index)
    {

        audio1.clip = ShootingSound[index];

        audio1.PlayDelayed(14);
        hasHappenedI = true;
    }

    void ExplossionSoundClip(int index)
    {

        audio2.clip = ExplossionSound[index];

        audio2.PlayDelayed(20);
        hasHappenedJ = true;
    }
    void GroansAndMoansClip(int index)
    {

        audio3.clip = Groans[index];

        audio3.PlayDelayed(10);

        hasHappenedK = true;
    }

    void ChangeSource()
    {
        if (count == 0)
        {
            audio3 = gameObject.transform.GetChild(3).GetComponent<AudioSource>();
            audio2 = gameObject.transform.GetChild(1).GetComponent<AudioSource>();
            audio1 = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
        }

        if (count == 1)
        {
            audio3 = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
            audio2 = gameObject.transform.GetChild(3).GetComponent<AudioSource>();
            audio1 = gameObject.transform.GetChild(1).GetComponent<AudioSource>();
        }

        if (count == 2)
        {
            audio3 = gameObject.transform.GetChild(1).GetComponent<AudioSource>();
            audio2 = gameObject.transform.GetChild(0).GetComponent<AudioSource>();
            audio1 = gameObject.transform.GetChild(3).GetComponent<AudioSource>();
        }
        time = 0;
    } 
        
}
