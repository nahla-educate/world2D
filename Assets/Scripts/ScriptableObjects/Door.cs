using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Door", menuName = "ScriptableObjects/Door", order = 1)]
public class Door : ScriptableObject
{
    public new string doorTag;
    public string roomName;
    public GameObject cube;


    public void ActiveRoom()
    {
        cube.SetActive(true);
        GameObject cylinder = GameObject.Find(roomName);
        if (cylinder != null)
        {
            Debug.Log("Cylinder found: " + roomName);
            cylinder.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Cylinder not found: " + roomName);
        }
    }
}
