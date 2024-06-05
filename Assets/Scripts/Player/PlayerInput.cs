using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UAG.enums;

namespace UAG.Player{
    
public class PlayerInput : MonoBehaviour
{

    public static PlayerInput instance;

    public KeyCode interactKey;

    void Awake()
    {
        instance = this;

        
        

        
    }

    void Update()
    {
        HandleItemInput();
    }


    public bool Interact_Down()
    {
        return Input.GetKeyDown(interactKey);
    }

    public void HandleItemSelection(int num)
    {
        GameStates myItem = GameManager.game.itemHotBar[num-1];
        //add null checks and state checks to make sure the state has been added before being able to be selected
        if(GameManager.game.CheckGameState(myItem))
        {
            GameManager.game.heldItem = myItem;
            GameManager.game.DisplayHeldItem();
        }   
        
    }

    private void HandleItemInput()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1)){
            HandleItemSelection(1);
        } else if( Input.GetKeyDown(KeyCode.Alpha2)){
            HandleItemSelection(2);
        } else if( Input.GetKeyDown(KeyCode.Alpha3)){
            HandleItemSelection(3);
        } else if( Input.GetKeyDown(KeyCode.Alpha4)){
            HandleItemSelection(4);
        } else if( Input.GetKeyDown(KeyCode.Alpha5)){
            HandleItemSelection(5);
        } else if(Input.GetKeyDown(KeyCode.Alpha6)){
            HandleItemSelection(6);
        } else if( Input.GetKeyDown(KeyCode.Alpha7)){
            HandleItemSelection(7);
        } else if( Input.GetKeyDown(KeyCode.Alpha8)){
            HandleItemSelection(8);
        } else if(Input.GetKeyDown(KeyCode.Alpha9)){
            HandleItemSelection(9);
        } else if( Input.GetKeyDown(KeyCode.Alpha0))
        {
            HandleItemSelection(10);
        }
    }

}

}