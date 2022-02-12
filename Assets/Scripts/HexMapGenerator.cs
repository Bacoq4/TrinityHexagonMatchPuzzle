using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMapGenerator : MonoBehaviour
{
    public Hexagon hexPrefab;
    public float distBtwHexes;
    public Transform hexHolder;
    public Vector2Int MapSize;
    public Vector2 diffVector;
    public float yIncrement;

    public Material[] materials;

    private void Awake() {
        SpawnMap();
    }

    public void SpawnMap()
    {
        for (int i = 0; i < hexHolder.childCount; i++)
        {
            DestroyImmediate(hexHolder.GetChild(i).gameObject);
        }

        float x = 0;
        float y = 0;
        
        for (int i = 0; i < MapSize.y; i++)
        {
            bool b = false;
            x = 0;
            for (int j = 0; j < MapSize.x; j++)
            {
                if (i % 2 == 1)
                {
                    Vector3 v1 = new Vector3((x+diffVector.x) * distBtwHexes, 0, y * distBtwHexes);
                    Hexagon hex = SpawnHexagon(v1);
                    Material material = materials[UnityEngine.Random.Range(0, 5)];
                    hex.GetComponent<MeshRenderer>().sharedMaterial = material;
                    hex.color = material.color;
                    hex.transform.SetParent(hexHolder);
                    if (!b)
                    {
                        b = true;
                        hex.isOnBottom = true;
                    }
                }
                else
                {
                    Vector3 v1 = new Vector3(x * distBtwHexes, 0, y * distBtwHexes);
                    Hexagon hex = SpawnHexagon(v1);
                    Material material = materials[UnityEngine.Random.Range(0, 5)];
                    hex.GetComponent<MeshRenderer>().sharedMaterial = material;
                    hex.color = material.color;
                    hex.transform.SetParent(hexHolder);
                    if (!b)
                    {
                        b = true;
                        hex.isOnBottom = true;
                    }
                }
                x++;
            }
            y+=yIncrement;
        }
    }
    public Hexagon SpawnHexagon(Vector3 pos)
    {
        Hexagon hex = Instantiate(hexPrefab, pos, Quaternion.identity);
        return hex;
    }
    public Transform SpawnTransform(Vector3 pos, Transform obj)
    {
        Transform go = Instantiate(obj , pos, Quaternion.identity);
        return go;
    }


    // private void BeforeSpawn()
    // {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
    //     float rayDistance;

    //     if (groundPlane.Raycast(ray, out rayDistance))
    //     {
    //         Vector3 point = ray.GetPoint(rayDistance);
    //         Debug.DrawLine(ray.origin, point, Color.red);
    //         if (!hasSpawned)
    //         {
    //             Hexagon hex = SpawnHexagon(point);
    //             hex.canBePlaced = true;
    //             currentHex = hex;
    //             hasSpawned = true;
    //         }
    //         if(currentHex == null) { return; }
    //         currentHex.transform.position = point;
    //         if (currentHex.isReadyToBePlaced && Input.GetMouseButtonDown(0))
    //         {
    //             currentHex.canBePlaced = false;
    //             currentHex = null;
    //             Hexagon hex = SpawnHexagon(Input.mousePosition);
    //             currentHex = hex;
    //             hex.canBePlaced = true;
    //         }
    //         //Debug.DrawRay(ray.origin,ray.direction * 100,Color.red);
    //     }
    //}


}
