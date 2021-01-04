using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger2D : MonoBehaviour
{

    public Dialogue2D dialogue2D; 

    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager2D>().StartDialogue(dialogue2D); 

       
    }
}
