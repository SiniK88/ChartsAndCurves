using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTriggerarea2D : MonoBehaviour
{
    public GameObject canvas;
    public DialogueTrigger2D trigger2D;
    private bool istriggered = false;
    private void Start() {
        trigger2D = gameObject.GetComponent<DialogueTrigger2D>();
    }

    private void OnTriggerEnter(Collider other) {
        if (istriggered == false) {
            if (other.tag == "Player") {
                canvas.SetActive(true);
                trigger2D.TriggerDialogue();
            }
            istriggered = true;
        }
    }

}
