using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UAG.enums;

public class LoadScene : Action
{
    public LevelNames levelName = LevelNames.Forest;

    public bool movePlayer = true;

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
        //Debug.Log(levelName.ToString());
        
        StartCoroutine(GameManager.game.SceneSwitch(levelName.ToString(), movePlayer));
    }
}
