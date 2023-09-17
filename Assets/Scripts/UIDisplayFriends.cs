using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Realtime;
using UnityEngine;

public class UIDisplayFriends : MonoBehaviour
{
    [SerializeField] private Transform friendContainer;
    [SerializeField] private UIFRiend uiFriendPrefab;
    private void Awake()
    {
        PhotonFriendController.OnDisplayFriends += HandleDisplayFriends;
  
    }
    private void OnDestroy() {
        PhotonFriendController.OnDisplayFriends -= HandleDisplayFriends;

    }

    private void HandleDisplayFriends(List<FriendInfo> friends)
    {
        foreach(Transform child in friendContainer)
        {
            Destroy(child.gameObject);
        }

        foreach(FriendInfo friend in friends)
        {
            Debug.Log("friends");
            UIFRiend uifriend = Instantiate(uiFriendPrefab, friendContainer);
            uifriend.Initialize(friend);
            Debug.Log(uifriend);
        }
    }
}
