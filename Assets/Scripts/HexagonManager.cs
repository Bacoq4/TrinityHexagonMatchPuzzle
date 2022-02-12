using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexagonManager : MonoBehaviour
{
    private Hexagon[] hexagons; 
    private List<Hexagon> destroyableHexagons;

    private static float timer;
    private static float timeControlRate = 1;

    public static void resetTimer()
    {
        timer = Time.time + timeControlRate;
    }

    private void Start() {
        resetTimer();
    }

    private void Update() {

        if(timer < Time.time)
        {
            destroyableHexagons = new List<Hexagon>();
            hexagons = FindObjectsOfType<Hexagon>();

            resetTimer();
            foreach (Hexagon hex in hexagons)
            {
                if (hex.canBeDestroyed)
                {
                    destroyableHexagons.Add(hex);
                }
            }
            foreach (Hexagon hex in destroyableHexagons)
            {
                Destroy(hex.gameObject);
            }
        }

        

        

    }

}
