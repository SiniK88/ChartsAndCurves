using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject : MonoBehaviour
{

    public float min = 0;
    public float max = 4;

    public GameObject object1;
    public GameObject player;
    bool isTriggered = false;
    bool callAgain = false;
    float waitTime = 6f;

    void Update() {
        int i = 0;
        if (isTriggered == true) {
            waitTime -= Time.deltaTime;
        }
        if (isTriggered == true && waitTime <= 0f) {
            callAgain = true; 
        }
            //scale = new Vector3(max + min * Mathf.Sin(Time.time), 1, 1);
            //for (i = 0; i < 3; ++i) scale[i] = max + min * Mathf.Sin(Time.time) ;
            //transform.localScale = scale;
        }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine(ScaleOverTime(1));
            isTriggered = true;
        }
        if(callAgain == true) {
            StartCoroutine(ScaleOverTime2(1));
        }
    }

    IEnumerator ScaleOverTime(float time) {
        Vector3 originalScale = object1.transform.localScale;
        Vector3 destinationScale = new Vector3(max,1, 1);

        float currentTime = 0.0f;

        do {
            object1.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

    }

    IEnumerator ScaleOverTime2(float time) {
        Vector3 originalScale = object1.transform.localScale;
        Vector3 destinationScale = new Vector3(max+4, 1, 1);

        float currentTime = 0.0f;

        do {
            object1.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= time);

    }

}
