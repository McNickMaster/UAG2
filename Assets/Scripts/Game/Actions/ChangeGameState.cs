using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.enums;

public class ChangeGameState : Action
{
    public GameStates state;

    public bool addState = true;

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
        if(addState)
        {
            
            GameManager.game.AddState(state);
        }
        else {
            GameManager.game.RemoveGameState(state);

        }
    }
}
