using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;
using ExitGames.Client.Photon;

public class RoomList : MonoBehaviourPunCallbacks
{
    public GameObject RoomPrefab;
    public GameObject RequestRoomPrefab;
    public Transform contentTransform;

    

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        // Clear the existing room list UI
        foreach (Transform child in contentTransform)
        {
            Destroy(child.gameObject);
        }

        // Iterate through the updated room list and populate the UI
        foreach (RoomInfo room in roomList)
        {
            string roomName = room.Name;

            bool isRequestRoom = (bool)room.CustomProperties["JoinRequest"];

            if (!isRequestRoom)
            {
                GameObject roomPrefab = RoomPrefab;
                GameObject roomObject = Instantiate(roomPrefab, Vector3.zero, Quaternion.identity, contentTransform);
                roomObject.GetComponent<Room>().Name.text = roomName;
            }
        }
    }

    public void OnRequestToJoinButtonClicked(string roomName)
    {
        ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable
        {
            { "JoinRequest", true },
            { "RequestSender", PhotonNetwork.NickName } // Optionally, include sender's name
        };

        PhotonNetwork.CurrentRoom.SetCustomProperties(customProperties);
    }

}
