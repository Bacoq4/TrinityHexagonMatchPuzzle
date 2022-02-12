using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrinityRotator : MonoBehaviour
{
    public Transform[] gobjects = new Transform[3];

    public float rotateSpeed = 100;

    public Transform hexHolder;

    bool isRotating;
    Quaternion qTo;
    public GameObject rotatedObject;

    public float rotatedAmount;
    public float timer = 0;
    public float rotateTime = 1;


    // Update is called once per frame
    void Update()
    {
        if (!gobjects[0] || !gobjects[1] || !gobjects[2]) { timer = 0; return; }    
        
        if (Input.GetKeyDown(KeyCode.RightArrow) && timer == 0)
        {
            RotateObj(rotatedAmount);
            HexagonManager.resetTimer();
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) && timer == 0)
        {
            RotateObj(-rotatedAmount);
            HexagonManager.resetTimer();
        }

        if (isRotating)
        {
            timer += Time.deltaTime;
            rotatedObject.transform.rotation = Quaternion.Lerp(rotatedObject.transform.rotation, qTo, Time.deltaTime * rotateSpeed);
            if (timer > rotateTime)
            {
                isRotating = false;
                timer = 0;
                foreach (Transform tr in gobjects)
                {
                    tr.parent = hexHolder;
                }
                if (rotatedObject.transform.childCount == 0)
                {
                    Destroy(rotatedObject);
                }
            }
            
        }
        
    }

    private void RotateObj(float rotatedAmount)
    {
        isRotating = true;

        Vector3 middlePoint = getMiddlePointOfTransforms(gobjects);

        rotatedObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        rotatedObject.transform.position = middlePoint;
        rotatedObject.GetComponent<MeshRenderer>().enabled = false;

        foreach (Transform tr in gobjects)
        {
            tr.SetParent(rotatedObject.transform);
        }

        qTo = Quaternion.AngleAxis(rotatedAmount, transform.up) * transform.rotation;
    }

    Vector3 getMiddlePointOfTransforms(Transform[] TArr)
    {
        Vector3 center = new Vector3(0,0,0);
        float counter = 0;

        foreach (Transform t in TArr)
        {
            center += t.position;
            counter++;
        }

        return center/counter;
    }
}
