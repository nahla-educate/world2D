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

    // Add the SetAppearance method that accepts a JSON string.
    public void SetAppearance(string jsonSerializedData)
    {
        // Deserialize the JSON string into the Data object.
        data = JsonUtility.FromJson<Data>(jsonSerializedData);
        Debug.Log(jsonSerializedData);
    }
}
public class Data
{
    public int myNumberInRoom;

    public int gender;

    public Color skinColor;    
    public Color lipsColor;
    public Color eyesColor;
    public Color hairColor;
    public Color pantsColor;
    public Color shirtColor;

    public Color handLColor;
    public Color handRColor;


    public int skin;
    public int mouth;
    public int eyes;
    public int hair;
    public int pants;
    public int shirt;

    public int handL;
    public int handR;

    //  public int pants;
    //  public Color pantsColor;
    // public int shoes;
    // public Color shoesColor;


}

