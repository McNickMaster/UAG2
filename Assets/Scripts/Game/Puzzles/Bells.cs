using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.enums;
public class Bells : MonoBehaviour
{
    public static Bells instance;
    public List<int> order = new List<int>();
    public List<int> key = new List<int>();

    public PlaySound bell1, bell2, bell3;

    //public GameObject portal;
    public Action myAction;
    public Action myAction2;
    public Action myAction3;

    private bool puzzle_solved = false;

    void Awake()
    {
        instance = this;
    }
    // Update is called once per frame
    void Update()
    {
        if(puzzle_solved)
        {


        } else {
            
            if(bell1.playing)
            {
                order.Add(1);
                bell1.playing = false;
            }
            if(bell2.playing)
            {
                order.Add(2);
                bell2.playing = false;
            }
            if(bell3.playing)
            {
                order.Add(3);
                bell3.playing = false;
            }   

        
            if(order.Count == 3)
            {
                if(CheckOrder())
                {
                    Finish();
                } else
                {
                    Invoke("ClearOrder", 0.5f);
                }
            }
        }
    }

    bool CheckOrder()
    {
        return (order[0] == key[0] &&
                order[2] == key[2] &&
                order[1] == key[1]);
    }


    void ClearOrder()
    {
        order = new List<int>();
    }

    void Finish()
    {
        puzzle_solved = true;
        //GameManager.game.AddState(GameStates.BELLS);
        myAction.Action_Start();
        myAction2.Action_Start();
        myAction3.Action_Start();
        //portal.SetActive(true);
    }

    

}
