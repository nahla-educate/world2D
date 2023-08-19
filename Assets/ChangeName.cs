using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using Photon.Realtime;
using TMPro;

public class ChangeName : MonoBehaviour
{
    [SerializeField] private TMP_Text playerNameText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerNameText.text = PhotonNetwork.LocalPlayer.NickName;
    }
}
