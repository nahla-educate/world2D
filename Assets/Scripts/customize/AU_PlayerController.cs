using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class AU_PlayerController : MonoBehaviour
{
    PhotonView myPV;
    public static AU_PlayerController localPlayer;
    [SerializeField] AvatarSetup avatar;
    [SerializeField] Data myData;
    public Animator myAnim;
    public bool isKeyboardInputEnabled = true;



    //components
    //Rigidbody myRB;
    [SerializeField] Transform myAvatar;
    //Player mouvement
    Vector2 movementInput;
    // [SerializeField] InputAction WASD;
    [SerializeField] float movementSpeed;

    private Rigidbody avatarRb;
    private Vector3 initialPosition;




    /*
     private void OnEnable()
      {
          WASD.Enable();
      }

      private void OnDisable()
      {
          WASD.Disable();
      }*/

    // Implement the IPunObservable interface
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (!PhotonNetwork.IsConnected) // Check if not connected
            return;

        if (stream.IsWriting)
        {
            // Send data over the network (write variables to the stream)
            stream.SendNext(JsonUtility.ToJson(myData)); // Convert myData to a JSON string and send it
        }
        else
        {
            // Receive data from the network (read variables from the stream)
            string receivedData = (string)stream.ReceiveNext(); // Receive the JSON string
            myData = JsonUtility.FromJson<Data>(receivedData); // Convert the JSON string back to myData object
            avatar.SetAvatar(myData); // Update the avatar appearance with the received data
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        myPV = GetComponent<PhotonView>();
        //  myRB = GetComponent<Rigidbody>();


        if (myPV == null)
        {
            Debug.LogError("PhotonView not found on the GameObject!");
            return;
        }

        if (myPV.IsMine)
        {
            myAvatar = transform.GetChild(0);
            avatarRb = GetComponent<Rigidbody>();
            initialPosition = transform.position;

            localPlayer = this;
            if (PhotonNetwork.IsConnected) // Check if connected before synchronizing
            {
                avatar.SetAvatar(PlayerData.instance.data);
                SyncAvatar(PlayerData.instance);
            }
        }
        
    }

    



    public void MoveLeft()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("walkin a");
            myAnim.SetBool("IsWalkingLeft", true); // Adjust the horizontal speed as needed
            avatarRb.velocity = new Vector3(-5f, avatarRb.velocity.y, avatarRb.velocity.z);
            
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
            myAnim.SetBool("IsWalkingRight", true);
            avatarRb.velocity = new Vector3(5f, avatarRb.velocity.y, avatarRb.velocity.z); // Adjust the horizontal speed as needed
        }
        else
        {
            myAnim.SetBool("IsWalkingRight", false);
            avatarRb.velocity = new Vector3(0f, avatarRb.velocity.y, avatarRb.velocity.z);
        }


    }

    public void MoveUp()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Z))
        {
            myAnim.SetBool("IsWalkingLeft", true);
            avatarRb.velocity = new Vector3(avatarRb.velocity.x, 5f, avatarRb.velocity.z); // Adjust the vertical speed as needed
          
            
        }
        else
        {
            myAnim.SetBool("IsWalkingLeft", false);
            avatarRb.velocity = new Vector3(avatarRb.velocity.x, 0f, avatarRb.velocity.z);
        }

    }

    public void MoveDown()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            myAnim.SetBool("IsWalkingLeft", true);
            avatarRb.velocity = new Vector3(avatarRb.velocity.x, -5f, avatarRb.velocity.z); // Adjust the vertical speed as needed
        }
        else
        {
            myAnim.SetBool("IsWalkingLeft", false);
            avatarRb.velocity = new Vector3(avatarRb.velocity.x, 0f, avatarRb.velocity.z);

        }
    }
    




    void Update()
    {
        if (!myPV.IsMine)
            return;
        if (isKeyboardInputEnabled == true)
        {
            // Process input only when keyboard input is enabled
            movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Z))
            {
                myAnim.SetBool("IsWalkingLeft", true);
                avatarRb.velocity = new Vector3(avatarRb.velocity.x, 5f, avatarRb.velocity.z); // Adjust the vertical speed as needed


            }
            else
            {
                myAnim.SetBool("IsWalkingLeft", false);
                avatarRb.velocity = new Vector3(avatarRb.velocity.x, 0f, avatarRb.velocity.z);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                myAnim.SetBool("IsWalkingRight", true);
                avatarRb.velocity = new Vector3(5f, avatarRb.velocity.y, avatarRb.velocity.z); // Adjust the horizontal speed as needed
            }
            else
            {
                myAnim.SetBool("IsWalkingRight", false);
                avatarRb.velocity = new Vector3(0f, avatarRb.velocity.y, avatarRb.velocity.z);
            }
            //down
            if (Input.GetKeyDown(KeyCode.S))
            {
                myAnim.SetBool("IsWalkingLeft", true);
                avatarRb.velocity = new Vector3(avatarRb.velocity.x, -5f, avatarRb.velocity.z); // Adjust the vertical speed as needed
            }
            else
            {
                myAnim.SetBool("IsWalkingLeft", false);
                avatarRb.velocity = new Vector3(avatarRb.velocity.x, 0f, avatarRb.velocity.z);

            }

            //left
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("walkin a");
                myAnim.SetBool("IsWalkingLeft", true); // Adjust the horizontal speed as needed
                avatarRb.velocity = new Vector3(-5f, avatarRb.velocity.y, avatarRb.velocity.z);

            }
            else
            {

                avatarRb.velocity = new Vector3(0f, avatarRb.velocity.y, avatarRb.velocity.z);
            }
        }

        //  myAnim.SetFloat("Speed", movementInput.magnitude);

        /*
          if (movementInput.x != 0)
          {

               movementInput = WASD.ReadValue<Vector2>();
              myAvatar.localScale = new Vector2(-Mathf.Sign(movementInput.x), 1);
              //Debug.Log("mouvex" + movementInput);
              //Debug.Log("mouvelo" + myAvatar.localScale);
          }
          myAnim.SetFloat("Speed", movementInput.magnitude);*/
    }

   /* private void FixedUpdate()
    {
         if (!myPV.IsMine)
             return;
         //myRB.velocity = movementInput * movementSpeed;
          Vector3 newPosition = myAvatar.position + new Vector3(movementInput.x, movementInput.y, 0f);
          myRB.MovePosition(newPosition);
          Debug.Log("new position" + newPosition);      


    }*/

    // Synchronize the avatar appearance data over the network
    public void SyncAvatar(PlayerData data)
    {
        if (PhotonNetwork.IsConnected) // Check if connected before synchronizing
        {
            string syncString = data.AvatarToString();
            myPV.RPC("RPC_SyncAvatar", RpcTarget.OthersBuffered, syncString);
        }
    }

    // RPC method to receive and apply synchronized avatar appearance data
    [PunRPC]
    void RPC_SyncAvatar(string data)
    {
        myData = JsonUtility.FromJson<Data>(data);
        avatar.SetAvatar(myData);
    }
}
