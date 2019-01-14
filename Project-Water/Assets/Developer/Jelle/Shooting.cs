using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Shooting : MonoBehaviour
{
    [SerializeField]
    private GameObject ropeStart;
    [SerializeField]
    private GameObject ropeEnd;
    [SerializeField]
    private Rigidbody ropeRigid;
    [SerializeField]
    private GameObject Harpoon;
    [SerializeField]
    private GameObject[] PlayerBoats;
    [SerializeField]
    private LineRenderer Lr;
    [SerializeField]
    private float forwardForce;

    private Transform ropeTransform;

    private float distance;

    private bool hasFired;
    void Start()
    {
        //Lr = PlayerBoats[0].GetComponent<LineRenderer>();
        ropeRigid = ropeEnd.GetComponent<Rigidbody>();
        ropeTransform = ropeRigid.transform;
    }

    void Update()
    {
        //foreach(GameObject playerBoat in PlayerBoats)
        //{
        //    if(Vector3.Distance(playerBoat.transform.position, Harpoon.transform.position) < 10f)
        //    {
        //        print("hallo meneer");  
        //    }
        //}
        //Harpoon.transform.LookAt(PlayerBoats[1].transform.position);
        //ropeEnd.transform.LookAt(PlayerBoats[1].transform.position);
        //ropeEnd.transform.LookAt(PlayerBoats[1].transform);
        Vector3 Boat1 = PlayerBoats[0].transform.position;
        Vector3 Boat2 = PlayerBoats[1].transform.position;
        //Harpoon.transform.LookAt(PlayerBoats[1].transform, Vector3.up);
        Distance(Boat1, Boat2);
        if (distance <= 10)
        {
            if (XCI.GetButtonDown(XboxButton.RightBumper) || XCI.GetButtonDown(XboxButton.LeftBumper))
            {
                Shoot();
                hasFired = !hasFired;
            }

        }
        else
        {
            Lr.enabled = false;
            hasFired = false;
        }
        if (hasFired == true)
        {
            ropeRigid.transform.parent = null;
            Lr.enabled = true;
            //Lr.SetPosition(0, new Vector3(ropeStart.transform.position.x, ropeStart.transform.position.y, ropeStart.transform.position.z));
            //Lr.SetPosition(1, new Vector3(ropeEnd.transform.position.x, ropeEnd.transform.position.y, ropeEnd.transform.position.z));
            Vector3 localPos = ropeRigid.transform.localScale;
            localPos.z += Time.deltaTime;
            //ropeTransform.position = Vector3.Lerp(ropeTransform.position, localPos, 0.5f);
            ropeRigid.transform.localScale = localPos;
        }
        else
        {
            ropeEnd.transform.parent = Harpoon.transform;
            ropeEnd.transform.position = ropeStart.transform.position;
            ropeEnd.transform.rotation = ropeStart.transform.rotation;
            Lr.enabled = false;
            ResetForce();
        }
        //print(Mathf.RoundToInt(distance));
    }
    private float Distance(Vector3 objectA, Vector3 objectB)
    {
        distance = Vector3.Distance(objectA, objectB);
        return distance;
    }
    private void Shoot()
    {
        ropeRigid.AddForce(ropeEnd.transform.forward * forwardForce * Time.deltaTime);
        ropeEnd.transform.rotation = Quaternion.identity;
    }
    private void ResetForce()
    {
        ropeRigid.velocity = Vector3.zero;
        ropeRigid.angularVelocity = Vector3.zero;
    }
}
