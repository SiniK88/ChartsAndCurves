using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour
{

    [SerializeField]
    Transform pointPrefab = default;

    [SerializeField, Range(10, 100)]
    int resolution = 10;

    [SerializeField, Range(0, 1)]
    int function = 0;


    Transform[] points; 

    private void Awake() {
        float step = 2f / resolution;
        var position = Vector3.zero; 
        var scale = Vector3.one * step ;
        points = new Transform[resolution];
        for( int i = 0; i < points.Length; i++) {

            Transform point = Instantiate(pointPrefab);
            position.x = (i + 0.5f) * step - 1f;
            //position.y = position.x * position.x * position.x;
            point.localPosition = position;
            point.localScale = scale;

            points[i] = point; 
            point.SetParent(transform, false);
        }
 
    }



    void Update()
    {
        FunctionLibrary.Function f = FunctionLibrary.GetFunction(function); 
        float time = Time.time * 0.5f;
        for (int i = 0; i < points.Length; i++) {
            Transform point = points[i];
            Vector3 position = point.localPosition;
            if (function == 0) {
                position.y = FunctionLibrary.Wave(position.x, time);
                //position.y = FunctionLibrary.Wave(position.x, time);
                //position.y = Mathf.Cos(Mathf.PI * (position.x + time));
                //position.y = (position.x * position.x * position.x) ;
            } else {
                position.y = FunctionLibrary.Ripple(position.x, time);
            }
            point.localPosition = position;
        }
    }
}
