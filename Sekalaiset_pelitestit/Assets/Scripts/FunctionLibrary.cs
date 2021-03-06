﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Mathf;

public static class FunctionLibrary {

    //public delegate float Function(float x, float z, float t);
    public delegate Vector3 Function(float u, float v, float t);

    public enum FunctionName { Wave, MultiWave, Ripple, Sphere, Test1, Scatter, Wave2D, Spriral, Test4, Test6, Vittu }

    static Function[] functions = { Wave, MultiWave, Ripple, Sphere, Test1, Scatter, Wave2D, Spriral, Test4, Test6, Vittu };
    public static Function GetFunction(FunctionName name) {
        return functions[(int)name];
    }

    //to make them work directly at the class level we have to mark it as static
    //public static float Wave(float x, float z, float t) {
    //    return Sin(PI * (x + z + t)); 
    //}

    public static Vector3 Wave(float u, float v, float t) {
        Vector3 p;
        p.x = u * 10;
        p.y = Sin(PI * (u + v + t)) * 5 ;
        p.z = v * 10;
        return p;
    }

    public static Vector3 Wave2D(float u, float v, float t) {
        Vector3 p;
        p.x = u * 10;
        p.y = Sin(PI * (u + t)) * 5;
        p.z = 1;
        return p;
    }
    public static Vector3 Spriral(float u, float v, float t) {
        Vector3 p;
        float a = 1.5f;
        float b = -2.5f;
        p.x = (a + b * t) * Cos(t);
        p.y = (a + b * t) * Sin(t) ;
        p.z = 1;
        return p;
    }


    public static Vector3 Vittu(float u, float v, float t) {
        Vector3 p;
        p.x = u * 10;
        p.y = Sin(PI * (p.x + 0.5f * t));
        p.y = 0.5f * Sin(2f * PI * (p.x + t)) * 5;
        p.z = 1;
        return p;
    }

    public static Vector3 Test6(float u, float v, float t) {
        Vector3 p;
        float r = 0.9f * Sin(PI * ( u * 0.5f  + t  ));
        float s = r * Cos(PI );
        p.x =  Sin( PI *u) * 10;
        p.y = r* Cos(PI * u) * 10;
        p.z = 1;
        return p;
    }


    public static Vector3 Test4(float u, float v, float t) {
        Vector3 p;
        p.x = Cos(u) * Cos(t);
        p.y = Sin(v) * Sin(t);
        p.z = 1;
        return p;
    }

    public static Vector3 Test1(float u, float v, float t) {
        Vector3 p;
        p.x = u * 10; // 20 is for scaling
        p.y = p.x  ;
        //p.z = v * 20 ; // and for z axis
        p.z = 1; // if we don't want to put much to z axis
        return p;
    }

    public static Vector3 Scatter(float u, float v, float t) {
        Vector3 p;
        float d = Abs(u) * 5;
        p.x = d * 10;
        p.y = Sin(4f * PI * d - t ) * 4;
        //p.z = v * 20 ; // and for z axis
        p.z = 1; // if we don't want to put much to z axis
        return p;
    }

    /*
    public static float MultiWave (float x, float z, float t) {
        float y = Sin(PI * (x + 2.5f * t));
        y += Sin(PI * (x + z + 0.25f * t));
        return y * (1f / 2.5f);
    }
    public static float Ripple (float x, float z, float t) {
        float d = Sqrt(x * x + z * z);
        float y = Sin(PI * (4f * d - t));
        return y / (1f + 10f * d);
    }
    */

    public static Vector3 MultiWave(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + t * 0.5f));
        p.y +=  Sin(2f * PI * (v + t));
        p.y += Sin(PI * (u + v + t * 0.25f));
        p.y *= 1f / 2.5f ;
        p.z = v;
        return p;
    }

    /*public static Vector3 MultiWave(float u, float v, float t) {
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (u + 0.5f * t));
        p.y += 0.5f * Sin(2f * PI * (v + t));
        p.y += Sin(PI * (u + v + 0.25f * t));
        p.y *= 1f / 2.5f;
        p.z = v;
        return p;
    }*/


    public static Vector3 Ripple(float u, float v, float t) {
        float d = Sqrt(u * u + v * v);
        Vector3 p;
        p.x = u;
        p.y = Sin(PI * (4f * d - t));
        p.y /= 1f + 10f * d;
        p.z = v;
        return p;
    }

    public static Vector3 Sphere(float u, float v, float t) {
        float r = 0.9f + 0.1f * Sin(8f * PI * v);
        float s = r * Cos(0.5f * PI * v);
        Vector3 p;
        p.x = s * Sin(PI * u);
        p.y = r * Sin(0.5f * PI * v);
        p.z = s * Cos(PI * u);
        return p;
    }

}



