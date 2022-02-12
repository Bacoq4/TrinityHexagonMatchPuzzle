using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Transform[] chosenObjects = new Transform[3];

    private Vector3 hitPos;
    public TrinityRotator trinityRotator;

    public float sphereCastRadius;


    private void OnDrawGizmosSelected() {
        Gizmos.DrawSphere(hitPos,sphereCastRadius);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        RaycastHit hit;

        if (Physics.Raycast(ray,out hit,1000))
        {
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            
            if (Input.GetMouseButtonDown(0) && trinityRotator.timer == 0)
            {
                Hexagon hex = hit.transform.GetComponent<Hexagon>();
                Vector3[] points = new Vector3[hex.transform.childCount];     
                for (int i = 0; i < hex.transform.childCount; i++)
                {
                    points[i] = hex.transform.GetChild(i).position;
                }
                Vector3 closestPoint = getClosestPoint(points,hit.point);
                hitPos = closestPoint;

                RaycastHit[] hits = Physics.SphereCastAll(closestPoint ,sphereCastRadius,Vector3.up,LayerMask.GetMask("Hex"));
                
                if(hits.Length != 3) {
                    for (int i = 0; i < hits.Length; i++)
                    {
                        print(hits[i].transform.name);
                    }
                    chosenObjects = new Transform[3];
                    trinityRotator.gobjects = new Transform[3];
                    return; 
                }
                chosenObjects = new Transform[3];

                for (int i = 0; i < hits.Length; i++)
                {
                    chosenObjects[i] = hits[i].transform;
                }

                trinityRotator.gobjects = chosenObjects;                
            }
        }
    }


    public Vector3 getClosestPoint(Vector3[] points, Vector3 hitPoint)
    {
        float smallestDist = Mathf.Infinity;
        Vector3 closestPoint = new Vector3(Mathf.Infinity,Mathf.Infinity,Mathf.Infinity);
        foreach (Vector3 point in points)
        {
            float dist =  Mathf.Abs(Vector3.Distance(point, hitPoint));
            if (dist < smallestDist)
            {
                smallestDist = dist;
                closestPoint = point;
            }
        }
        return closestPoint;
    }

}
