using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersFriends : MonoBehaviour
{
    [SerializeField] private GameObject friends;
    [SerializeField] private GameObject players;
    [SerializeField] private GameObject list;

    public void ActiveFriends()
    {
        friends.SetActive(true);
        players.SetActive(false);
    }

    public void ActivePlayers()
    {
        friends.SetActive(false);
        players.SetActive(true);
    }

    public void DesactiveList()
    {
        list.SetActive(false);

    }
    public void ActiveList()
    {
        list.SetActive(true);
    }
}
