using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class HarpoenControll : MonoBehaviour {

    private Vector3 _LookDir;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        _LookDir.x = XCI.GetAxisRaw(XboxAxis.RightStickX);
        _LookDir.z = XCI.GetAxisRaw(XboxAxis.RightStickY);


        transform.LookAt(transform.position + -_LookDir);

    }
}
