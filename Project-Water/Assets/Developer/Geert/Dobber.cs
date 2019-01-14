using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dobber : MonoBehaviour {

   
       
      
        [SerializeField] private float _Amplitude = 0.5f;
        [SerializeField] private float _Frequency = 1f;

      
        private Vector3 posOffset = new Vector3();
        private Vector3 tempPos = new Vector3();
        private float randTime;

        // Use this for initialization
        void Start()
        {
            randTime = Random.Range(0f, 1f);
            posOffset = transform.position;
            
        }

        // Update is called once per frame
        void Update()
        {
            

            
            tempPos.y = posOffset.y;
            tempPos.y += Mathf.Sin(Time.fixedTime + randTime  * Mathf.PI * _Frequency) * _Amplitude;

            transform.position = new Vector3(transform.position.x,tempPos.y, transform.position.z);
        }
    
}
