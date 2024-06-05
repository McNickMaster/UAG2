using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class DialogueFactory : MonoBehaviour
{
    public static DialogueFactory instance;

    public GameObject dialogueBoxPrefab;


    void Awake()
    {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnBox(Vector3 position, string text)
    {
        GameObject box = Instantiate(dialogueBoxPrefab, position, Quaternion.identity, null);

        box.GetComponentInChildren<TextMeshProUGUI>().text = text;
    }


}
