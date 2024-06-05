using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

using UAG.enums;
using UAG.Player;

public class GameManager : MonoBehaviour
{
    public static GameManager game;

    public LevelNames currentLevel = LevelNames.INTRO;
    public Scene currentScene;
    LevelNames fromLevel = LevelNames.INTRO;
    public GameStates heldItem;
    

    public List<GameStates> gameState = new List<GameStates>();

    [Header("Modules")]
    public AudioSource musicPlayer;
    public AudioSource gameFX;
    public AudioSource environmentFX;
    public GameObject noteParent;
    public GameObject itemParent;
    private GameObject currentItem = null;

    public GameObject[] itemHotBarUI;
    public GameStates[] itemHotBar;
    public GameObject[] itemModels;

    public Texture2D crosshair;
    
    void Awake()
    {
        
        //UpdateItemUI();
        Cursor.SetCursor(crosshair, Vector2.one / 2, CursorMode.ForceSoftware);
        
        game = this;
        
        StartLoadingFirstScene();
        
        //Invoke("Game_Mode", 0.1f);
        
        
    }

    private void OnEnable()
    {
        Game_Mode();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    
        




        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //Application.Quit();
        }

    }

    void FixedUpdate()
    {
        //DisplayHeldItem();
        UpdateItemUI();
    }

    public void UI_Mode()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PlayerMovement.instance.gameObject.SetActive(false);
        PlayerCam.instance.enabled = false;
    }

    public void Game_Mode()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
        PlayerMovement.instance.gameObject.SetActive(true);
        PlayerCam.instance.enabled = true;
    }


    public void AddState(GameStates state)
    {
        if(CheckGameState(state))
        {

        } else 
        {
            gameState.Add(state);
        }
        
    }

    void UpdateItemUI()
    {
        if(itemHotBarUI.Length > 0 && itemHotBarUI[3] != null)
        {
            for(int i = 0; i < itemHotBarUI.Length; i++)
            {

                itemHotBarUI[i].SetActive(CheckGameState(itemHotBar[i]));
            }

        }
        
    }

    public bool CheckGameState(GameStates state)
    {
//        Debug.Log("Checking if game state has " + state.ToString() + ". " + gameState.Contains(state));
        return gameState.Contains(state);
    }

    public void RemoveGameState(GameStates state)
    {
        gameState.Remove(state);
        heldItem = GameStates.ITEM_NONE;
        DisplayHeldItem();
    }

    public bool CheckHoldingItem(GameStates state)
    {
        return heldItem == state;
    }

    public void DisplayHeldItem()
    {
        if(currentItem != null) 
        {
            Destroy(currentItem);
        }
        switch(heldItem)
        {
            /*
            case GameStates.ITEM_LIFESAVER:
            {
                currentItem = 
                    Instantiate(itemModels[0], Vector3.zero, Quaternion.identity, itemParent.transform);
                    currentItem.transform.localRotation = Quaternion.identity;
                break;
            }
            case GameStates.ITEM_TEDDY:
            {
                currentItem = 
                    Instantiate(itemModels[1], Vector3.zero, Quaternion.identity, itemParent.transform);
                    currentItem.transform.localRotation = Quaternion.identity;
                 break;
            }
            case GameStates.ITEM_KEYCARD:
            {
                currentItem = 
                    Instantiate(itemModels[2], Vector3.zero, Quaternion.identity, itemParent.transform);
                currentItem.transform.localRotation = Quaternion.identity;
                break;
            }
            case GameStates.ITEM_LEMOMN:
            {
                currentItem = 
                    Instantiate(itemModels[3], Vector3.zero, Quaternion.identity, itemParent.transform);
                    currentItem.transform.localRotation = Quaternion.identity;
                break;
            }
            case GameStates.ITEM_DRUGS:
            {
                currentItem = 
                    Instantiate(itemModels[4], Vector3.zero, Quaternion.identity, itemParent.transform);
                    currentItem.transform.localRotation = Quaternion.identity;
                break;
            }
            case GameStates.ITEM_LEMONADE:
            {
                currentItem = 
                    Instantiate(itemModels[5], Vector3.zero, Quaternion.identity, itemParent.transform);
                    currentItem.transform.localRotation = Quaternion.identity;
                break;
            }
            */
            case GameStates.ITEM_NONE:
            {
                currentItem = null;
                break;
            }
        }

        if(currentItem != null) 
        {
            currentItem.transform.localPosition = Vector3.zero;
        }
    }


    #region SceneLoading


    public IEnumerator SceneSwitch(string newScene, bool movePlayer)
    {
         if(movePlayer)
            {
                SceneTrans.instance.FadeToBlack();
            }
        
                
            fromLevel = LevelManager.currentLevel.thisLevel;
            PlayerMovement.instance.enabled = false;
            AsyncOperation load = SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);
            yield return load;
            SceneManager.UnloadSceneAsync(currentScene);
            currentScene = SceneManager.GetSceneByName(newScene);
            SceneManager.SetActiveScene(currentScene);
            if(movePlayer)
            {
                MovePlayerToSpawn();
                SceneTrans.instance.FadeFromBlack();
            }
            PlayerMovement.instance.enabled = true;

        if(newScene=="EndGame")
        {
            UI_Mode();
            Destroy(PlayerInput.instance.gameObject);
        }
        
    }
    IEnumerator LoadFirstScene(string newScene)
    {
        
        AsyncOperation load = SceneManager.LoadSceneAsync(newScene, LoadSceneMode.Additive);
        yield return load;
        currentScene = SceneManager.GetSceneByName(newScene);
        SceneManager.SetActiveScene(currentScene);
        MovePlayerToSpawn();
    }

    public void StartLoadingFirstScene()
    {
        StartCoroutine(LoadFirstScene(currentLevel.ToString()));
    }

    

    public void MovePlayerToSpawn()
    {

        Transform playerSpawn = LevelManager.currentLevel.GetSpawn(fromLevel);

        PlayerMovement.instance.ResetAt(playerSpawn);
    }



    #endregion SceneLoading
}
