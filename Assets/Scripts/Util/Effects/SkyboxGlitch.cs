using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxGlitch : MonoBehaviour
{
    public static SkyboxGlitch instance;

    public float repeatTime = 20;
    public float flashTime = 0.1f;
    public Material normalSky, glitchedSky;
    private Material activeSky;

    int x = 0;

    void Awake()
    {
        instance = this;

        InvokeRepeating("CheckGlitch", 0, repeatTime);
    }

    void Start()
    {

    }

    void Update()
    {
        if(Input.GetKey(KeyCode.Semicolon) && Input.GetKeyDown(KeyCode.Alpha1))
        {
            ActivateGlitch();
        }
    }

    void CheckGlitch()
    {
        x = Random.Range(0, 255);

        if(x == 213)
        {
            ActivateGlitch();
        }
        
    }

    public void ActivateGlitch()
    {
        SetGlitched();
        Invoke("SetNormal", flashTime);
    }


    void SetGlitched()
    {
        activeSky = glitchedSky;
        RenderSettings.skybox = activeSky;
    }
    void SetNormal()
    {
        activeSky = normalSky;
        RenderSettings.skybox = activeSky;
    }
}
