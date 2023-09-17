using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDesactiveObject : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private GameObject gameObject2;
    [SerializeField] private GameObject avatar;
    [SerializeField] private GameObject custom;

    public void ActiveObj()
    {
        gameObject.SetActive(true);
        gameObject2.SetActive(false);
        avatar.SetActive(false);
    }

    public void ActObj()
    {
        gameObject.SetActive(true);
        custom.SetActive(false);
    }

}
