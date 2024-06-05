using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.enums;

public class PlaySound : Action
{
    public AudioClip sound;
    public AudioSource player;

    public bool playing;

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
        playing = true;
        player.clip = sound;
        player.PlayDelayed(0.2f);

        Invoke("ResetPlaying", 0.1f);
    }

    void ResetPlaying()
    {
        playing = false;
    }
}
