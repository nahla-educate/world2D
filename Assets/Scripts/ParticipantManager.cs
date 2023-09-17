using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;

public class ParticipantManager : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform _content;
    [SerializeField]
    private ParticipantUI _participantUI;
    private List<ParticipantUI> _list = new List<ParticipantUI>();

    public override void OnJoinedRoom()
    {
        GetCurrentRoomPlayers();
    }
    private void GetCurrentRoomPlayers()
    {
        foreach(KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPlayerListing(playerInfo.Value);
        }
    }
    private void AddPlayerListing(Player player)
    {
        ParticipantUI listing = Instantiate(_participantUI, _content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            _list.Add(listing);
        }
    }
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPlayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _list.FindIndex(x => x.Player == otherPlayer);
        if(index != -1)
        {
            Destroy(_list[index].gameObject);
            _list.RemoveAt(index);
        }

    }
}
