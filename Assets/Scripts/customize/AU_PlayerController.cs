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
    private Vector3 networkedPosition;

    [SerializeField] AvatarSetup avatar;
    [SerializeField] Data myData;
    public Animator myAnim;
    public bool isKeyboardInputEnabled = true;
<<<<<<< HEAD
    [SerializeField] public GameObject avatarToResize;
    [SerializeField] public float scaleFactor = 1.5f;
    [SerializeField] public GameObject roomOne;
    [SerializeField] public GameObject roomTwo;
    [SerializeField] public GameObject roomThree;
    [SerializeField] public GameObject roomFour;
    [SerializeField] public GameObject roomFive;
    [SerializeField] public GameObject roomSix;
    [SerializeField] public GameObject roomSeven;
    [SerializeField] public GameObject roomEight;
    [SerializeField] public GameObject roomNine;
    [SerializeField] public GameObject roomTen;
    [SerializeField] public GameObject map;

    [SerializeField] public GameObject avatara;

    [SerializeField] public GameObject listBtn;
    [SerializeField] public GameObject chatPanel;

    [SerializeField] PhotonConnector goToRoom;
    private bool isWalkingLeft = false;
    private bool isWalkingRight = false;




    public void ResizeAvatar()
    {
        if (avatarToResize != null)
        {
            avatarToResize.transform.localScale *= scaleFactor;
        }
    }
 

     void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("DoorOne"))
         {
             Debug.Log("Player entered trigger zone 'DoorOne'.");
             roomOne.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);

             avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.OnConnectedRoomClicked("RoomOne");
             }

         }
         else if (other.CompareTag("DoorTwo"))
         {
             Debug.Log("Player entered trigger zone DoorTwo.");
             roomTwo.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);

             avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.OnConnectedRoomClicked("RoomTwo");
             }

         }
         else if (other.CompareTag("DoorThree"))
         {
             Debug.Log("Player entered trigger zone DoorThree.");
             map.SetActive(false);
             roomThree.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             avatara.SetActive(false);
             if (goToRoom != null)
             {
                Debug.Log("create or join");
                goToRoom.CreateOrJoinRoomOne();
             }
         }
         else if (other.CompareTag("DoorFour"))
         {
             Debug.Log("Player entered trigger zone DoorFour.");
             roomFour.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);
             

            avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.OnConnectedRoomClicked("RoomFour");
             }

         }
         else if (other.CompareTag("DoorFive"))
         {
             Debug.Log("Player entered trigger zone.");
             roomFive.SetActive(true);
             map.SetActive(false);
             chatPanel.SetActive(true);
             listBtn.SetActive(true);

             avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.OnConnectedRoomClicked("RoomFive");
             }

         }
         else if (other.CompareTag("DoorSix"))
         {
             Debug.Log("Player entered trigger zone.");
             roomSix.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);

             avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.OnConnectedRoomClicked("RoomSix");
             }

         }
         else if (other.CompareTag("DoorSeven"))
         {
             Debug.Log("Player entered trigger zone.");
             roomSeven.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);

             avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.OnConnectedRoomClicked("RoomSeven");
             }

         }
         else if (other.CompareTag("DoorEight"))
         {
             Debug.Log("Player entered trigger zone.");
             roomEight.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);

             avatara.SetActive(false);
             if (goToRoom != null)
             {
                if (!PhotonNetwork.InRoom)
                {
                    Debug.Log("room vide.");
                    // Create the room if the player is not already in a room
                    goToRoom.CreateRoom();
                    Debug.Log("room created.");
                }
                else
                {
                    Debug.Log("Player entered room");
                    goToRoom.JoinRoom();
                    Debug.Log("room joined");
                }
             }

         }
         else if (other.CompareTag("DoorNine"))
         {
             Debug.Log("Player entered trigger zone.");
             roomNine.SetActive(true);
             chatPanel.SetActive(true);
             listBtn.SetActive(true);
             map.SetActive(false);

             avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.OnConnectedRoomClicked("RoomNine");
             }

         }
         else if (other.CompareTag("DoorTen"))
         {
             Debug.Log("Player entered trigger zone.");
             roomTen.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);

             avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.OnConnectedRoomClicked("RoomTen");
             }

         }
     }
=======
>>>>>>> 5ef3753343931c5f31f96651844b05317bb63430



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

            stream.SendNext(transform.position); // Send the position data
            stream.SendNext(transform.rotation);
        }
        else
        {
            // Receive data from the network (read variables from the stream)
            string receivedData = (string)stream.ReceiveNext(); // Receive the JSON string
            myData = JsonUtility.FromJson<Data>(receivedData); // Convert the JSON string back to myData object
            avatar.SetAvatar(myData); // Update the avatar appearance with the received data

            Vector3 receivedPosition = (Vector3)stream.ReceiveNext(); // Receive the position data
            Quaternion receivedRotation = (Quaternion)stream.ReceiveNext();

            // Update the position and rotation of the player's avatar
            transform.position = receivedPosition;
            transform.rotation = receivedRotation;
        }
    }

    [PunRPC]
    private void SyncPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void UpdatePosition(Vector3 newPosition)
    {
        myPV.RPC("SyncPosition", RpcTarget.All, newPosition);
    }



    // Start is called before the first frame update
    void Start()
    {
        myPV = GetComponent<PhotonView>();
<<<<<<< HEAD
        myAnim = GetComponent<Animator>();
=======
>>>>>>> 5ef3753343931c5f31f96651844b05317bb63430
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

    
<<<<<<< HEAD
=======

>>>>>>> 5ef3753343931c5f31f96651844b05317bb63430



  /*  public void MoveLeft()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("walkin a");
            myAnim.SetBool("IsWalkingLeft", true); // Adjust the horizontal speed as needed
<<<<<<< HEAD
            avatarRb.velocity = new Vector3(-15f, avatarRb.velocity.y, avatarRb.velocity.z);
            
=======
            avatarRb.velocity = new Vector3(-5f, avatarRb.velocity.y, avatarRb.velocity.z);
            
        }
        else
        {
            
            avatarRb.velocity = new Vector3(0f, avatarRb.velocity.y, avatarRb.velocity.z);
>>>>>>> 5ef3753343931c5f31f96651844b05317bb63430
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
<<<<<<< HEAD
    }*/
=======
    }
>>>>>>> 5ef3753343931c5f31f96651844b05317bb63430
    




    void Update()
    {
<<<<<<< HEAD
        if (myPV.IsMine)
        {
            if (isKeyboardInputEnabled == true)
            {
                // Process input only when keyboard input is enabled
                movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

                // Top (Upward movement)
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z))
                {
                    myAnim.SetBool("IsWalkingLeft", true);
                    avatarRb.velocity = new Vector3(avatarRb.velocity.x, 2f, avatarRb.velocity.z); // Adjust the vertical speed as needed
                }
                else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Z))
                {
                    myAnim.SetBool("IsWalkingLeft", false);
                    avatarRb.velocity = new Vector3(avatarRb.velocity.x, 0f, avatarRb.velocity.z);
                }


                // Right (Rightward movement)
                if (Input.GetKey(KeyCode.D))
                {
                    myAnim.SetBool("IsWalkingRight", true);
                    SetWalkingRight(true);
                    avatarRb.velocity = new Vector3(2f, avatarRb.velocity.y, avatarRb.velocity.z); // Adjust the horizontal speed as needed
                }
                else if (!Input.GetKey(KeyCode.D))
                {
                    myAnim.SetBool("IsWalkingRight", false);
                    SetWalkingRight(false);
                    avatarRb.velocity = new Vector3(0f, avatarRb.velocity.y, avatarRb.velocity.z);
                }

                // Down (Downward movement)
                if (Input.GetKey(KeyCode.S))
                {
                    myAnim.SetBool("IsWalkingLeft", true);
                    avatarRb.velocity = new Vector3(avatarRb.velocity.x, -2f, avatarRb.velocity.z); // Adjust the vertical speed as needed
                }
                else if (!Input.GetKey(KeyCode.S))
                {
                    myAnim.SetBool("IsWalkingLeft", false);
                }


                // Left (Leftward movement)
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q))
                {
                    myAnim.SetBool("IsWalkingLeft", true);
                    SetWalkingLeft(true);
                    avatarRb.velocity = new Vector3(-2f, avatarRb.velocity.y, avatarRb.velocity.z); // Adjust the horizontal speed as needed
                }
                else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.Q))
                {
                    myAnim.SetBool("IsWalkingLeft", false);
                    SetWalkingLeft(false);
                }

            }
        }

        

=======
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

>>>>>>> 5ef3753343931c5f31f96651844b05317bb63430
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

    private void SetWalkingLeft(bool walking)
    {
        isWalkingLeft = walking;
        myAnim.SetBool("IsWalkingLeft", walking);

        // Synchronize the animation state over the network using an RPC
        myPV.RPC("SyncWalkingLeft", RpcTarget.Others, walking);
    }

    private void SetWalkingRight(bool walking)
    {
        isWalkingRight = walking;
        myAnim.SetBool("IsWalkingRight", walking);

        // Synchronize the animation state over the network using an RPC
        myPV.RPC("SyncWalkingRight", RpcTarget.Others, walking);
    }

    // RPC method to receive and apply synchronized walking left animation state
    [PunRPC]
    private void SyncWalkingLeft(bool walking)
    {
        myAnim.SetBool("IsWalkingLeft", walking);
    }

    // RPC method to receive and apply synchronized walking right animation state
    [PunRPC]
    private void SyncWalkingRight(bool walking)
    {
        myAnim.SetBool("IsWalkingRight", walking);
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
