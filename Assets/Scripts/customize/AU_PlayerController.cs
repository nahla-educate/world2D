using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AU_PlayerController : MonoBehaviour
{
    PhotonView myPV;
    public static AU_PlayerController localPlayer;
    [SerializeField] AvatarSetup avatar;
    [SerializeField] Data myData;

    // Implement the IPunObservable interface
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (!PhotonNetwork.IsConnected) // Check if not connected
            return;

        if (stream.IsWriting)
        {
            // Send data over the network (write variables to the stream)
            stream.SendNext(JsonUtility.ToJson(myData)); // Convert myData to a JSON string and send it
        }
        else
        {
            // Receive data from the network (read variables from the stream)
            string receivedData = (string)stream.ReceiveNext(); // Receive the JSON string
            myData = JsonUtility.FromJson<Data>(receivedData); // Convert the JSON string back to myData object
            avatar.SetAvatar(myData); // Update the avatar appearance with the received data
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myPV = GetComponent<PhotonView>();
        if (myPV == null)
        {
            Debug.LogError("PhotonView not found on the GameObject!");
            return;
        }

        if (myPV.IsMine)
        {
            localPlayer = this;
            if (PhotonNetwork.IsConnected) // Check if connected before synchronizing
            {
                avatar.SetAvatar(PlayerData.instance.data);
                SyncAvatar(PlayerData.instance);
            }
        }
    }

    // Synchronize the avatar appearance data over the network
    public void SyncAvatar(PlayerData data)
    {
        if (PhotonNetwork.IsConnected) // Check if connected before synchronizing
        {
            string syncString = data.AvatarToString();
            myPV.RPC("RPC_SyncAvatar", RpcTarget.OthersBuffered, syncString);
        }
    }

    // RPC method to receive and apply synchronized avatar appearance data
    [PunRPC]
    void RPC_SyncAvatar(string data)
    {
        myData = JsonUtility.FromJson<Data>(data);
        avatar.SetAvatar(myData);
    }
}
