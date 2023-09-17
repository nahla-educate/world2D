using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayfabFriendController : MonoBehaviour
{
    public static Action<List<FriendInfo>> OnFriendListUpdated = delegate { };
    private List<FriendInfo> friends;
    private bool isPhotonReady = false;

    private void Awake()
    {
        friends = new List<FriendInfo>();
        PhotonConnector.GetPhotonFriends += HandleGetFriends;
        UIAddFriend.OnAddFriend += HandleAddPlayfabFriend;
        UIFRiend.OnRemoveFriend += HandleRemoveFriend;
    }

    private void OnDestroy()
    {
        PhotonConnector.GetPhotonFriends -= HandleGetFriends;
        UIAddFriend.OnAddFriend -= HandleAddPlayfabFriend;
        UIFRiend.OnRemoveFriend -= HandleRemoveFriend;
    }
    // Start is called before the first frame update
    void Start()
    {
        // Check if the player is logged in
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            // If logged in, get the friends list
            GetPlayfabFriends();
        }
    }

    public void ClickFriend()
    {
        if (PlayFabClientAPI.IsClientLoggedIn())
        {
            // If logged in, get the friends list
            GetPlayfabFriends();
        }
    }


    private void HandleAddPlayfabFriend(string name)
    {
        var request = new AddFriendRequest { FriendTitleDisplayName = name };
        PlayFabClientAPI.AddFriend(request, OnFriendAddedSuccess, OnFailure);
    }
    private void HandleRemoveFriend(string name)
    {
        string id = friends.FirstOrDefault(f => f.TitleDisplayName == name).FriendPlayFabId;
        Debug.Log($"Remove friend {name} with id {id}");
        var request = new RemoveFriendRequest { FriendPlayFabId = id };
        PlayFabClientAPI.RemoveFriend(request, OnFriendRemoveSuccess, OnFailure);
    }

    private void HandleGetFriends()
    {
        if (isPhotonReady)
        {
            GetPlayfabFriends();
        }
        else
        {
            Debug.LogWarning("Photon is not ready yet. Wait for the connection to be established.");
        }
    }
    private void GetPlayfabFriends()
    {
        
        var request = new GetFriendsListRequest {
            ProfileConstraints = new PlayerProfileViewConstraints
            {
                ShowDisplayName = true, // Include display name
                ShowAvatarUrl = true    // Include avatar URL
            },
            XboxToken = null };
        PlayFabClientAPI.GetFriendsList(request, OnFriendsListSuccess, OnFailure);
    }
    private void OnFriendAddedSuccess(AddFriendResult result)
    {
        GetPlayfabFriends();
    }
    private void OnFriendsListSuccess(GetFriendsListResult result)
    {
        friends = result.Friends;
        OnFriendListUpdated?.Invoke(result.Friends);  
    }
    private void OnFriendRemoveSuccess(RemoveFriendResult result)
    {
        GetPlayfabFriends();
    }

    private void OnFailure(PlayFabError error)
    {
        Debug.Log($"error: {error.GenerateErrorReport()}");
    }
    private void OnConnectedToMaster()
    {
        isPhotonReady = true;
    }

}
