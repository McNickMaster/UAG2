using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UAG.Player;
public class ShowNote : Action
{
    public Transform worldNoteParent;
    public Transform note;
    public Interactable interact;
    

    private bool lookingAtNote = false;

    private Vector3 targetPos = Vector3.zero, startingPos = Vector3.zero;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(lookingAtNote)
        {
            if(PlayerInput.instance.Interact_Down())
            {
                HideNote();
                lookingAtNote = false;
            }
        }
        interact.enabled = !lookingAtNote;
        

        note.localPosition = (Vector3.Lerp(note.localPosition, Vector3.zero, 0.5f));
    }

    public override void Action_Start()
    {
        note.transform.parent = GameManager.game.noteParent.transform;
        startingPos = note.transform.localPosition;
        note.transform.rotation = Quaternion.identity;
        note.transform.localRotation = Quaternion.identity;
        lookingAtNote = true;
        GameManager.game.UI_Mode();
    }

    public void HideNote()
    {
        note.transform.parent = worldNoteParent;
        startingPos = note.transform.localPosition;
        note.transform.rotation = Quaternion.identity;
        note.transform.localRotation = Quaternion.identity;
        GameManager.game.Game_Mode();
    }
}
