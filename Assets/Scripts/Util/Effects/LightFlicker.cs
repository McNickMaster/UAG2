using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public Light light;

    public float flickerTime = 5f;

    // Start is called before the first frame update
    void Awake()
    {
        InvokeRepeating("DoubleFlicker", Random.Range(0.5f, 3), flickerTime);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Flicker()
    {
        Off();
        Invoke("On", 0.3f);

    }

    void DoubleFlicker()
    {
        Flicker();
        Flicker();
        Invoke("Flicker", 0.1f);
    }


    void On()
    {
        light.enabled = true;
    }

    void Off()
    {
        light.enabled = false;
    }


}
