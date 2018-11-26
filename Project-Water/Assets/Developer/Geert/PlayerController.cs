using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class PlayerController : MonoBehaviour {
    [SerializeField] private float _Speed;
    
    private Vector3 _InputDir;
    [SerializeField] private XboxController Player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Player = PlayerNum;
        _InputDir.x = XCI.GetAxisRaw(XboxAxis.LeftStickX,PlayerNum);
        _InputDir.z = XCI.GetAxisRaw(XboxAxis.LeftStickY, PlayerNum);


        _InputDir=_InputDir.normalized;
        _InputDir *= Time.deltaTime;
        _InputDir *= _Speed;



        transform.LookAt(transform.position + _InputDir);
        transform.Translate(-_InputDir.z, 0, _InputDir.x,Space.World);
        
    }

    public XboxController PlayerNum { get; set; }
}
