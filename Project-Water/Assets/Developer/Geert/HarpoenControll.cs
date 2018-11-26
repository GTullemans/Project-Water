using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class HarpoenControll : MonoBehaviour {

    private Vector3 _LookDir;
    [SerializeField] private GameObject _Parent;
    XboxController _PlayerNum;
    // Use this for initialization
    void Start () {
        _PlayerNum = _Parent.GetComponent<PlayerController>().PlayerNum;
	}
	
	// Update is called once per frame
	void Update () {

        _LookDir.x = XCI.GetAxisRaw(XboxAxis.RightStickX, _PlayerNum);
        _LookDir.z = XCI.GetAxisRaw(XboxAxis.RightStickY, _PlayerNum);


        transform.LookAt(transform.position + -_LookDir);

    }
}
