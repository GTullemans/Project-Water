using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTailSway : MonoBehaviour {

	// Use this for initialization
	void Start () {


    }

    // Update is called once per frame
    void Update() {
        // What is "T"
        float T = Mathf.Sin(2 * (Time.time + transform.position.y));
        // Rotate Tail "T"
        transform.Rotate(0, T, 0);
    }
}
