using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class DialogueManager2D : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText; 
     Queue<string> sentences;

    public GameObject canvas;
    void Start()
    {
        sentences = new Queue<string>(); 
    }

    public void StartDialogue ( Dialogue2D dialogue2D) {
        nameText.text = dialogue2D.name; 
        sentences.Clear(); 

        foreach( string sentence in dialogue2D.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence() {
        if(sentences.Count == 0) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        //dialogueText.text = sentence; // all text at one
        StopAllCoroutines(); // stops animation spevious sentence and we start new coroutine
        StartCoroutine(TypeSentence(sentence)); 
    }

    IEnumerator TypeSentence ( string sentence) {
        dialogueText.text = "";
        foreach( char letter in sentence.ToCharArray()) {
            dialogueText.text += letter;
            yield return null; // we wait one frame after one letter
        }
    }

    void EndDialogue() {
        Debug.Log("end dialogue");
        canvas.SetActive(false);
    }
}
