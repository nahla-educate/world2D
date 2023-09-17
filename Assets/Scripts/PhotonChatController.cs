using Photon.Chat;
using Photon.Pun;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ExitGames.Client.Photon;
using PlayFab.ClientModels;
using TMPro;

public class PhotonChatController : MonoBehaviour, IChatClientListener
{
    [SerializeField] private string nickname;
    [SerializeField] private GameObject panelChat;
    [SerializeField] private GameObject panelJoin;
    private ChatClient chatClient;
    private string recipient;
    private string currentChannel; // Track the current chat channel
    bool isConnected;

    string currentChat;
    [SerializeField] Text chatDisplay;


    [SerializeField] private InputField messageInputField;
    [SerializeField] private ScrollRect chatScrollRect;
    [SerializeField] private RectTransform chatContent;

    [SerializeField] private GameObject messagePrefab;



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
       // chatClient = new ChatClient(this);
       // ConnectToPhotonChat();
    }

    private void Update()
    {
        if (isConnected)
        {
            chatClient.Service();
        }        
    }
    #endregion

    #region Private Methods
    private void AddMessageToUI(string sender, string message)
    {
        // Load a prefab or create your TMP_Text message UI element
        GameObject newMessagePrefab = Instantiate(messagePrefab, chatContent);
        TMP_Text textComponent = newMessagePrefab.GetComponent<TMP_Text>();
        textComponent.text = $"{sender}: {message}";

        // Adjust the layout to account for the new message
        LayoutRebuilder.ForceRebuildLayoutImmediate(chatContent);

        // Scroll to the bottom to show the new message
        Canvas.ForceUpdateCanvases();
        chatScrollRect.verticalNormalizedPosition = 0f;
    }



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
    public void UsernameOnValueChange(string valueIn)
    {
        nickname = valueIn;
    }
    public void TypeChatOnValueChange(string valueIn)
    {
        currentChat = valueIn;
    }
    public void ChatConnectOnClick()
    {
        isConnected = true;
        chatClient = new ChatClient(this);
        chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion, new AuthenticationValues(nickname));
        Debug.Log("connecting");
    }
    public void HandleFriendInvite(string recipient)
    {
        Debug.Log(recipient);
        Debug.Log(PhotonNetwork.CurrentRoom.Name);
        if (chatClient != null)
        {
            currentChannel = recipient;
            chatClient.SendPrivateMessage(recipient, PhotonNetwork.CurrentRoom.Name);
        }
        else
        {
            Debug.LogError("chatClient is null!");
        }

    }
    public void SendMessageButtonClicked()
    {
        string message = messageInputField.text;
        if (!string.IsNullOrEmpty(message))
        {
            if (chatClient != null)
            {
                chatClient.SendPrivateMessage(PhotonNetwork.CurrentRoom.Name, message);
                Debug.Log("hi" + message);
                Debug.Log("room" + PhotonNetwork.CurrentRoom.Name);
                AddMessageToUI(nickname, message);
                messageInputField.text = ""; // Clear the input field after sending the message
            }
            else
            {
                Debug.LogError("chatClient is null!");
            }
        }
    }
    public void SubmitPublicChatOnClick()
    {
        if (!string.IsNullOrEmpty(currentChat))
        {
            if (chatClient != null)
            {
                chatClient.PublishMessage(currentChannel, currentChat);
                Debug.Log($"Published in channel {currentChannel}: {currentChat}");
                messageInputField.text = "";
                currentChat = "";
            }
            else
            {
                Debug.LogError("chatClient is null!");
            }
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
        panelJoin.SetActive(false);
       // OnChatConnected?.Invoke(chatClient);

        // Determine the current room's name
        string currentRoomName = PhotonNetwork.CurrentRoom.Name;
        Debug.Log(currentRoomName);
        switch (currentRoomName.ToLower())
        {
            case "roomone":
                chatClient.Subscribe(new string[] { "channelOne" });
                currentChannel = "channelOne"; // Set currentChannel to "channelOne"
                break;
            case "roomtwo":
                chatClient.Subscribe(new string[] { "channelTwo" });
                currentChannel = "channelTwo"; // Set currentChannel to "channelTwo"
                break;
            case "roomthree":
                chatClient.Subscribe(new string[] { "channelThree" });
                currentChannel = "channelThree"; // Set currentChannel to "channelThree"
                break;
            case "roomfour":
                chatClient.Subscribe(new string[] { "channelFour" });
                currentChannel = "channelFour"; // Set currentChannel to "channelFour"
                break;
            case "roomfive":
                chatClient.Subscribe(new string[] { "channelFive" });
                currentChannel = "channelFive"; // Set currentChannel to "channelFive"
                break;
            case "roomsix":
                chatClient.Subscribe(new string[] { "channelSix" });
                currentChannel = "channelSix"; // Set currentChannel to "channelSix"
                break;
            case "roomseven":
                chatClient.Subscribe(new string[] { "channelSeven" });
                currentChannel = "channelSeven"; // Set currentChannel to "channelSeven"
                break;
            case "roomeight":
                chatClient.Subscribe(new string[] { "channelEight" });
                currentChannel = "channelEight"; // Set currentChannel to "channelEight"
                break;
            case "roomnine":
                chatClient.Subscribe(new string[] { "channelNine" });
                currentChannel = "channelNine"; // Set currentChannel to "channelNine"
                break;
            case "roomten":
                chatClient.Subscribe(new string[] { "channelTen" });
                currentChannel = "channelTen"; // Set currentChannel to "channelTen"
                break;
            default:
                // Handle the case where currentRoomName is not recognized
                // You can add error handling or default behavior here
                break;
        }




    }
    public void OnChatStateChange(ChatState state)
    {
        Debug.Log($"Photon chat OnChatStateChange :  {state.ToString()}");
    }
    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        Debug.Log($"Photon chat OnGetMessages :  {channelName}");
        string msgs = "";
        for(int i =0;i < senders.Length; i++)
        {
            Debug.Log($"{senders[i]} messaged : {messages[i]}");
            msgs = string.Format("{0}: {1}", senders[i], messages[i]);
            chatDisplay.text += "\n " + msgs;
            Debug.Log(msgs);

        }

    }
    public void OnPrivateMessage(string sender, object message, string channelName)
    {

        if (!string.IsNullOrEmpty(message.ToString()))
        {
            Debug.Log($"{sender}: {message}");
            // Handle the received message here
            AddMessageToUI(sender, message.ToString());
        }
    }
    /*public void OnPrivateMessage(string sender, object message, string channelName)
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

      
    }*/
    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log($"Photon Chat OnStatusUpdate: {user} changed to {status} : {message}");
        PhotonStatus newStatus = new PhotonStatus(user, status, (string)message);
        OnStatusUpdated?.Invoke(newStatus);
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        Debug.Log($"Photon Chat Onsubscribed");
        panelChat.SetActive(true);
        for (int i = 0; i < channels.Length; i++)
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
