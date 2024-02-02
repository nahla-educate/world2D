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
    private int selectedSkinColorIndex = 0;
    private int selectedShirtColorIndex = 0;
    private int selectedEyesColorIndex = 0;
    private int selectedMouthColorIndex = 0;
    private int selectedPantsColorIndex = 0;

    private int selectedHandLColorIndex = 0;
    private int selectedHandRColorIndex = 0;


    [SerializeField] Color[] hairColors;
    [SerializeField] Color[] eyesColors;
    [SerializeField] Color[] lipsColors;
    [SerializeField] Color[] skinColors;
    [SerializeField] Color[] pantsColors;
    [SerializeField] Color[] shirtColors;

    [SerializeField] Color[] handLColors;
    [SerializeField] Color[] handRColors;


    [SerializeField] Image hairButton;
    void Start()
    {
        PlayerData.instance.data.hair = 1;
        PlayerData.instance.data.hairColor = hairColors[2]; // You can change the index to your desired default color.
        PlayerData.instance.data.lipsColor = lipsColors[2];
        PlayerData.instance.data.eyesColor = eyesColors[2];
        PlayerData.instance.data.skinColor = skinColors[11];
        PlayerData.instance.data.handLColor = handLColors[2];
        PlayerData.instance.data.handRColor = handRColors[2];
        PlayerData.instance.data.pantsColor = pantsColors[2];
        PlayerData.instance.data.shirtColor = shirtColors[2];

        PlayerData.instance.data.skin = 0;
        PlayerData.instance.data.mouth = 1;

        PlayerData.instance.data.eyes = 1;
        PlayerData.instance.data.pants = 0;
        PlayerData.instance.data.shirt = 0;


        PlayerData.instance.data.handR = 0;
        PlayerData.instance.data.handL = 0;

        avatar.SetAvatar(PlayerData.instance.data);

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
        PlayerData.instance.data.hairColor = hairColors[2]; // Set default color for the selected style
        Debug.Log("hair: " + PlayerData.instance.data.hair);
        Debug.Log("hairCount: " + avatar.hairCount);

        PlayerPrefs.SetInt("Hair", PlayerData.instance.data.hair);
        avatar.SetAvatarHair(PlayerData.instance.data);
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
        avatar.SetAvatarHair(PlayerData.instance.data);
    }
    public void ChangeLipsColor(int colorIndex)
    {
        PlayerData.instance.data.lipsColor = lipsColors[colorIndex];
        avatar.SetAvatarMouth(PlayerData.instance.data);
    }
    public void ChangeEyesColor(int colorIndex)
    {
        PlayerData.instance.data.eyesColor = eyesColors[colorIndex];
        avatar.SetAvatarEyes(PlayerData.instance.data);
    }
    public void ChangeSkinColor(int colorIndex)
    {
        PlayerData.instance.data.skinColor = skinColors[colorIndex];
        PlayerData.instance.data.handLColor = handLColors[colorIndex];
        PlayerData.instance.data.handRColor = handRColors[colorIndex];

        avatar.SetAvatarSkin(PlayerData.instance.data);
    }
    public void ChangePantsColor(int colorIndex)
    {
        PlayerData.instance.data.pantsColor = pantsColors[colorIndex];
        avatar.SetAvatarPants(PlayerData.instance.data);
    }
    public void ChangeShirtColor(int colorIndex)
    {
        Debug.Log(colorIndex);
        Debug.Log(PlayerData.instance.data.shirtColor);
        PlayerData.instance.data.shirtColor = shirtColors[colorIndex];
        avatar.SetAvatarShirt(PlayerData.instance.data);
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

