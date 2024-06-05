using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.enums;
public class DebugUtil : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.game.AddState(GameStates.ITEM_TEDDY);
            GameManager.game.AddState(GameStates.ITEM_LIFESAVER);
            GameManager.game.AddState(GameStates.ITEM_KEYCARD);
            GameManager.game.AddState(GameStates.ITEM_LEMOMN);
            GameManager.game.AddState(GameStates.ITEM_DRUGS);
        }
    }
}
