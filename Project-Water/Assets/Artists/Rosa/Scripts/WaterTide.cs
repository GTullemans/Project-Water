using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTide : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    float speed = 0.5f;
    float height = 0.1f;

    void Update()
    {
        Vector3 pos = transform.position;
        float newY = Mathf.Sin(Time.time * speed);
        transform.position = new Vector3(pos.x, newY, pos.z) * height;
    }

}
