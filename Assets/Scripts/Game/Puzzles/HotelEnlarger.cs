using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.Player;
public class HotelEnlarger : MonoBehaviour
{

    public Transform parentTransform;

    private float z = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        z = PlayerMovement.instance.transform.position.z;
        parentTransform.localScale = Vector3.one * ((z/350) + 1);
    }
}
