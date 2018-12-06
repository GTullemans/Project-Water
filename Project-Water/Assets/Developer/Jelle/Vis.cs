using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vis : MonoBehaviour
{
    private float timer;

    private float startTime;

    private float journeyLength;

    private float percentage;

    private Vector3 pos;
    [SerializeField]
    private Transform endPos;

    [SerializeField]
    private float totalLerpTime;
    public float currentLerpTime;
    void Start()
    {

    }

    void Update()
    {
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
                endPos.position = new Vector3(Random.Range(-15f, 15f), 0.5f, Random.Range(-15f, 15f));
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
        transform.position = Vector3.Lerp(transform.position, endPos.position, percentage);
    }
}
