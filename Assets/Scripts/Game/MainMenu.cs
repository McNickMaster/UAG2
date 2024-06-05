using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public float spinSpeed = 3;
    public Material skybox;

    private float angle = 0;

    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        SpinSkybox();
    }

    void SpinSkybox()
    {
        skybox.SetFloat("_Rotation", angle);
        angle += Time.fixedDeltaTime * spinSpeed;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
