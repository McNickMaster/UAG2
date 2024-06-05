using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.Player;
using UAG.enums;

public class TP_Player : Action
{
    public Transform tp_point;

    public Vector3 mask = Vector3.one;

    public Action loadMeadowAction;

    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }  

    public void CheckHeldItem()
    {
        if (GameManager.game.heldItem == GameStates.ITEM_LEMONADE)
        {
            loadMeadowAction.Action_Start();
        }
    }

    public override void Action_Start()
    {
        CheckHeldItem();
        Vector3 tpPos = tp_point.position;
        Vector3 playerPos = PlayerMovement.instance.transform.position;

        tpPos = new Vector3(mask.x == 1 ? tpPos.x : playerPos.x, 
                            mask.y == 1 ? tpPos.y : playerPos.y, 
                            mask.z == 1 ? tpPos.z : playerPos.z);

        

        PlayerMovement.instance.transform.position = tpPos;
        //PlayerMovement.instance.playerCam.rotation = tp_point.rotation;
    }

}
