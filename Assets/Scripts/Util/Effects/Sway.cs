using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    public float sway_speed, sway_distance, sway_interval;

    public Vector3 sway_direction = Vector3.up;


    private Vector3 startPosition;
    private float a, b;

    void Awake()
    {
        startPosition = transform.position;
        a = startPosition.y;
        b = startPosition.y + (sway_distance);

        InvokeRepeating("SwitchSway", sway_interval, sway_interval);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSway();
    }

    void UpdateSway()
    {  
        float x = Mathf.Lerp(a, b, sway_speed);
        transform.position = new Vector3(0, x, 0);
    }

    void SwitchSway()
    {
        float z = a;
        a = b;
        b = z;

    }
}
