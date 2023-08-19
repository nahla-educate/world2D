using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarSetup : MonoBehaviour
{
    [SerializeField] GameObject[] genders;

    [HideInInspector] public int shirtCount;
    [SerializeField] GameObject[] fshirts;

    [HideInInspector] public int hairCount;
    [SerializeField] GameObject[] fHairs;
    //[SerializeField] GameObject[] fShoes;
    //[SerializeField] GameObject[] mShoes;

    [SerializeField] SpriteRenderer[] skinColor;
    [SerializeField] SpriteRenderer[] hairColor;
    [SerializeField] SpriteRenderer[] shirtColor;


    // Start is called before the first frame update
    void Start()
    {
        shirtCount = fshirts.Length;
        hairCount = fHairs.Length;
    }

    public void SetAvatar(Data avatarData)
    {
        TurnOffAvatar();
       Debug.Log(avatarData.hair);
       // genders[avatarData.gender].SetActive(true);

       // fshirts[avatarData.shirt].SetActive(true);

        
        fHairs[avatarData.hair].SetActive(true);

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

        foreach (var shirt in fshirts)
        {
            shirt.SetActive(false);
        }



        foreach (var hair in fHairs)
        {
            hair.SetActive(false);
        }



        // ... deactivate other components ...
    }



}
