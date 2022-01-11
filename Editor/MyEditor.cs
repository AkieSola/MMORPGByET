using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MyEditor : Editor
{
    [MenuItem("����/�������飬 &_f",false)]
    public static void CreateCube()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);   
        cube.name = "����";
    }

    [MenuItem("����/���ٷ���, &_G",false)]
    public static void DestoryCube()
    {
        GameObject cube = GameObject.Find("����");
        Debug.Log(cube);
        if (cube != null)
        {
            Editor.DestroyImmediate(cube);
        }
      
    }
    private void OnSceneGUI()
    {
        if (Input.GetKeyDown(KeyCode.F) && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            CreateCube();
        }
        if (Input.GetKeyDown(KeyCode.G) && Input.GetKeyDown(KeyCode.LeftAlt))
        {
            DestoryCube();
        }
    }
}
