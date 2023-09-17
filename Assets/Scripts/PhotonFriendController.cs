using Photon.Pun;
using Photon.Realtime;
using PlayfabFriendInfo = PlayFab.ClientModels.FriendInfo;
using PhotonFriendInfo = Photon.Realtime.FriendInfo;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class PhotonFriendController : MonoBehaviourPunCallbacks
{
    public static Action<List<PhotonFriendInfo>> OnDisplayFriends = delegate { };

    private void Awake()
    {
        PlayfabFriendController.OnFriendListUpdated += HandleFriendsUpdated;
    }

    

    private void OnDestroy()
    {
        PlayfabFriendController.OnFriendListUpdated -= HandleFriendsUpdated;
    }
    private void HandleFriendsUpdated(List<PlayfabFriendInfo> friends)
    {
        Debug.Log($"{friends.Count}");
        if(friends.Count != 0)
        {
            string[] friendDisplayNames = friends.Select(f => f.TitleDisplayName).ToArray();
            Debug.Log(friendDisplayNames);
            if (PhotonNetwork.IsConnected)
            {
                PhotonNetwork.FindFriends(friendDisplayNames);
                Debug.Log(friendDisplayNames);
            }

        }
        else
        {
            List<PhotonFriendInfo> friendList = new List<PhotonFriendInfo>();
            OnDisplayFriends?.Invoke(friendList);
        }
        
            
        
        
    }
    
    public override void OnFriendListUpdate(List<PhotonFriendInfo> friendList)
    {
        Debug.Log($"{friendList.Count}");
        OnDisplayFriends?.Invoke(friendList);
    }
   

    
}
