using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AU_Game_Controller : MonoBehaviour
{
    public static AU_Game_Controller instance;
    public Transform[] spawnPoints;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    
}
