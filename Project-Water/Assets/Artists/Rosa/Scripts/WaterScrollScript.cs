using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScrollScript : MonoBehaviour {

    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;
    public Material Normal;
    public Material Foam;
    public float NormalX = 0.5f;
    public float NormalY = 0.5f;
    public float FoamX = 0.5f;
    public float FoamY = 0.5f;


    void Update () {
        float OffsetX = Time.time * ScrollX;
        float OffsetY = Time.time * ScrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);

        float NormalOffsetX = Time.time * NormalX;
        float NormalOffsetY = Time.time * NormalY;
        Normal.mainTextureOffset = new Vector2(NormalOffsetX, NormalOffsetY);

        float FoamOffsetX = Time.time * FoamX;
        float FoamOffsetY = Time.time * FoamY;
        Foam.mainTextureOffset = new Vector2(FoamOffsetX, FoamOffsetY);

    }
}
