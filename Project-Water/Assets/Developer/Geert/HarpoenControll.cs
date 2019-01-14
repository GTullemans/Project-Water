using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class HarpoenControll : MonoBehaviour {

    private Vector3 _LookDir;
    [SerializeField] private GameObject _Parent;
    XboxController _PlayerNum;
    [SerializeField] private float _RotateSpeed = 0.2f;
    // Use this for initialization
    void Start () {
        _PlayerNum = _Parent.GetComponent<PlayerController>().PlayerNum;
	}
	
	// Update is called once per frame
	void Update () {

        _LookDir.x = XCI.GetAxisRaw(XboxAxis.RightStickX, _PlayerNum);
        _LookDir.z = XCI.GetAxisRaw(XboxAxis.RightStickY, _PlayerNum);


        //transform.LookAt(transform.position + -_LookDir);
        if (_LookDir != Vector3.zero)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-_LookDir), _RotateSpeed);
        }

    }
}
