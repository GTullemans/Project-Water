using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _Speed;
    [SerializeField] private float _RotateSpeed;
    [SerializeField] private float _Acceleratie,_Decceleratie;
    private Vector3 _InputDir;
    private Vector3 _Dir;
    [SerializeField] private XboxController Player;
    private float _CurrentSpeed =0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Player = PlayerNum;
        _InputDir.x = XCI.GetAxisRaw(XboxAxis.LeftStickX,PlayerNum);
        _InputDir.z = XCI.GetAxisRaw(XboxAxis.LeftStickY, PlayerNum);

        
        _InputDir=_InputDir.normalized;
        



        //transform.LookAt(transform.position + -_InputDir);
        //if(_InputDir == Vector3.zero && _Dir != Vector3.zero)
        //{
        //    Debug.Log("jeej");
        //}
        if(_InputDir != Vector3.zero)
        {
            _Dir = _InputDir;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(-_InputDir), _RotateSpeed);

            if (_CurrentSpeed < _Speed)
            {
                _CurrentSpeed += _Acceleratie;

            }
            else _CurrentSpeed = _Speed;
        }
        else
        {
            if (_CurrentSpeed > 0)
            {
                _CurrentSpeed -= _Decceleratie;
                
            }
            else _CurrentSpeed = 0;
           
        }
        
         
        
        transform.Translate(_Dir.z * _CurrentSpeed * Time.deltaTime, 0, -_Dir.x * _CurrentSpeed * Time.deltaTime, Space.World);
        //Debug.Log(_CurrentSpeed);
        
        
    }

    public XboxController PlayerNum { get; set; }
}
