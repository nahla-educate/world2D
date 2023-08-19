using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonPlayer : MonoBehaviour
{
    PhotonView myPV;
    GameObject playerAvatar;

    Player[] allPlayers;
    int numberInroom;
    [SerializeField] private TMP_Text playerNameText;

    // Start is called before the first frame update
    void Start()
    {
        myPV = GetComponent<PhotonView>();
        allPlayers = PhotonNetwork.PlayerList;

        numberInroom = 0; // Reset the counter

        // Debug logging to check the length of spawnPoints array
        Debug.Log("SpawnPoints array length: " + AU_Game_Controller.instance.spawnPoints.Length);

        if (myPV.IsMine)
        {
            // Check if spawnPoints is not null and has the correct length
            if (AU_Game_Controller.instance.spawnPoints != null && numberInroom < AU_Game_Controller.instance.spawnPoints.Length)
            {
                playerAvatar = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "Avatar"), AU_Game_Controller.instance.spawnPoints[numberInroom].position, Quaternion.identity);
                playerNameText.text = PhotonNetwork.LocalPlayer.NickName;
            }
            else
            {
                Debug.LogError("spawnPoints is null or numberInroom is out of bounds!");
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
