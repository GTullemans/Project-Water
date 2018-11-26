using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScrollScript : MonoBehaviour {

    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;
    public Material Normal;
    public float NormalX = 0.5f;
    public float NormalY = 0.5f;


    void Update () {
        float OffsetX = Time.time * ScrollX;
        float OffsetY = Time.time * ScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

        float NormalOffsetX = Time.time * NormalX;
        float NormalOffsetY = Time.time * NormalY;
        Normal.mainTextureOffset = new Vector2(NormalOffsetX, NormalOffsetY);

    }
}
