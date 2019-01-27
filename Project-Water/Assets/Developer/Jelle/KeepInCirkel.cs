using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepInCirkel : MonoBehaviour {

    [SerializeField]
    private Vector3 circleCenter;
    [SerializeField]
    private float circleRadius;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        circleCenter.y = transform.position.y;
        Vector3 v = transform.position - circleCenter;
        v = Vector3.ClampMagnitude(v, circleRadius);
        transform.position = circleCenter + v;
    }
}
