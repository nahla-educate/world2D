using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePanels : MonoBehaviour
{
    [SerializeField] public GameObject hairPanel;
    [SerializeField] private GameObject clothesPanel;
    [SerializeField] private GameObject facePanel;
    [SerializeField] private GameObject skinPanel;

    [SerializeField] private GameObject mouthPanel;
    [SerializeField] private GameObject eyesPanel;
    [SerializeField] private GameObject eyebrowsPanel;

    [SerializeField] private GameObject hairStylePanel;
    [SerializeField] private GameObject hairColorPanel;

    [SerializeField] private GameObject pantsPanel;
    [SerializeField] private GameObject shoesPanel;
    [SerializeField] private GameObject shirtPanel;

    [SerializeField] private GameObject findRooms;
    [SerializeField] private GameObject createPublicRoom;
    [SerializeField] private GameObject createPrivateRoom;
    [SerializeField] private GameObject chat;


    public void ActiveHair()
    {
        hairPanel.SetActive(true);
        clothesPanel.SetActive(false);
        facePanel.SetActive(false);
        skinPanel.SetActive(false);
    }

    public void ActiveClothes()
    {
        hairPanel.SetActive(false);
        clothesPanel.SetActive(true);
        facePanel.SetActive(false);
        skinPanel.SetActive(false);
    }

    public void ActiveFace()
    {
        hairPanel.SetActive(false);
        clothesPanel.SetActive(false);
        facePanel.SetActive(true);
        skinPanel.SetActive(false);
    }

    public void ActiveSkin()
    {
        hairPanel.SetActive(false);
        clothesPanel.SetActive(false);
        facePanel.SetActive(false);
        skinPanel.SetActive(true);
    }
    //face
    
    public void ActiveEyes()
    {
        mouthPanel.SetActive(false);
        eyesPanel.SetActive(true);
        eyebrowsPanel.SetActive(false);
    }

    public void ActiveMouth()
    {
        mouthPanel.SetActive(true);
        eyesPanel.SetActive(false);
        eyebrowsPanel.SetActive(false);
    }

    public void ActiveEyebrows()
    {
        mouthPanel.SetActive(false);
        eyesPanel.SetActive(false);
        eyebrowsPanel.SetActive(true);
    }
    //clothes
    public void ActiveShoes()
    {
        pantsPanel.SetActive(false);
        shoesPanel.SetActive(true);
        shirtPanel.SetActive(false);
    }

    public void ActivePants()
    {
        pantsPanel.SetActive(true);
        shoesPanel.SetActive(false);
        shirtPanel.SetActive(false);
    }

    public void ActiveShirt()
    {
        pantsPanel.SetActive(false);
        shoesPanel.SetActive(false);
        shirtPanel.SetActive(true);
    }
    //hair
    public void ActiveColorHair()
    {
        hairStylePanel.SetActive(false);
        hairColorPanel.SetActive(true);
    }

    public void ActiveStyleHair()
    {
        hairStylePanel.SetActive(true);
        hairColorPanel.SetActive(false);
    }

    //rooms
    public void DisactiveFind()
    {
        findRooms.SetActive(false);
    }

    public void DisactiveCreatePub()
    {
        createPublicRoom.SetActive(false);
        chat.SetActive(true);

    }
    public void DisactiveCreateP()
    {
        createPrivateRoom.SetActive(false);
        chat.SetActive(true);
    }

}
