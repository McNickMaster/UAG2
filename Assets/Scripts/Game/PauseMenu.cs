using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;

    private bool ui_active = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(pauseUI != null)
        {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            ToggleActive();
        }

        if(ui_active)
        {
            ShowUI();
        } else 
        {
            HideUI();
        }

        }
    }

    public void ShowUI()
    {
        if(!pauseUI.activeSelf)
        {
            pauseUI.SetActive(true);
            GameManager.game.UI_Mode();
        }
    }

    public void HideUI()
    {
        ui_active = false;
        if(pauseUI.activeSelf)
        {
            pauseUI.SetActive(false);
            GameManager.game.Game_Mode();
        }
    }

    private void ToggleActive()
    {
        if(ui_active)
        {
            ui_active = false;
        } else 
        {
            ui_active = true;
        }
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
