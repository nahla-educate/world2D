using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{
    [SerializeField] GameObject[] genders;

    [HideInInspector] public int eyesCount;
    [SerializeField] GameObject[] fEyes;

    [HideInInspector] public int hairCount;
    [SerializeField] GameObject[] fHairs;

    [HideInInspector] public int mouthCount;
    [SerializeField] GameObject[] fMouth;


    // Start is called before the first frame update
    void Start()
    {
        mouthCount = fMouth.Length;
        eyesCount = fEyes.Length;
        hairCount = fHairs.Length;
    }

    public void SetAvatar(Data avatarData)
    {
        TurnOffAvatar();
     // Debug.Log(avatarData.hair);
       // genders[avatarData.gender].SetActive(true);
   
        fHairs[avatarData.hair].SetActive(true);
        fEyes[avatarData.eyes].SetActive(true);
        fMouth[avatarData.mouth].SetActive(true);

        // Set hair color
        foreach (SpriteRenderer hairRenderer in fHairs[avatarData.hair].GetComponentsInChildren<SpriteRenderer>())
        {
           // Debug.Log(avatarData.hairColor);
            hairRenderer.color = avatarData.hairColor;
        }


        /* foreach (SpriteRenderer s in skinColor)
         {
             Debug.Log(avatarData.skinColor);
             s.color = avatarData.skinColor;
         }

         foreach (SpriteRenderer s in hairColor)
         {
             Debug.Log(avatarData.hairColor);
             s.color = avatarData.hairColor;
         }

         foreach (SpriteRenderer s in shirtColor)
         {
             Debug.Log(avatarData.shirtColor);
             s.color = avatarData.shirtColor;
         }*/
    }
    private void TurnOffAvatar()
    {
        // Deactivate all avatar components here
        foreach (var gender in genders)
        {
            gender.SetActive(false);
        }

        foreach (var hair in fHairs)
        {
            hair.SetActive(false);
        }

        foreach (var eyes in fEyes)
        {
            eyes.SetActive(false);
        }

        foreach (var mouth in fMouth)
        {
            mouth.SetActive(false);
        }



    }



}
