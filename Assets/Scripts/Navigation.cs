using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;

public class Navigation : MonoBehaviour
{
    public GameObject panelMenu;

    public void ActiveMenuBtn()
    {
        panelMenu.SetActive(true);
    }
    public void DisactiveMenuBtn()
    {
        panelMenu.SetActive(false);
    }

    public void MenuR()
    {
        SceneController.LoadScene("MainMenu 1");
    }

    public void Play()
    {
        SceneController.LoadScene("MainMenu");
    }

    public void Customize()
    {
        SceneController.LoadScene("Customize");

    }

    public void DisconnectBtn()
    {
        StartCoroutine(DisconnectAndLoad());
    }

    IEnumerator DisconnectAndLoad()
    {
        PhotonNetwork.Disconnect();
        while (PhotonNetwork.IsConnected)
            yield return null;
        SceneManager.LoadScene("SampleScene");
    }
}
