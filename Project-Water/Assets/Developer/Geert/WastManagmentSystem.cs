using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WastManagmentSystem : MonoBehaviour {
    [SerializeField] private GameObject[] _TrashPrefap;
    [SerializeField] private int _AmountOfTrash;
    float mean = 0;
    float stdDev = 5;


    // Use this for initialization
    void Start () {

        

        for (int i = 0; i < _AmountOfTrash; i++)
        {
            Vector3 pos = transform.position;
            float x1 = Random.Range(0.0f, 1.0f);
            float x2 = Random.Range(0.0f, 1.0f);
            float randStdNormalx = Mathf.Sqrt(-2.0f * Mathf.Log(x1)) * Mathf.Sin(2.0f * Mathf.PI * x2);
            pos.x += mean + stdDev * randStdNormalx;
            float y1 = Random.Range(0.0f, 1.0f);
            float y2 = Random.Range(0.0f, 1.0f);
            float randStdNormaly = Mathf.Sqrt(-2.0f * Mathf.Log(y1)) * Mathf.Sin(2.0f * Mathf.PI * y2);
            pos.z += mean + stdDev * randStdNormaly;
            
            Instantiate(_TrashPrefap[Random.Range(0, _TrashPrefap.Length - 1)],pos,Quaternion.identity);
        }
     }
	
	// Update is called once per frame
	void Update () {
		
	}
}
