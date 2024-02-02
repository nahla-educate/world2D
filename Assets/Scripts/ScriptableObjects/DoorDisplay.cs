using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorDisplay : MonoBehaviour
{
    public static DoorDisplay Instance { get; private set; }

    [SerializeField] private List<Door> doors;
    public Text textP;
    public GameObject cube;

    public void InteractWithDoor(string doorTag)
    {
        Door door = doors.Find(d => d.doorTag == doorTag);
        Debug.Log("inter");
       
        if (door != null)
        {
            Debug.Log("not null");
            // Set room and UI elements
            textP.text = door.doorTag;
            door.ActiveRoom();
            

            // Perform custom action (if any)
         //   door.onInteract?.Invoke();
        }
    }
}
