using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingInputSystem : MonoBehaviour
{
    private Rigidbody avatarRb;
    private Vector3 initialPosition;
  


    private void Awake()
    {
        avatarRb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
    }


    public void MoveLeft()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            avatarRb.velocity = new Vector3(-2f, avatarRb.velocity.y, avatarRb.velocity.z); // Adjust the horizontal speed as needed
        }
        else
        {
            avatarRb.velocity = new Vector3(0f, avatarRb.velocity.y, avatarRb.velocity.z);
        }
        
    }

       
    public void MoveRight()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {          
            avatarRb.velocity = new Vector3(2f, avatarRb.velocity.y, avatarRb.velocity.z); // Adjust the horizontal speed as needed
        }
        else
        {
            avatarRb.velocity = new Vector3(0f, avatarRb.velocity.y, avatarRb.velocity.z);
        }

        
    }

    public void MoveUp()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            avatarRb.velocity = new Vector3(avatarRb.velocity.x, 2f, avatarRb.velocity.z); // Adjust the vertical speed as needed
        }
        else
        {
            avatarRb.velocity = new Vector3(avatarRb.velocity.x, 0f, avatarRb.velocity.z); 
        }
        
    }

    public void MoveDown()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            avatarRb.velocity = new Vector3(avatarRb.velocity.x, -2f, avatarRb.velocity.z); // Adjust the vertical speed as needed
        }
        else
        {
            avatarRb.velocity = new Vector3(avatarRb.velocity.x, 0f, avatarRb.velocity.z);

        }
    }

    
}


