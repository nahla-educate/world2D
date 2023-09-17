using System;

using UnityEngine;

public class UIAddFriend : MonoBehaviour
{
    [SerializeField] private string displayName;
    public static Action<string> OnAddFriend = delegate { };

    // Start is called before the first frame update
    public void SetAddFriendName(string name)
    {
        displayName = name;
    }

    // Update is called once per frame
    public void AddFriend()
    {        
        if (string.IsNullOrEmpty(displayName)) return;
        Debug.Log("see");
        OnAddFriend?.Invoke(displayName); 
        Debug.Log("yes");
    }
}
