using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustumizer : MonoBehaviour
{
    //[SerializeField] Transform[] cameraPosition; // Define the array

   
    [SerializeField] AvatarSetup avatar;
    // [SerializeField] AvatarSetup avatar2;

    private int selectedHairColorIndex = 0;


    [SerializeField] Color[] hairColors;


    [SerializeField] Image hairButton;
    void start()
    {
        PlayerData.instance.data.hair = 0;
    }

    //[SerializeField] Image shirtButton;
    // [SerializeField] Image pantsButton;
    // [SerializeField] Image shoesButton;

    // [SerializeField] Image skinButton;
    //  [SerializeField] Image eyeButton;


/*

    public void OpenMainMenu()
    {
        Camera.main.transform.position = cameraPosition[0].position;
    }

    public void OpenAvatarCustomizer()
    {
        Camera.main.transform.position = cameraPosition[1].position;
    }*/
    public void ChangeGender()
    {
        if (PlayerData.instance.data.gender == 0)
        {
            PlayerData.instance.data.gender = 1;
        }
        else
        {
            PlayerData.instance.data.gender = 0;

        }
        PlayerPrefs.SetInt("Gender", PlayerData.instance.data.gender);
        avatar.SetAvatar(PlayerData.instance.data);
    }
    public void ChangeH(int param)
    {
        PlayerData.instance.data.hair = param;
        PlayerData.instance.data.hairColor = hairColors[param]; // Set default color for the selected style
        Debug.Log("hair: " + PlayerData.instance.data.hair);
        Debug.Log("hairCount: " + avatar.hairCount);

        PlayerPrefs.SetInt("Hair", PlayerData.instance.data.hair);
        avatar.SetAvatar(PlayerData.instance.data);
    }

    public void ChangeMouth(int param)
    {
        PlayerData.instance.data.mouth = param;
        Debug.Log("mouth: " + PlayerData.instance.data.mouth);
        Debug.Log("mouthCount: " + avatar.mouthCount);

        PlayerPrefs.SetInt("Mouth", PlayerData.instance.data.mouth);
        avatar.SetAvatar(PlayerData.instance.data);
    }

    public void ChangeEyes(int param)
    {
        PlayerData.instance.data.eyes = param;
        Debug.Log("eyes: " + PlayerData.instance.data.eyes);
        Debug.Log("eyesCount: " + avatar.eyesCount);

        PlayerPrefs.SetInt("Eyes", PlayerData.instance.data.eyes);
        avatar.SetAvatar(PlayerData.instance.data);
    }
    public void ChangeHairColor(int colorIndex)
    {
        PlayerData.instance.data.hairColor = hairColors[colorIndex];
        avatar.SetAvatar(PlayerData.instance.data);
    }



    /*public void ChangeHair(int param)
    {
        PlayerData.instance.data.hair++; // Increment the hair style
        Debug.Log("hair: " + PlayerData.instance.data.hair);

        if (PlayerData.instance.data.hair >= avatar.hairCount)
        {
            PlayerData.instance.data.hair = 0; // Loop back to the first style
        }

        PlayerPrefs.SetInt("Hair", PlayerData.instance.data.hair);
        avatar.SetAvatar(PlayerData.instance.data);
    }*/


}

