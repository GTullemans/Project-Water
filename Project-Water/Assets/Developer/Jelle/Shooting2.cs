using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Shooting2 : MonoBehaviour
{
    public GameObject boot;
    public GameObject object1;
    public GameObject object2;
    [SerializeField]
    private GameObject Harpoon;
    [SerializeField]
    private GameObject pivot;

    public float speed = 5f;
    public float distance;
    public float range;

    private bool hasFired;
    private bool hasConnected = false;

    Vector3 startScale;
    Vector3 temp;
    Vector3 pos;

    void Start()
    {
        startScale = transform.localScale;
        //SetPos(object1.transform.position, object2.transform.position);
    }

    void Update()
    {
        Vector3 object1pos = object1.transform.position;
        Vector3 object2pos = object2.transform.position;
        pos = transform.position;
        distance = Vector3.Distance(object1pos, object2pos);
        if (temp.x >= range)
        {
            ResetRope();
            hasConnected = false;
        }
        temp = transform.localScale;
        if (XCI.GetButtonDown(XboxButton.LeftBumper))
        {
            hasConnected = false;
            ResetRope();
        }
        if (XCI.GetButtonDown(XboxButton.RightBumper))
        {
            hasFired = !hasFired;
        }
        if (hasFired)
        {
            ShootRope();
        }
        else
        {
            ResetRope();
        }
        if (hasConnected)
        {
            Harpoon.transform.LookAt(object2.transform);
            transform.parent = null;
            transform.position = 0.5f * (object1.transform.position + object2.transform.position);
            //transform.LookAt(object2.transform.position);
            temp.x = distance;
            transform.localScale = temp;
            SetPos(object1.transform.position, object2.transform.position);
            //print("hallo mevrouw");
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (hasConnected == false)
        {
            if (other.gameObject.name == "Boot 2")
            {
                //print("hallo daar meneer");
                hasConnected = !hasConnected;
                hasFired = !hasFired;
            }
        }

    }
    void SetPos(Vector3 start, Vector3 end)
    {
        var dir = end - start;
        var mid = (dir) / 2.0f + start;
        //transform.position = mid;
        transform.rotation = Quaternion.FromToRotation(Vector3.right, dir);
        //Vector3 scale = transform.localScale;
        //scale.y = dir.magnitude * factor;
        //transform.localScale = scale;
    }
    private void ShootRope()
    {
        //Harpoon.transform.position = boot.transform.position;
        Harpoon.GetComponent<HarpoenControll>().enabled = false;
        //transform.parent = null;
        transform.position = pivot.transform.position;
        temp.x += speed * Time.deltaTime;
        pos -= transform.right * speed / 2 * Time.deltaTime;
        //pos.x += speed / 2 * Time.deltaTime;
        transform.position = pos;

        transform.localScale = temp;
    }

    private void ResetRope()
    {
        Harpoon.GetComponent<HarpoenControll>().enabled = true;
        transform.parent = pivot.transform;
        hasFired = false;
        transform.localScale = startScale;
        transform.position = pivot.transform.position;
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }
}
