using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;
using TMPro;

public class PhotonConnector : MonoBehaviourPunCallbacks
{
    [SerializeField] private string nickname;
    public static Action GetPhotonFriends = delegate { };
    private bool isConnectedToMaster = true;
    public GameObject PrefabTank;
    public Transform SpawPoint;
    public Transform SpawPoint1;
    // [SerializeField] private TMP_Text playerNameText;
   

    // List to store spawned players
    private List<GameObject> spawnedPlayers = new List<GameObject>();


    #region Unity Method
    private void Awake()
    {
        nickname = PlayerPrefs.GetString("USERNAME");
        UIInvite.OnRoomInviteAccept += HandleRoomInviteAccept;
    } 
    private void OnDestroy()
    {

        UIInvite.OnRoomInviteAccept -= HandleRoomInviteAccept;
    }
    private void Start()
    {        
        ConnectToPhoton(nickname);

    }
   
   
    #endregion
    #region Private Methods 
    
    private void CreatePhotonRoom(string roomName)
    {
        RoomOptions ro = new RoomOptions();
        ro.IsOpen = true;
        ro.IsVisible = true;
        ro.MaxPlayers = 4;
        PhotonNetwork.JoinOrCreateRoom(roomName, ro, TypedLobby.Default);
       

    }
    private void ConnectToPhoton(string nickname)
    {
        Debug.Log($"Connect to Photon as {nickname}");
        PhotonNetwork.AuthValues = new AuthenticationValues(nickname);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = nickname;
        PhotonNetwork.ConnectUsingSettings();
    }

    private void HandleRoomInviteAccept(string roomName)
    {
        PlayerPrefs.GetString("PHOTONROOM", roomName);
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
        else
        {
            if (PhotonNetwork.InLobby)
            {
                JoinPlayerRoom();
            }
        }
    }
    private void JoinPlayerRoom()
    {
        string roomName = PlayerPrefs.GetString("PHOTONROOM");
        PlayerPrefs.SetString("PHOTONROOM", "");
        PhotonNetwork.JoinRoom(roomName);
    }
    #endregion
    #region Public Methods
    public void OnConnectedRoomClicked(string roomName)
    {
        if (isConnectedToMaster) // Ensure you're connected to the master server
        {
            CreatePhotonRoom(roomName);
           
        }
        else
        {
            Debug.LogError("Not connected to the master server yet!");
        }

    }
  
    #endregion

    #region Photon Callbacks
    public override void OnConnectedToMaster()
    {
        Debug.Log("You have connected to the Photon Master Server");
       
        isConnectedToMaster = true; // Set the flag to indicate successful connection

        if (!PhotonNetwork.InLobby)
        {
            PhotonNetwork.JoinLobby();
        }
        GetPhotonFriends?.Invoke();

    }
    public override void OnJoinedLobby()
    {
        Debug.Log("You have connected to a Photon Lobby");
        // CreatePhotonRoom("TestRoom");
        GetPhotonFriends?.Invoke();
        string roomName = PlayerPrefs.GetString("PHOTONROOM");
        if (!string.IsNullOrEmpty(roomName))
        {
            JoinPlayerRoom();

        }

    }
    public override void OnCreatedRoom()
    {
        Debug.Log($"You have created a Photon Room named {PhotonNetwork.CurrentRoom.Name}");
       

    }
    public override void OnJoinedRoom()
    {
        Debug.Log($"You have joined the Photon room {PhotonNetwork.CurrentRoom.Name}");
        StartCoroutine(SpawPlayer());
      

    }
    IEnumerator SpawPlayer()
    {
        /*  Transform Sp;
          if (PhotonNetwork.PlayerList.Length <= 1)
          {
              Sp = SpawPoint;
          }
          else
          {
              Sp = SpawPoint1;
          }
          GameObject myplayer = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Avatar"), Sp.position, Quaternion.identity, 0) as GameObject;
          playerNameText.text = PhotonNetwork.LocalPlayer.NickName;

          yield return new WaitForSeconds(5);*/
        Transform spawnPoint = PhotonNetwork.PlayerList.Length <= 1 ? SpawPoint : SpawPoint1;

        GameObject myPlayer = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Avatar"), spawnPoint.position, Quaternion.identity, 0) as GameObject;
        spawnedPlayers.Add(myPlayer); // Add the spawned player to the list

        // Update the names of all spawned players
        UpdateSpawnedPlayerNames();

        yield return new WaitForSeconds(5);


    }

    // Method to update the names of spawned players
    void UpdateSpawnedPlayerNames()
    {
        foreach (var player in spawnedPlayers)
        {
            TMP_Text playerNameText = player.GetComponentInChildren<TMP_Text>();
            if (playerNameText != null)
            {
                // playerNameText.text = PhotonNetwork.LocalPlayer.NickName;
                playerNameText.text = player.GetPhotonView().Owner.NickName;
            }
        }
    }
    public override void OnLeftRoom()
    {
        Debug.Log("You have left a Photon room");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"You failed to join the Photon room: {message}");
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log($"Another Player has joined the room {newPlayer.UserId}");
       
    }
    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log($" Player has left the room {otherPlayer.UserId}");
    }
    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        Debug.Log($"New MasterClient is {newMasterClient.UserId}");
    }
    #endregion
}

