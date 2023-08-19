using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDesactiveObject : MonoBehaviour
{
    [SerializeField] private GameObject gameObject;
    [SerializeField] private GameObject gameObject2;
    [SerializeField] private GameObject avatar;

    public void ActiveObj()
    {
        gameObject.SetActive(true);
        gameObject2.SetActive(false);
        avatar.SetActive(false);
    }
   
}
