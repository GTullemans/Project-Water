using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _Speed;

    private Vector3 _InputDir;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        _InputDir.x = XCI.GetAxisRaw(XboxAxis.LeftStickX);
        _InputDir.z = XCI.GetAxisRaw(XboxAxis.LeftStickY);


        _InputDir=_InputDir.normalized;
        _InputDir *= Time.deltaTime;
        _InputDir *= _Speed;



        transform.LookAt(transform.position + _InputDir);
        transform.Translate(-_InputDir.z, 0, _InputDir.x,Space.World);
        
    }
}
