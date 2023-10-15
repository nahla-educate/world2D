using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource src;
    public AudioClip loginSound, errorSound, warnSound, clickSound;

    public void LoginBtn()
    {
        src.clip = loginSound;
        src.Play();
    }
    public void ErrorBtn()
    {
        src.clip = errorSound;
        src.Play();
    }
    public void WarnBtn()
    {
        src.clip = warnSound;
        src.Play();
    }
    public void ClickBtn()
    {
        src.clip = clickSound;
        src.Play();
    }
}
