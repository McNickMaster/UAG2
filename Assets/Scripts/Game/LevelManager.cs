using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.Player;
using UAG.enums;

public class LevelManager : MonoBehaviour
{
    public static LevelManager currentLevel;
    public LevelNames thisLevel;

    [HideInInspector]
    public Transform playerSpawn;
    public Transform[] spawns;



    void Awake()
    {
        currentLevel = this;

        

    }

    private void OnEnable()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetSpawn(LevelNames fromLevel)
    {
        playerSpawn = spawns[((int)fromLevel)];
        Debug.Log("Player came from " + fromLevel);
        return playerSpawn;
    }
}
