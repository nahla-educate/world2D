using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sphere : MonoBehaviour
{
    [SerializeField] private List<Door> doors;
   // DoorDisplay doorDisplay;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hi");
        DoorDisplay doorDisplay = DoorDisplay.Instance;
        if (doorDisplay != null)
        {
            Debug.Log("hh");
            doorDisplay.InteractWithDoor(other.tag);
        }
    }
}
