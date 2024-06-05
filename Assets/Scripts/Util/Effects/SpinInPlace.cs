using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinInPlace : MonoBehaviour
{

    public Vector3 spinAxis = Vector3.zero;
    public float spinSpeed = 10f;

    private float angle = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        angle += spinSpeed + Time.fixedDeltaTime;
        transform.localRotation = Quaternion.AngleAxis(angle, spinAxis);
        if(angle > 360)
        {
            angle %= 360;
        }
    }
}
