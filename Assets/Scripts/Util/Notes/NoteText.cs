using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class NoteText : MonoBehaviour
{
    public TextMeshProUGUI noteBody;
    public string note_id = "test";

    Note note;

    void Awake()
    {
        LoadJson();
        noteBody.text = note.body;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("Assets\\Scripts\\Util\\Notes\\" + note_id + ".json"))
        {
            string json = r.ReadToEnd();
            note = JsonUtility.FromJson<Note>(json);
        }
    }
}

[Serializable]
public class Note
{
    public string note_id;
    public string body;
}
