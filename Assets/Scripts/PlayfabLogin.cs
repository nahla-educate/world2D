using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayfabLogin : MonoBehaviour
{
    [SerializeField] private string username;

    #region Unity Methods
    private void Start()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.TitleId))
        {
            PlayFabSettings.TitleId = "5FA4A";
        }
    }
    #endregion

    #region Private Methods
    private bool IsValidUsername()
    {
        bool isValid = false;

        if(username.Length >= 3 && username.Length <= 24)
        {
            isValid = true;
        }
        return isValid;
    }
    private void LoginWithCustomId()
    {
        Debug.Log($"Login to Playfab as {username}");
        var request = new LoginWithCustomIDRequest { CustomId = username, CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginCustomIdSuccess, OnFailure);
    }
    private void UpdateDisplayName(string displayname)
    {
        Debug.Log($"Updating Playfab account's display bname to {displayname}");
        var request = new UpdateUserTitleDisplayNameRequest { DisplayName = displayname };
        PlayFabClientAPI.UpdateUserTitleDisplayName(request, OnDisplayNameSuccess, OnFailure);

    }
    #endregion
    #region Public Methods
    public void SetUsername(string name)
    {
        username = name;
        PlayerPrefs.SetString("USERNAME", username);
    }
    public void Login()
    {
        if (!IsValidUsername()) return;
        LoginWithCustomId();
    }
    #endregion
    #region Playfab Callbacks
    private void OnLoginCustomIdSuccess(LoginResult obj)
    {
        Debug.Log($"You have logged into playfab using custom id: {username}");
        UpdateDisplayName(username);

        //FindObjectOfType<Bridge>().SendToJS("Login success!");
        
    }

    private void OnFailure(PlayFabError error)
    {
        Debug.Log($"issue: {error.GenerateErrorReport()}");
    }
    private void OnDisplayNameSuccess(UpdateUserTitleDisplayNameResult obj)
    {
        Debug.Log($"You have updated the displayname of playfab account!");
        SceneController.LoadScene("MainMenu");

    }
    #endregion
}
