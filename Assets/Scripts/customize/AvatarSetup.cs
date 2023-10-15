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

    [HideInInspector] public int skinCount;
    [SerializeField] GameObject[] fSkin;

    [HideInInspector] public int pantsCount;
    [SerializeField] GameObject[] fPants;

    [HideInInspector] public int shirtCount;
    [SerializeField] GameObject[] fShirt;

    [HideInInspector] public int handLCount;
    [SerializeField] GameObject[] fHandL;

    [HideInInspector] public int handRCount;
    [SerializeField] GameObject[] fHandR;


    // Start is called before the first frame update
    void Start()
    {
        mouthCount = fMouth.Length;
        eyesCount = fEyes.Length;
        hairCount = fHairs.Length;
        skinCount = fSkin.Length;
        pantsCount = fPants.Length;
        shirtCount = fShirt.Length;

        handRCount = fHandR.Length;
        handLCount = fHandL.Length;
        SetAvatarHair(PlayerData.instance.data);


    }

    public void SetAvatarHair(Data avatarData)
    {
        TurnOffAvatar();
        // Debug.Log(avatarData.hair);
        // genders[avatarData.gender].SetActive(true);

        fHairs[avatarData.hair].SetActive(true);
        fEyes[avatarData.eyes].SetActive(true);
        fMouth[avatarData.mouth].SetActive(true);
        fSkin[avatarData.skin].SetActive(true);
        fPants[avatarData.pants].SetActive(true);
        fShirt[avatarData.shirt].SetActive(true);

        // Set hair color
        foreach (SpriteRenderer hairRenderer in fHairs[avatarData.hair].GetComponentsInChildren<SpriteRenderer>())
        {
            // Debug.Log(avatarData.hairColor);
            hairRenderer.color = avatarData.hairColor;
        }
        
    }
    public void SetAvatarEyes(Data avatarData)
    {
        TurnOffAvatar();
        // Debug.Log(avatarData.hair);
        // genders[avatarData.gender].SetActive(true);

        fHairs[avatarData.hair].SetActive(true);
        fEyes[avatarData.eyes].SetActive(true);
        fMouth[avatarData.mouth].SetActive(true);
        fSkin[avatarData.skin].SetActive(true);
        fPants[avatarData.pants].SetActive(true);
        fShirt[avatarData.shirt].SetActive(true);

        // Set eyes color
        foreach (SpriteRenderer eyesRenderer in fEyes[avatarData.eyes].GetComponentsInChildren<SpriteRenderer>())
        {
            eyesRenderer.color = avatarData.eyesColor;
        }

    }
    public void SetAvatarMouth(Data avatarData)
    {
        TurnOffAvatar();
        // Debug.Log(avatarData.hair);
        // genders[avatarData.gender].SetActive(true);

        fHairs[avatarData.hair].SetActive(true);
        fEyes[avatarData.eyes].SetActive(true);
        fMouth[avatarData.mouth].SetActive(true);
        fSkin[avatarData.skin].SetActive(true);
        fPants[avatarData.pants].SetActive(true);
        fShirt[avatarData.shirt].SetActive(true);

        fHandL[avatarData.handL].SetActive(true);
        fHandR[avatarData.handR].SetActive(true);

        // Set mouth color
        foreach (SpriteRenderer mouthRenderer in fMouth[avatarData.mouth].GetComponentsInChildren<SpriteRenderer>())
        {
            mouthRenderer.color = avatarData.lipsColor;
        }

    }
    public void SetAvatarSkin(Data avatarData)
    {
        TurnOffAvatar();
        // Debug.Log(avatarData.hair);
        // genders[avatarData.gender].SetActive(true);

        fHairs[avatarData.hair].SetActive(true);
        fEyes[avatarData.eyes].SetActive(true);
        fMouth[avatarData.mouth].SetActive(true);
        fSkin[avatarData.skin].SetActive(true);
        fPants[avatarData.pants].SetActive(true);
        fShirt[avatarData.shirt].SetActive(true);

        fHandL[avatarData.handL].SetActive(true);
        fHandR[avatarData.handR].SetActive(true);

        // Set skin color
        foreach (SpriteRenderer skinRenderer in fSkin[avatarData.skin].GetComponentsInChildren<SpriteRenderer>())
        {
            skinRenderer.color = avatarData.skinColor;
        }

        // Set handL color
        foreach (SpriteRenderer handlRenderer in fHandL[avatarData.handL].GetComponentsInChildren<SpriteRenderer>())
        {
            handlRenderer.color = avatarData.handLColor;
        }

        // Set handR color
        foreach (SpriteRenderer handRRenderer in fHandR[avatarData.handR].GetComponentsInChildren<SpriteRenderer>())
        {
            handRRenderer.color = avatarData.handRColor;
        }

    }
    public void SetAvatarPants(Data avatarData)
    {
        TurnOffAvatar();
        // Debug.Log(avatarData.hair);
        // genders[avatarData.gender].SetActive(true);

        fHairs[avatarData.hair].SetActive(true);
        fEyes[avatarData.eyes].SetActive(true);
        fMouth[avatarData.mouth].SetActive(true);
        fSkin[avatarData.skin].SetActive(true);
        fPants[avatarData.pants].SetActive(true);
        fShirt[avatarData.shirt].SetActive(true);

        // Set pants color
        foreach (SpriteRenderer pantsRenderer in fPants[avatarData.pants].GetComponentsInChildren<SpriteRenderer>())
        {
            pantsRenderer.color = avatarData.pantsColor;
        }

    }
    public void SetAvatarShirt(Data avatarData)
    {
        TurnOffAvatar();
        // Debug.Log(avatarData.hair);
        // genders[avatarData.gender].SetActive(true);

        fHairs[avatarData.hair].SetActive(true);
        fEyes[avatarData.eyes].SetActive(true);
        fMouth[avatarData.mouth].SetActive(true);
        fSkin[avatarData.skin].SetActive(true);
        fPants[avatarData.pants].SetActive(true);
        fShirt[avatarData.shirt].SetActive(true);

        // Set shirt color
        foreach (SpriteRenderer shirtRenderer in fShirt[avatarData.shirt].GetComponentsInChildren<SpriteRenderer>())
        {
            shirtRenderer.color = avatarData.shirtColor;
        }

    }
    public void SetAvatar(Data avatarData)
    {
        TurnOffAvatar();
     // Debug.Log(avatarData.hair);
       // genders[avatarData.gender].SetActive(true);
   
        fHairs[avatarData.hair].SetActive(true);
        fEyes[avatarData.eyes].SetActive(true);
        fMouth[avatarData.mouth].SetActive(true);
        fSkin[avatarData.skin].SetActive(true);
        fPants[avatarData.pants].SetActive(true);
        fShirt[avatarData.shirt].SetActive(true);

        // Set hair color
        foreach (SpriteRenderer hairRenderer in fHairs[avatarData.hair].GetComponentsInChildren<SpriteRenderer>())
        {
           // Debug.Log(avatarData.hairColor);
            hairRenderer.color = avatarData.hairColor;
        }

        // Set eyes color
        foreach (SpriteRenderer eyesRenderer in fEyes[avatarData.eyes].GetComponentsInChildren<SpriteRenderer>())
        {
            eyesRenderer.color = avatarData.eyesColor;
        }

        // Set mouth color
        foreach (SpriteRenderer mouthRenderer in fMouth[avatarData.mouth].GetComponentsInChildren<SpriteRenderer>())
        {
            mouthRenderer.color = avatarData.lipsColor;
        }
        // Set skin color
        foreach (SpriteRenderer skinRenderer in fSkin[avatarData.skin].GetComponentsInChildren<SpriteRenderer>())
        {
            skinRenderer.color = avatarData.skinColor;
        }
        // Set pants color
        foreach (SpriteRenderer pantsRenderer in fPants[avatarData.pants].GetComponentsInChildren<SpriteRenderer>())
        {
            pantsRenderer.color = avatarData.pantsColor;
        }
        // Set shirt color
        foreach (SpriteRenderer shirtRenderer in fShirt[avatarData.shirt].GetComponentsInChildren<SpriteRenderer>())
        {
            shirtRenderer.color = avatarData.shirtColor;
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

        foreach (var skin in fSkin)
        {
            skin.SetActive(false);
        }

        foreach (var pants in fPants)
        {
            pants.SetActive(false);
        }

        foreach (var shirt in fShirt)
        {
            shirt.SetActive(false);
        }


        foreach (var handR in fHandR)
        {
            handR.SetActive(false);
        }

        foreach (var handL in fHandL)
        {
            handL.SetActive(false);
        }



    }



}
