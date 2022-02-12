using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HexMapGenerator))]
public class HexMapEditor : Editor 
{
    public override void OnInspectorGUI() 
    {
        base.OnInspectorGUI();

        HexMapGenerator hexMapGenerator = target as HexMapGenerator;
        //hexMapGenerator.SpawnMap();
    }
}
