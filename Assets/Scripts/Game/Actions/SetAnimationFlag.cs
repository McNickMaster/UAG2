using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationFlag : Action
{
    
    public Animation animation;
    public Animator animator;
    public string flag;

    bool isAnimator = true;


    void Awake()
    {
        if(animator == null)
        {
            isAnimator = false;
        }

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
        if(isAnimator)
        { 
            animator.SetTrigger(flag);
        } else 
        {
            animation.Play();
        }

    }
}
