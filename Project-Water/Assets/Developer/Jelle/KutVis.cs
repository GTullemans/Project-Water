using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KutVis : MonoBehaviour
{
    private float timer;

    private float startTime;

    private float journeyLength;

    private float percentage;

    private Vector3 pos;

    [SerializeField]
    private Transform startCube;
    [SerializeField]
    private Transform endPos;
    [SerializeField]
    private Transform diveObj;

    [SerializeField]
    private float totalLerpTime;
    public float currentLerpTime;
    void Start()
    {

    }

    void Update()
    {
        diveObj.position = new Vector3(transform.position.x, diveObj.transform.position.y, transform.position.z);
        currentLerpTime += Time.deltaTime;

        if (currentLerpTime > totalLerpTime)
        {
            currentLerpTime = totalLerpTime;
        }

        percentage = currentLerpTime / totalLerpTime;

        if (percentage >= 3.0f)
        {
            currentLerpTime = 0f;
        }
        MoveFish();
        if (transform.position == endPos.position)
        {
            int rand = Random.Range(0, 5);
            if (rand == 3)
            {
                endPos.position = new Vector3(endPos.transform.position.x, -3f, endPos.transform.position.z);
                currentLerpTime = 0f;
            }
            else
            {
                endPos.position = new Vector3(Random.Range(-10.6f, 10.6f), 0.5f, Random.Range(-10.6f, 10.6f));
                currentLerpTime = 0f;
            }
        }
    }
    private void Dive()
    {
        transform.position = Vector3.Lerp(transform.position, endPos.position, percentage);
    }
    private void MoveFish()
    {
        startCube.position = transform.position;

        transform.position = Vector3.Lerp(transform.position, endPos.position, percentage);
    }
}
