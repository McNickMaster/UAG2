using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine.SceneManagement;

public class EndingManager : MonoBehaviour
{
    public static EndingManager instance;

    public TextMeshProUGUI body;
    public TextMeshProUGUI title;
    public string id = "test";
    public Endings ourEnding;

    EndingText ourText;

    void Awake()
    {

        /*
        if(GameManager.game.CheckGameState(UAG.enums.GameStates.ADDICT_LEMON) || GameManager.game.CheckGameState(UAG.enums.GameStates.ITEM_LEMONADE))
        {
            ourEnding = Endings.LEMONADE;
        } else if(GameManager.game.CheckGameState(UAG.enums.GameStates.ADDICT_DRUGS))
        {
            ourEnding = Endings.SPOILED_LEMONS;
        } else if(GameManager.game.CheckGameState(UAG.enums.GameStates.TREE_DEAD))
        {
            ourEnding = Endings.ROOT;
        }else if(GameManager.game.CheckGameState(UAG.enums.GameStates.MEADOW))
        {
            ourEnding = Endings.SWEETEST;
        }else 
        {
            ourEnding = Endings.NO_LEMONS;
        }
        instance = this;

        switch(ourEnding)
        {
            case (Endings.LEMONADE):
            {
                id = "lemonade";
                break;
            }
            case (Endings.NO_LEMONS):
            {
                id = "no_lemons";
                break;
            }
            case (Endings.SPOILED_LEMONS):
            {
                id = "spoiled";
                break;
            }
            case (Endings.ROOT):
            {
                id = "root";
                break;
            }
            case (Endings.SWEETEST):
            {
                id = "sweet";
                break;
            }

        }
        */
        LoadJson();

        title.text = ourText.title;
        body.text = ourText.body;
    }


    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("Assets\\Scripts\\Game\\Endings\\EndingsText\\" + id + ".json"))
        {
            string json = r.ReadToEnd();
            ourText = JsonUtility.FromJson<EndingText>(json);
        }
    }

    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

[Serializable]
public class EndingText
{
    public string title;
    public string body;
}
