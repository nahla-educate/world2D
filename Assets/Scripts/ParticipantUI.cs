using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;

public class ParticipantUI : MonoBehaviour
{
    [SerializeField] private Text playerText;
    public Player Player { get; private set; }

    public void SetPlayerInfo(Player player)
    {
        Player = player;
        playerText.text = player.NickName;
    }
}
