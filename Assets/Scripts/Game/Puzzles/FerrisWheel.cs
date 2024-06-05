using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.enums;

public class FerrisWheel : MonoBehaviour
{
    public SpinInPlace mySpin;

    private bool lerping = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.game.CheckGameState(GameStates.FERRIS_STOPPED))
        {
            lerping = true;
            mySpin.spinSpeed = 0;

            
        } else 
        {

        }

        if(lerping)
        {
            transform.rotation = Quaternion.AngleAxis(Mathf.Lerp(transform.rotation.z, 0, 0.001f), Vector3.forward);
        }

        if(lerping && Mathf.Abs(transform.rotation.z) <= 2)
        {
            transform.rotation = Quaternion.AngleAxis(0, Vector3.forward);
            lerping = false;
        }
    }
}
