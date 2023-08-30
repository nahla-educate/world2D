using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public Data data;


    public void OnEnable()
    {
        data = new Data();
        PlayerData.instance = this;
        DontDestroyOnLoad(gameObject);

    }


    public string AvatarToString()
    {
        string returnString = JsonUtility.ToJson(PlayerData.instance.data);
        return returnString;
    }
}
public class Data
{
    public int myNumberInRoom;

    public int gender;

    public Color skinColor;

    public int hair;
    public Color hairColor;

    public int eyes;
    public int mouth;


    public Color shirtColor;
    //  public int pants;
    //  public Color pantsColor;
    // public int shoes;
    // public Color shoesColor;


}

