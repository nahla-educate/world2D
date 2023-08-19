using System;
using TMPro;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;

public class UIFRiend : MonoBehaviour
{
    [SerializeField] private TMP_Text friendNameText;
    [SerializeField] private FriendInfo friend;
    [SerializeField] private string friendName;
    [SerializeField] private Image onlineImage;
    [SerializeField] private Color onlineColor;
    [SerializeField] private Color offlineColor;

   public static Action<string> OnRemoveFriend = delegate { };
    public static Action<string> OnInviteFriend = delegate { };
    public static Action<string> OnGetCurrentStatus = delegate { };

    private void Awake()
    {
        PhotonChatController.OnStatusUpdated += HandleStatusUpdated;
        PhotonChatFriendController.OnStatusUpdated += HandleStatusUpdated;
    }
    private void OnDestroy()
    {
        PhotonChatController.OnStatusUpdated -= HandleStatusUpdated;
        PhotonChatFriendController.OnStatusUpdated -= HandleStatusUpdated;
    }
    private void OnEnable()
    {
        if (string.IsNullOrEmpty(friendName)) return;
        OnGetCurrentStatus?.Invoke(friendName);
    }
    public void Initialize(FriendInfo friend)
    {
        
        Debug.Log($"{friend.UserId} is online : {friend.IsOnline}; in room {friend.IsInRoom}; room name: {friend.Room}");
        this.friend = friend;
         friendNameText.SetText(this.friend.UserId);
        SetStatus();
       

    }
    public void Initialize(string friendName)
    {
        /* this.friend = friend;
         friendNameText.SetText(this.friend.UserId);*/
        Debug.Log($"{friend.UserId} is added");
        this.friendName = friendName;
        SetupUI();
        OnGetCurrentStatus?.Invoke(friendName);


    }
    public void RemoveFriend()
    {
        OnRemoveFriend?.Invoke(friend.UserId);
    }
    public void InviteFriend()
    {
        Debug.Log($"Clicked to invite friend {friend.UserId}");
        OnInviteFriend?.Invoke(friend.UserId);

    }
    private void HandleStatusUpdated(PhotonStatus status)
    {
        if(string.Compare(friendName, status.PlayerName) == 0)
        {
            Debug.Log($"Updating status in UI for {status.PlayerName} to status {status.Status}");
           // SetStatus(status.Status);
        }
        else
        {
            Debug.Log($"Good for nothing HandleStatusUpdated {status.PlayerName}");
        }
    }
    private void SetupUI()
    {
        friendNameText.SetText(friendName);
    }
    private void SetStatus()
    {
        if (friend.IsOnline)
        {
            onlineImage.color = onlineColor;
        }
        else
        {
            onlineImage.color = offlineColor;
        }
    }
}
