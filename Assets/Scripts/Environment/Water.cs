using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    public MeshRenderer mesh;

    public float scrollSpeedX, scrollSpeedY;

    private float x, y;


    void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Scroll();
    }

    void Scroll()
    {
        x += scrollSpeedX * Time.deltaTime;
        y += scrollSpeedY * Time.deltaTime;


        mesh.material.SetTextureOffset("_MainTex", new Vector2(x, y));

        if(x >= 1)
        {
            x = 0;
        }

        if(y >= 1)
        {
            y = 0;
        }
    }
}
