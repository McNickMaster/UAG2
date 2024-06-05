using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.Player;
using UAG.enums;

public class Interactable : MonoBehaviour
{
    public Action myInteraction;
    public Action secondaryAction;
    public Action thirdAction;
    public Action fourthAction;

    [HideInInspector]
    public bool ableToInteract = false;

    [Header("Config")]
    public bool needPlayerInput = true;
    public bool needItem = false;
    public GameStates item_key;
    public bool disableItem = true;

    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ableToInteract && needPlayerInput && PlayerInput.instance.Interact_Down())
        {
            if(needItem)
            {
                if(GameManager.game.CheckHoldingItem(item_key))
                {
                    Interact();
                } else
                {
                    //play error sound
                }
            } else {
                Interact();
            }
        } else 
        {
            if(ableToInteract && needItem && !needPlayerInput)
            {
                if(GameManager.game.CheckHoldingItem(item_key))
                {
                    Interact();
                }
            }
        }
    }

    void Interact()
    {
        myInteraction.Action_Start();

        if(secondaryAction != null)
        {
            secondaryAction.Action_Start();
        }

        if(thirdAction != null)
        {
            thirdAction.Action_Start();
        }
        if(fourthAction != null)
        {
            fourthAction.Action_Start();
        }

        if(needItem && disableItem)
        {
            GameManager.game.RemoveGameState(item_key);
            GameManager.game.DisplayHeldItem();
        }

        if(sound != null)
        { 
            GameManager.game.gameFX.clip = sound;
            GameManager.game.gameFX.Play();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer.Equals(6))
        {
            if(!needPlayerInput)
            {
                Interact();
            }
            ableToInteract = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer.Equals(6))
        {
            ableToInteract = false;
        }
    }
}
