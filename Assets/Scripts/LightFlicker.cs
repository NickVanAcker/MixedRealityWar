using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public Light[] lights;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    public IEnumerator Flicker()
    { 
        OffOrOn();
        yield return new WaitForSeconds(0.1f);
        OffOrOn();
        yield return new WaitForSeconds(0.1f);
        OffOrOn();
        yield return new WaitForSeconds(0.1f);
        OffOrOn();



    }


    void OffOrOn()
    {
        if (lights[0].enabled == true)
        {
            lights[0].enabled = false;
            lights[3].enabled = false;
            lights[2].enabled = false;
            lights[1].enabled = false;
            lights[4].enabled = false;
        }
        else
        {
            lights[0].enabled = true;
            lights[3].enabled = true;
            lights[2].enabled = true;
            lights[1].enabled = true;
            lights[4].enabled = true;
        }
    }
}
