using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    Vector3 vecR = new Vector3(0.55f, 0, 0);
    Vector3 vecL = new Vector3(0, 0, 0.85f);
    Vector3[] directions = new Vector3[6];
    public Hexagon[] connectedHexes = new Hexagon[6];

    [SerializeField] private float rayDistance = 2f;

    public Color color;

    public bool canBeDestroyed;
    public bool openDebug;
    public bool isOnBottom;

    public float fallDistance = 2f;

    private void Start() {
        directions[0] = (-vecR + vecL);
        directions[1] = (vecR + vecL);
        directions[2] = transform.right;
        directions[3] = -(-vecR + vecL);
        directions[4] = -(vecR + vecL);
        directions[5] = -transform.right;
    }

    public void SetCanBeDestroyed()
    {
        if ((connectedHexes[0] && connectedHexes[0].color == color && connectedHexes[1] && connectedHexes[1].color == color) || (connectedHexes[0] && connectedHexes[0].color == color && connectedHexes[5] && connectedHexes[5].color == color))
        {          
            canBeDestroyed = true;          
        }
        else if ((connectedHexes[1] && connectedHexes[1].color == color && connectedHexes[0] && connectedHexes[0].color == color) || (connectedHexes[1] && connectedHexes[1].color == color && connectedHexes[2] && connectedHexes[2].color == color))
        {          
            canBeDestroyed = true;        
        }
        else if ((connectedHexes[2] && connectedHexes[2].color == color && connectedHexes[1] && connectedHexes[1].color == color) || (connectedHexes[2] && connectedHexes[2].color == color && connectedHexes[3] && connectedHexes[3].color == color))
        {
            canBeDestroyed = true;         
        }
        else if ((connectedHexes[3] && connectedHexes[3].color == color && connectedHexes[2] && connectedHexes[2].color == color) || (connectedHexes[3] && connectedHexes[3].color == color && connectedHexes[4] && connectedHexes[4].color == color))
        {      
            canBeDestroyed = true;
        }
        else if ((connectedHexes[4] && connectedHexes[4].color == color && connectedHexes[3] && connectedHexes[3].color == color) || (connectedHexes[4] && connectedHexes[4].color == color && connectedHexes[5] && connectedHexes[5].color == color))
        {
            canBeDestroyed = true;
        }
        else if ((connectedHexes[5] && connectedHexes[5].color == color && connectedHexes[4] && connectedHexes[4].color == color) || (connectedHexes[5] && connectedHexes[5].color == color && connectedHexes[0] && connectedHexes[0].color == color))
        {           
            canBeDestroyed = true;          
        }
        else
        {
            canBeDestroyed = false;
        }
    }

    private void Update() {
        Ray ray0 = new Ray(transform.position + new Vector3(0, 0.2f ,0), directions[0]);
        Ray ray1 = new Ray(transform.position + new Vector3(0, 0.2f, 0), directions[1]);
        Ray ray2 = new Ray(transform.position + new Vector3(0, 0.2f, 0), directions[2]);
        Ray ray3 = new Ray(transform.position + new Vector3(0, 0.2f, 0), directions[3]);
        Ray ray4 = new Ray(transform.position + new Vector3(0, 0.2f, 0), directions[4]);
        Ray ray5 = new Ray(transform.position + new Vector3(0, 0.2f, 0), directions[5]);

        RaycastHit hit0;
        RaycastHit hit1;
        RaycastHit hit2;
        RaycastHit hit3;
        RaycastHit hit4;
        RaycastHit hit5;      

        if (Physics.Raycast(ray0, out hit0, rayDistance, LayerMask.GetMask("Hex")))
        {
            Hexagon hex = hit0.transform.GetComponent<Hexagon>();
            if (hex == null) { return; }
            connectedHexes[0] = hex;
        }
        else
        {
            connectedHexes[0] = null;
        }
        if (Physics.Raycast(ray1, out hit1, rayDistance, LayerMask.GetMask("Hex")))
        {
            Hexagon hex = hit1.transform.GetComponent<Hexagon>();
            if (hex == null) { return; }
            connectedHexes[1] = hex;
        }
        else
        {
            connectedHexes[1] = null;
        }
        if (Physics.Raycast(ray2, out hit2, rayDistance, LayerMask.GetMask("Hex")))
        {
            Hexagon hex = hit2.transform.GetComponent<Hexagon>();
            if(hex == null){ return; }
            connectedHexes[2] = hex;
        }
        else
        {
            connectedHexes[2] = null;
        }
        if (Physics.Raycast(ray3, out hit3, rayDistance, LayerMask.GetMask("Hex")))
        {
            Hexagon hex = hit3.transform.GetComponent<Hexagon>();
            if (hex == null) { return; }
            connectedHexes[3] = hex;
        }
        else
        {
            connectedHexes[3] = null;
        }
        if (Physics.Raycast(ray4, out hit4, rayDistance, LayerMask.GetMask("Hex")))
        {
            Hexagon hex = hit4.transform.GetComponent<Hexagon>();
            if (hex == null) { return; }
            connectedHexes[4] = hex;
        }
        else
        {
            connectedHexes[4] = null;
        }
        if (Physics.Raycast(ray5, out hit5, rayDistance, LayerMask.GetMask("Hex")))
        {
            Hexagon hex = hit5.transform.GetComponent<Hexagon>();
            if (hex == null) { return; }
            connectedHexes[5] = hex;
        }
        else
        {
            connectedHexes[5] = null;
        }
        
        SetCanBeDestroyed();

        if (openDebug)
        {
            Debug.DrawLine(ray0.origin, ray0.GetPoint(rayDistance));
            Debug.DrawLine(ray1.origin, ray1.GetPoint(rayDistance));
            Debug.DrawLine(ray2.origin, ray2.GetPoint(rayDistance));
            Debug.DrawLine(ray3.origin, ray3.GetPoint(rayDistance));
            Debug.DrawLine(ray4.origin, ray4.GetPoint(rayDistance));
            Debug.DrawLine(ray5.origin, ray5.GetPoint(rayDistance));

        }
        

    }

}
