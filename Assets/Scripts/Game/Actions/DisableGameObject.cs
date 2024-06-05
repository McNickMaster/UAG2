using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableGameObject : Action
{
    
    public GameObject obj;

    public bool delay = false;
    public float delay_time = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public override void Action_Start()
    {
        if(delay)
        {
            delay = false;
            Invoke("Action_Start", delay_time);
        }
        else{
            obj.SetActive(false);
        }
        //play effect
    }

    
}
