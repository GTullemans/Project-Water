using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineScript : MonoBehaviour
{
    [SerializeField]
    private GameObject firstPoint;
    [SerializeField]
    private GameObject secondPoint;
    private Vector3[] firstPos;
    private Vector3 secondPos;
    [SerializeField]
    private LineRenderer Lr;
    void Start()
    {
        Lr = GetComponent<LineRenderer>();
        Lr.positionCount = 2;
    }

    void Update()
    {
        Lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, transform.position.z));
        Lr.SetPosition(1, new Vector3(secondPoint.transform.position.x, secondPoint.transform.position.y, secondPoint.transform.position.z));
    }
}
