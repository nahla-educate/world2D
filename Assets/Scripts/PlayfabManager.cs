using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class PlayfabManager : MonoBehaviour
{
    public PlayerData characterEditor;
    [SerializeField] AvatarSetup avatarSetup;
    void Start()
    {
        GetAppearance();
        
    }


    //Player data
    public void GetAppearance()
    {
        PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnDataRecieved, OnError);
        Debug.Log("nn");
    }

    void OnDataRecieved(GetUserDataResult result)
    {
        Debug.Log("yes");
        if (result.Data != null && result.Data.ContainsKey("Avatar"))
        {
            // Get the appearance data as a JSON string
            string appearanceData = result.Data["Avatar"].Value;
            characterEditor.SetAppearance(appearanceData); 

            // Deserialize the JSON data to the Data object
            Data avatarData = JsonUtility.FromJson<Data>(appearanceData);

            // Update the avatar using AvatarSetup
            avatarSetup.SetAvatar(avatarData);
        }
        else
        {
            Debug.Log("Player data not complete!");
        }

    }

    public void SaveAppearance()
    {
        // Convert the appearance data to a JSON string
        string appearanceData = JsonUtility.ToJson(PlayerData.instance.data);

        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string>
            {
                {"Avatar", appearanceData }
               // {"Skin", PlayerData.instance.data.hair.ToString() }
            }
        };
        PlayFabClientAPI.UpdateUserData(request, OnDataSend, OnError);
    }

    void OnDataSend(UpdateUserDataResult result)
    {
        Debug.Log("Successfully data send");
        SceneManager.LoadScene("MainMenu");
    }

    
    void OnError(PlayFabError error)
    {
        Debug.Log("Error");
    }
}
