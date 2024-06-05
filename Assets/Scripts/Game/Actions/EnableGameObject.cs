using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.enums;

public class EnableGameObject : Action
{
    
    public GameObject obj;

    public bool startObjAnimation = false;
    public GameStates thisState;

    public bool shouldObjectRespawnOnReEnter = false;

    public bool delay = false;
    public float delay_time = 1;

    void Awake()
    {

        if(startObjAnimation)
        {
            //obj.GetComponent<Animator>().StopPlayback();
        }


        if(shouldObjectRespawnOnReEnter)
        {
            obj.SetActive(GameManager.game.CheckGameState(thisState));
        } else 
        {
            obj.SetActive(false);
        }

        
        
        //Debug.Log(GameManager.game.CheckGameState(GameStates.SKY_BRIDGE_ON));
    }
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
            
            obj.SetActive(true);
            //play effect
            if(startObjAnimation)
            {
                obj.GetComponent<Animator>().enabled = true;
            }
        }
    
    }
}
