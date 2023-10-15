using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects2 : MonoBehaviour
{
    public AudioSource src;
    public AudioClip loginSound, errorSound, warnSound, clickSound, switchColorS;

    public void LoginBtn()
    {
        src.clip = loginSound;
        src.Play();
    }
    public void SwitchColorBtn()
    {
        src.clip = switchColorS;
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
