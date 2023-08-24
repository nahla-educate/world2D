using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;
using TMPro;
using ExitGames.Client.Photon;

public class PhotonConnector : MonoBehaviourPunCallbacks
{
    [SerializeField] private string nickname;
    public static Action GetPhotonFriends = delegate { };
    private bool isConnectedToMaster = true;
    public GameObject PrefabTank;
    public Transform SpawPoint;
    public Transform SpawPoint1;
    [SerializeField] public GameObject PanelCreate;

    // [SerializeField] private TMP_Text playerNameText;

    [SerializeField] public TMP_InputField input_Create;
    [SerializeField] public TMP_InputField input_Join; 
    [SerializeField] public TMP_InputField input_CreatePRoom;


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

    private void CreatePhotonRoom(string roomName, bool isRequestRoom)
    {
        RoomOptions ro = new RoomOptions
        {
            IsOpen = true,
            IsVisible = true,
            MaxPlayers = 4,
            CustomRoomProperties = new ExitGames.Client.Photon.Hashtable
            {
                { "JoinRequest", isRequestRoom }
            }
        };

        PhotonNetwork.CreateRoom(roomName, ro, TypedLobby.Default);
        SaveRoomInfo(roomName, isRequestRoom);
    }

    private void ConnectToPhoton(string nickname)
    {
        Debug.Log($"Connect to Photon as {nickname}");
        PhotonNetwork.AuthValues = new AuthenticationValues(nickname);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.NickName = nickname;

        // Clear the saved room name from PlayerPrefs
       // PlayerPrefs.SetString("PHOTONROOM", "");
        PhotonNetwork.ConnectUsingSettings();
    }


    private void SaveRoomInfo(string roomName, bool isRequestRoom)
    {
        string savedRooms = PlayerPrefs.GetString("SAVED_ROOMS", "");

        if (!string.IsNullOrEmpty(savedRooms))
        {
            savedRooms += ";";
        }
        savedRooms += roomName + "," + isRequestRoom.ToString();
        PlayerPrefs.SetString("SAVED_ROOMS", savedRooms);
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
        if (!string.IsNullOrEmpty(roomName))
        {
           // PlayerPrefs.SetString("PHOTONROOM", ""); // Clear the saved room name

            Debug.Log($"Attempting to join room: {roomName}");
            PhotonNetwork.JoinRoom(roomName);
        }
        else
        {
            Debug.Log("No room name saved in PlayerPrefs.");
        }
    }
    #endregion
    #region Public Methods
    public void OnConnectedRoomClicked(string roomName)
    {
        if (isConnectedToMaster) // Ensure you're connected to the master server
        {
            CreatePhotonRoom(roomName, false);

            SaveRoomInfo(roomName, false); // Save the room as a public room

        }
        else
        {
            Debug.LogError("Not connected to the master server yet!");
        }

    }


    public void CreateRoom()
    { //PhotonNetwork.CreateRoom(input_Create.text);
        PanelCreate.SetActive(false);
        string roomName = input_Create.text.Trim();
        if (!string.IsNullOrEmpty(roomName))
        {
            CreatePhotonRoom(roomName, false);
            SaveRoomInfo(roomName, false);
        }
        else
        {
            Debug.LogError("Room name is empty!");
        }
        

    }

    public void CreateRequestRoom()
    {
        string roomName = input_CreatePRoom.text.Trim();
        RoomOptions roomOptions = new RoomOptions
        {
            IsOpen = true,
            IsVisible = true,
            MaxPlayers = 4,
            CustomRoomProperties = new ExitGames.Client.Photon.Hashtable { { "JoinRequest", false } } // Request needed
        };

        PhotonNetwork.CreateRoom(roomName, roomOptions);
        SaveRoomInfo(roomName, true); // Save the room as a request room
    }


    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(input_Join.text);
    }

   
    public void JoinRoomInList(string RoomName)
    {
        Debug.Log($"Joining room: {RoomName}");
        if (isConnectedToMaster) // Ensure you're connected to the master server
        {
            StartCoroutine(DelayedJoin(RoomName));

        }
        else
        {
            Debug.LogError("Not connected to the master server yet!");
        }
       
    }

    private IEnumerator DelayedJoin(string roomName)
    {
        yield return new WaitForSeconds(0.5f); // Adjust the delay as needed
        PhotonNetwork.JoinRoom(roomName);
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
      //  PlayerPrefs.SetString("SAVED_ROOMS", "");
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
        base.OnCreatedRoom();
        Debug.Log($"You have created a Photon Room named {PhotonNetwork.CurrentRoom.Name}");

        // Save room name or other information to your preferred storage mechanism
       

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
        base.OnLeftRoom();

        // Check if the room is empty after you left
        if (PhotonNetwork.CurrentRoom.PlayerCount == 0)
        {
            Debug.Log("You were the last player in the room. The room will be destryed.");
            
        }
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log($"Failed to join the room. Error code: {returnCode}, Message: {message}");

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

