using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManger : MonoBehaviour {
    [SerializeField] private List<GameObject> Players;
	// Use this for initialization
	void Start () {
        int active = 1;

		for(int i = 0;i < Players.Count; i++)
        {
            if (Players[i].activeInHierarchy)
            {
                Players[i].GetComponent<PlayerController>().PlayerNum = (XboxCtrlrInput.XboxController)active;
                active++;
            }
        }
	}
	
	
}
