using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime; // Add this using directive

public class Room : MonoBehaviour
{
    public Text Name;

    public void JoinRoom()
    {
        GameObject.Find("Connector").GetComponent<PhotonConnector>().JoinRoomInList(Name.text);
    }
}

