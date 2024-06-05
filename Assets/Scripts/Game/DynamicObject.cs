using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.enums;
public class DynamicObject : MonoBehaviour
{

    public GameObject defaultObj, switchedObject;

    public GameStates switchState;

    // Start is called before the first frame update
    void Awake()
    {
        if(GameManager.game.CheckGameState(switchState))
        {
            Switched_On();
        } else {
            Default_On();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.game.CheckGameState(switchState))
        {
            Switched_On();
        } else {
            Default_On();
        }
    }

    void Default_On()
    {
        if(defaultObj != null)
        {
            defaultObj.SetActive(true);
        }
        if(switchedObject != null)
        {
            switchedObject.SetActive(false);
        }
    }

    void Switched_On()
    {
        if(defaultObj != null)
        {
            defaultObj.SetActive(false);
        }
        if(switchedObject != null)
        {
            switchedObject.SetActive(true);
        }
    }
}
