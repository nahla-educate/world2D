using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterCustumizer : MonoBehaviour
{
    //[SerializeField] Transform[] cameraPosition; // Define the array

   // [SerializeField] GameObject mainMenu;
   // [SerializeField] GameObject avatarMenu;
    //[SerializeField] GameObject monsterMenu;

    [SerializeField] AvatarSetup avatar;
   // [SerializeField] AvatarSetup avatar2;


    [SerializeField] Color[] defaultColors;

    [SerializeField] Image hairButton;

    //[SerializeField] Image shirtButton;
    // [SerializeField] Image pantsButton;
    // [SerializeField] Image shoesButton;

    // [SerializeField] Image skinButton;
    //  [SerializeField] Image eyeButton;


/*

    public void OpenMainMenu()
    {
        mainMenu.SetActive(true);
        avatarMenu.SetActive(false);
        Camera.main.transform.position = cameraPosition[0].position;
    }

    public void OpenAvatarCustomizer()
    {
        mainMenu.SetActive(false);
        avatarMenu.SetActive(true);
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
    public void ChangeHair(int param)
    {
        PlayerData.instance.data.hair += param;
        Debug.Log(PlayerData.instance.data.hair);
        Debug.Log(avatar.hairCount);
        if (PlayerData.instance.data.hair >= avatar.hairCount)
        {
            PlayerData.instance.data.hair = 0;
        }
        if (PlayerData.instance.data.hair <= 0)
        {
            PlayerData.instance.data.hair = avatar.hairCount -1;
        }
        else
        {
            PlayerData.instance.data.hair = avatar.hairCount - 2;
        }
        PlayerPrefs.SetInt("Hair", PlayerData.instance.data.hair);
        avatar.SetAvatar(PlayerData.instance.data);
    }
    public void ChangeShirt(int param)
    {
        PlayerData.instance.data.shirt += param;
        if (PlayerData.instance.data.shirt >= avatar.shirtCount)
        {
            PlayerData.instance.data.shirt = 0;
        }
        if (PlayerData.instance.data.shirt < 0)
        {
            PlayerData.instance.data.shirt = avatar.shirtCount - 1;
        }
        PlayerPrefs.SetInt("Shirt", PlayerData.instance.data.shirt);
        avatar.SetAvatar(PlayerData.instance.data);
    }
}

