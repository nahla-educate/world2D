using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AU_PlayerController : MonoBehaviour
{
    PhotonView myPV;
    public static AU_PlayerController localPlayer;
    private Vector3 networkedPosition;
    [SerializeField] private AvatarSetup avatar;
    [SerializeField] private Data myData;
    public Animator myAnim;
    public bool isKeyboardInputEnabled = false;
    public bool moveAV = false;
    //public GameObject societyObject;
    
    [SerializeField] private GameObject avatarToResize;
    [SerializeField] private float scaleFactor = 1.5f;
    [SerializeField] private GameObject roomOne;
    [SerializeField] private GameObject roomTwo;
    [SerializeField] private GameObject roomThree;
    [SerializeField] private GameObject roomFour;
    [SerializeField] private GameObject roomFive;
    [SerializeField] private GameObject roomSix;
    [SerializeField] private GameObject roomSeven;
    [SerializeField] private GameObject roomEight;
    [SerializeField] private GameObject roomNine;
    [SerializeField] private GameObject roomTen;
    [SerializeField] private GameObject map;
    [SerializeField] private GameObject panelMap;

    [SerializeField] private GameObject avatara;
    [SerializeField] private GameObject listBtn;
    [SerializeField] private GameObject chatPanel;
    [SerializeField] private PhotonConnector goToRoom;

    private bool isWalkingLeft = false;
    private bool isWalkingRight = false;

    public void ResizeAvatar()
    {
        avatarToResize.transform.localScale *= scaleFactor;
        if (avatarToResize != null)
        {
            avatarToResize.transform.localScale *= scaleFactor;
        }
    }
    /*  private void OnTriggerExit(Collider collision)
      {
          if (collision.CompareTag("Society"))
          {
              Debug.Log("Collision");
          }
      }*/
   

    void OnTriggerEnter2D(Collider2D other)
     {
        Debug.Log("Triggered by ");
        if (other.CompareTag("Society"))
        {
           // Debug.Log("Triggered by society");         
        }
         if (other.CompareTag("DoorOne"))
         {
             Debug.Log("Player entered trigger zone 'DoorOne'.");
             roomOne.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);
             panelMap.SetActive(false);

             avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.CreateOrJoinRoomOne();
             }

         }
         else if (other.CompareTag("DoorTwo"))
         {
             Debug.Log("Player entered trigger zone DoorTwo.");
             roomTwo.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);
            panelMap.SetActive(false);

            avatara.SetActive(false);
             if (goToRoom != null)
             {
                goToRoom.CreateOrJoinRoomTwo();
             }

         }
         else if (other.CompareTag("DoorThree"))
         {
           Debug.Log("Player entered trigger zone DoorThree.");
             map.SetActive(false);
            panelMap.SetActive(false);
            roomThree.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             avatara.SetActive(false);
             if (goToRoom != null)
             {
                Debug.Log("create or join");
                goToRoom.CreateOrJoinRoomThree();
             }
         }
         else if (other.CompareTag("DoorFour"))
         {
             Debug.Log("Player entered trigger zone DoorFour.");
             roomFour.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);
            panelMap.SetActive(false);

            avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.CreateOrJoinRoomFour();
             }

         }
         else if (other.CompareTag("DoorFive"))
         {
             Debug.Log("Player entered trigger zone.");
             roomFive.SetActive(true);
             map.SetActive(false);
            panelMap.SetActive(false);
            chatPanel.SetActive(true);
             listBtn.SetActive(true);

             avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.CreateOrJoinRoomFive();
             }

         }
         else if (other.CompareTag("DoorSix"))
         {
             Debug.Log("Player entered trigger zone.");
             roomSix.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);
            panelMap.SetActive(false);

            avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.CreateOrJoinRoomSix();
             }

         }
         else if (other.CompareTag("DoorSeven"))
         {
             Debug.Log("Player entered trigger zone.");
             roomSeven.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);
             panelMap.SetActive(false);

            avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.CreateOrJoinRoomSeven();
             }

         }
         else if (other.CompareTag("DoorEight"))
         {
             Debug.Log("Player entered trigger zone.");
             roomEight.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);
            panelMap.SetActive(false);

            avatara.SetActive(false);
             if (goToRoom != null)
             {
                goToRoom.CreateOrJoinRoomEight();
             }

         }
         else if (other.CompareTag("DoorNine"))
         {
             Debug.Log("Player entered trigger zone.");
             roomNine.SetActive(true);
             chatPanel.SetActive(true);
             listBtn.SetActive(true);
             map.SetActive(false);
            panelMap.SetActive(false);

            avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.CreateOrJoinRoomNine();
             }

         }
         else if (other.CompareTag("DoorTen"))
         {
             Debug.Log("Player entered trigger zone.");
             roomTen.SetActive(true);
             listBtn.SetActive(true);
             chatPanel.SetActive(true);
             map.SetActive(false);
            panelMap.SetActive(false);

            avatara.SetActive(false);
             if (goToRoom != null)
             {
                 goToRoom.CreateOrJoinRoomTen();
             }

         }
     }
   


    //components
    //Rigidbody myRB;
    [SerializeField] Transform myAvatar;
    //Player mouvement
    Vector2 movementInput;
    // [SerializeField] InputAction WASD;
    [SerializeField] float movementSpeed;

    private Rigidbody2D avatarRb;
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
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (!PhotonNetwork.IsConnected) // Check if not connected
            return;

        if (stream.IsWriting)
        {
            stream.SendNext(JsonUtility.ToJson(myData)); // Convert myData to a JSON string and send it

            stream.SendNext(transform.position); // Send the position data
            stream.SendNext(transform.rotation);
        }
        else
        {
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
    /*[PunRPC]
    private void SyncPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void UpdatePosition(Vector3 newPosition)
    {
        myPV.RPC("SyncPosition", RpcTarget.All, newPosition);
    }*/



    // Start is called before the first frame update
    void Start()
    {
        myPV = GetComponent<PhotonView>();
        myAnim = GetComponent<Animator>();

        if (myPV == null)
        {
            Debug.LogError("PhotonView not found on the GameObject!");
            return;
        }

        if (myPV.IsMine)
        {
            myAvatar = transform.GetChild(0);
            avatarRb = GetComponent<Rigidbody2D>();
            initialPosition = transform.position;

            localPlayer = this;
            if (PhotonNetwork.IsConnected) //before synchronizing
            {
                avatar.SetAvatar(PlayerData.instance.data);
                SyncAvatar(PlayerData.instance);
            }
        }
        
    }
      
    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "MainMenu")
        {
            avatarToResize.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

        }

        if (myPV.IsMine)
        {
                // Process input only when keyboard input is enabled
                movementInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

                // Top
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Z))
                {
                    myAnim.SetBool("IsWalkingLeft", true);
                    avatarRb.velocity = new Vector2(avatarRb.velocity.x, 2f); 
                }
                else if (!Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Z))
                {
                    myAnim.SetBool("IsWalkingLeft", false);
                    avatarRb.velocity = new Vector2(avatarRb.velocity.x, 0f);
                }


                // Right
                if (Input.GetKey(KeyCode.D))
                {
                    myAnim.SetBool("IsWalkingRight", true);
                    SetWalkingRight(true);
                    avatarRb.velocity = new Vector2(2f, avatarRb.velocity.y); 
                }
                else if (!Input.GetKey(KeyCode.D))
                {
                    myAnim.SetBool("IsWalkingRight", false);
                    SetWalkingRight(false);
                    avatarRb.velocity = new Vector2(0f, avatarRb.velocity.y);
                }

                // Down
                if (Input.GetKey(KeyCode.S))
                {
                    myAnim.SetBool("IsWalkingLeft", true);
                    avatarRb.velocity = new Vector2(avatarRb.velocity.x, -2f); 
                }
                else if (!Input.GetKey(KeyCode.S))
                {
                    myAnim.SetBool("IsWalkingLeft", false);
                }


                // Left
                if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q))
                {
                    myAnim.SetBool("IsWalkingLeft", true);
                    SetWalkingLeft(true);
                    avatarRb.velocity = new Vector2(-2f, avatarRb.velocity.y);
                }
                else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.Q))
                {
                    myAnim.SetBool("IsWalkingLeft", false);
                    SetWalkingLeft(false);
                }
        }      

        //  myAnim.SetFloat("Speed", movementInput.magnitude);

        /*
          if (movementInput.x != 0)
          {

               movementInput = WASD.ReadValue<Vector2>();
              myAvatar.localScale = new Vector2(-Mathf.Sign(movementInput.x), 1);
              //Debug.Log("mouvex" + movementInput);
          }
          myAnim.SetFloat("Speed", movementInput.magnitude);*/
    }
    public void CanMove()
    {
        moveAV = !moveAV;
    }

    private void SetWalkingLeft(bool walking)
    {
        isWalkingLeft = walking;
        myAnim.SetBool("IsWalkingLeft", walking);

        // Synchronize the animation
        myPV.RPC("SyncWalkingLeft", RpcTarget.Others, walking);
    }

    private void SetWalkingRight(bool walking)
    {
        isWalkingRight = walking;
        myAnim.SetBool("IsWalkingRight", walking);

        // Synchronize the animation
        myPV.RPC("SyncWalkingRight", RpcTarget.Others, walking);
    }

    [PunRPC]
    private void SyncWalkingLeft(bool walking)
    {
        myAnim.SetBool("IsWalkingLeft", walking);
    }

    [PunRPC]
    private void SyncWalkingRight(bool walking)
    {
        myAnim.SetBool("IsWalkingRight", walking);
    }   

    public void SyncAvatar(PlayerData data)
    {
        if (PhotonNetwork.IsConnected) //before synchronizing
        {
            string syncString = data.AvatarToString();
            myPV.RPC("RPC_SyncAvatar", RpcTarget.OthersBuffered, syncString);
        }
    }

    // synchronized avatar appearance data
    [PunRPC]
    void RPC_SyncAvatar(string data)
    {
        myData = JsonUtility.FromJson<Data>(data);
        avatar.SetAvatar(myData);
    }
}
