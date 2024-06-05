using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.Player;
public class WatchPlayer : MonoBehaviour
{

    private Transform player;

    // Start is called before the first frame update
    void Awake()
    {
        player = PlayerMovement.instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        Watch();
    }

    void Watch()
    {
        transform.LookAt(player.position);
    }

    


}
