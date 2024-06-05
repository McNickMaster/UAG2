using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UAG.enums;

public class SpawnDialogue : Action
{

    public string boxText;
    public Transform spawnPoint;

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
        DialogueFactory.instance.SpawnBox(spawnPoint.position + new Vector3(0, 1, 0), boxText);
        
    }
}
