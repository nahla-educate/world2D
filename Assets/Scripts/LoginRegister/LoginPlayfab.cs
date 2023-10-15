using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class LoginPlayfab : MonoBehaviour
{
    [SerializeField] private string username;

    public AudioSource src;
    public AudioClip loginSound, errorSound, warnSound;

    private bool isPasswordShown = false;
    [SerializeField] Text MessageText;
    [SerializeField] Text LoginText;
    [SerializeField] Text PwdMessageText;
    [SerializeField] Text UsernameMessageText;

    [Header("Login")]
    [SerializeField] InputField MailLoginInput;
    [SerializeField] InputField PwdLoginInput;
    [SerializeField] GameObject LoginPage;

    [Header("Register")]
    [SerializeField] InputField UsernameRegisterInput;
    [SerializeField] InputField MailRegisterInput;
    [SerializeField] InputField PwdRegisterInput;
    [SerializeField] GameObject RegisterPage;

    [Header("Recovery")]
    [SerializeField] InputField EmailRecoveryInput;
    [SerializeField] GameObject RecoveryPage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #region Buttom Functions
    private bool IsValidForm()
    {
        bool isValid = false;
        string password = PwdRegisterInput.text;
        string username = UsernameRegisterInput.text;
        if (password.Length < 6)
        {
            src.clip = errorSound;
            src.Play();
            PwdMessageText.text = "Password is too short. It should be more than 6 characters.";
        }else
        {
            PwdMessageText.text = "";
        }
        if (username.Length < 3)
        {
            src.clip = errorSound;
            src.Play();
            UsernameMessageText.text = "Username is too short. It should be more than 3 characters.";
        }
        else if (username.Length > 24)
        {
            src.clip = errorSound;
            src.Play();
            UsernameMessageText.text = "Username is too long. It should be less than 24 characters.";
        }
        else
        {
            UsernameMessageText.text = "";
        }
        if(password.Length >= 6 && username.Length >= 3 && username.Length <= 24)
        {
            UsernameMessageText.text = "";
            PwdMessageText.text = "";
            isValid = true;
        }
        return isValid;
    }
    public void RegisterUser()
    {
        IsValidForm();
        var request = new RegisterPlayFabUserRequest
        {
            DisplayName = UsernameRegisterInput.text,
            Email = MailRegisterInput.text,
            Password = PwdRegisterInput.text,

            RequireBothUsernameAndEmail = false
        };
        
        PlayFabClientAPI.RegisterPlayFabUser(request, OnregisterSuccess, OnError);

    }
    private bool IsValidLogin()
    {
        bool isValid = false;
        string email = MailLoginInput.text;
        string password = PwdLoginInput.text;
        if (password.Length < 6)
        {
            src.clip = errorSound;
            src.Play();
            MessageText.text = "Password is too short. It should be more than 6 characters.";
        }
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            src.clip = errorSound;
            src.Play();
            MessageText.text = "Email and password are required fields.";
        }
        if (password.Length >= 6 && !string.IsNullOrEmpty(email))
        {
            isValid = true;
        }
        return isValid;
    }
    public void ShowHidePwd()
    {
        isPasswordShown = !isPasswordShown;

        if (isPasswordShown)
        {
            PwdLoginInput.contentType = InputField.ContentType.Standard;
        }
        else
        {
            PwdLoginInput.contentType = InputField.ContentType.Password;
        }
    }
    public void Login()
    {
        string email = MailLoginInput.text;
        string password = PwdLoginInput.text;
        
        if (IsValidLogin())
        {
            var request = new LoginWithEmailAddressRequest
            {
                Email = MailLoginInput.text,
                Password = PwdLoginInput.text,

                InfoRequestParameters = new GetPlayerCombinedInfoRequestParams
                {
                    GetPlayerProfile = true
                }
            };
            MessageText.color = Color.yellow;
            MessageText.text = "Logging in, please wait...";
            PlayFabClientAPI.LoginWithEmailAddress(request, OnLoginSuccess, OnFailure);
        } 

        
    }
    public void RecoveryUser()
    {
        var request = new SendAccountRecoveryEmailRequest
        {
            Email = EmailRecoveryInput.text,
            TitleId = "EE429",
        };
        PlayFabClientAPI.SendAccountRecoveryEmail(request, OnRecoverySuccess, OnError);
    }
    private void OnRecoverySuccess(SendAccountRecoveryEmailResult obj)
    {
        MessageText.color = Color.green;
        MessageText.text = "Recovery Mail Sent";
    }


    private void OnLoginSuccess(LoginResult result)
    {
        Debug.Log("success");
        string name = null;
        if (result.InfoResultPayload != null)
        {
            name = result.InfoResultPayload.PlayerProfile.DisplayName;
            username = name;
            PlayerPrefs.SetString("USERNAME", username);
        }
        Debug.Log(name);
        src.clip = loginSound;
        src.Play();
        MessageText.color = Color.green;
        MessageText.text = "Welcome " + name + " !";
        StartCoroutine(LoadNextScene());
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    IEnumerator LoadNextScene()
    {
        yield return new WaitForSeconds(2);
        SceneController.LoadScene("MainMenu");
    }


    private void OnFailure(PlayFabError Error)
    {
        src.clip = errorSound;
        src.Play();
        MessageText.text = Error.ErrorMessage;
        Debug.Log(Error.GenerateErrorReport());
    }
    private void OnError(PlayFabError Error)
    {
        src.clip = errorSound;
        src.Play();
        Debug.Log("error");
        MessageText.text = Error.ErrorMessage;
        
        Debug.Log(Error.GenerateErrorReport());
    }
    private void OnregisterSuccess(RegisterPlayFabUserResult obj)
    {
        MessageText.color = Color.green;
        MessageText.text = "New Account Is Created !";
        OpenLoginPage();
    }
    public void OpenLoginPage()
    {
        LoginPage.SetActive(true);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(false);
    }
    public void OpenRegisterPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(true);
        RecoveryPage.SetActive(false);
    }
    public void OpenRecoveryPage()
    {
        LoginPage.SetActive(false);
        RegisterPage.SetActive(false);
        RecoveryPage.SetActive(true);
    }
    #endregion
   
}
