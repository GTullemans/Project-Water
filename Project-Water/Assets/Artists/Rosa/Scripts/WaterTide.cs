using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTide : MonoBehaviour {
    private Vector3 pos;
    float speed = 0.5f;
    float height = 0.1f;


    // Use this for initialization
    void Start () {
         pos = transform.position;
    }

   

    void Update()
    {
        
        float newY = Mathf.Sin(Time.time * speed);
        
        transform.position = new Vector3(pos.x, pos.y + (newY * height) , pos.z);
    }

}
