using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class SceneTrans : MonoBehaviour
{
    public static SceneTrans instance;

    public Image blackPlate;
    public float kp = 0.05f;
    
    private float a = 0, target_a = 0, old_a = 0, p = 0, fast_p = 0;

    void Awake()
    {
        instance = this;

        p = kp;
        fast_p = kp * 1.75f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Fade();

        
    }

    private void Fade()
    {
        if(blackPlate != null)
        {
            blackPlate.color = new Color(0,0,0,a);
            a = Mathf.Lerp(a, target_a, kp);

        }
    }

    public void FadeToBlack()
    {
        target_a = 1;
        old_a = 0;
        kp = fast_p;
    }

    public void FadeFromBlack()
    {
        target_a = 0;
        old_a = 1;
        kp = p;
    }
}
