using Photon.Chat;
using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;
using ExitGames.Client.Photon;
using PlayFab.ClientModels;

public class PhotonChatController : MonoBehaviour, IChatClientListener
{
    [SerializeField] private string nickname;
    private ChatClient chatClient;

    public static Action<string, string> OnRoomInvite = delegate { };
    public static Action<ChatClient> OnChatConnected = delegate { };
    public static Action<PhotonStatus> OnStatusUpdated = delegate { };

    #region Unity Methods
    private void Awake()
    {
        nickname = PlayerPrefs.GetString("USERNAME");
        UIFRiend.OnInviteFriend += HandleFriendInvite;
    }
    private void OnDestroy()
    {

        UIFRiend.OnInviteFriend -= HandleFriendInvite;
    }
    private void Start()
    {
        chatClient = new ChatClient(this);
        ConnectToPhotonChat();
    }

    private void Update()
    {
        chatClient.Service();
    }
    #endregion

    #region Private Methods
    private void ConnectToPhotonChat()
    {
        Debug.Log("Connecting to Photon chat");
        chatClient.AuthValues = new Photon.Chat.AuthenticationValues(nickname);
        ChatAppSettings chatSettings = new ChatAppSettings();
        chatSettings.AppIdChat = PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat;
        // Set any other required properties in chatSettings
        chatClient.ConnectUsingSettings(chatSettings);

    }

    #endregion
    #region Public Methods
    public void HandleFriendInvite(string recipient)
    {
        Debug.Log(recipient);
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
        if (chatClient != null)
        {
            chatClient.SendPrivateMessage(recipient, PhotonNetwork.CurrentRoom.Name);
        }
        else
        {
            Debug.LogError("chatClient is null!");
        }

    }

    #endregion

    #region Photon Chat Callbacks

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log($"Photon chat debugreturn {message}");
    }

    public void OnDisconnected()
    {
        Debug.Log("Disconnected");
    }

    public void OnConnected()
    {
        Debug.Log("Connected chat");
        OnChatConnected?.Invoke(chatClient);

    }
     public void OnChatStateChange(ChatState state)
    {
        Debug.Log($"Photon chat OnChatStateChange :  {state.ToString()}");
    }
    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        Debug.Log($"Photon chat OnGetMessages :  {channelName}");
        for(int i =0;i < senders.Length; i++)
        {
            Debug.Log($"{senders[i]} messaged : {messages[i]}");
        }

    }
    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        if (!string.IsNullOrEmpty(message.ToString()))
        {
              Debug.Log($"{sender} : {message}");
            string[] splitNames = channelName.Split(new char[] {':'});
            
            string senderNAme = splitNames[0];
            if (!sender.Equals(senderNAme, StringComparison.OrdinalIgnoreCase))
            {
                Debug.Log($"{sender} : {message}");
                OnRoomInvite?.Invoke(sender, message.ToString());
              
            }
            
        }

      
    }
    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log($"Photon Chat OnStatusUpdate: {user} changed to {status} : {message}");
        PhotonStatus newStatus = new PhotonStatus(user, status, (string)message);
        OnStatusUpdated?.Invoke(newStatus);
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log($"Photon Chat Onsubscribed");
        for(int i = 0; i < channels.Length; i++)
        {
            Debug.Log($"{channels[i]}");
        }
    }

    public void OnUnsubscribed(string[] channels)
    {
        Debug.Log($"Photon Chat OnUnsubscribed");
        for (int i = 0; i < channels.Length; i++)
        {
            Debug.Log($"{channels[i]}");
        }
    }

    public void OnUserSubscribed(string channel, string user)
    {
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
    }
    #endregion
}
[Serializable]
public class PhotonStatus
{
    public string PlayerName { get; private set; } // Replace with the actual property name you are using
    public int Status { get; private set; }
    public string Message { get; private set; }

    public PhotonStatus(string playerName, int status, string message) // Update the parameter name here
    {
        PlayerName = playerName; // Update the property name here
        Status = status;
        Message = message;
    }
}
