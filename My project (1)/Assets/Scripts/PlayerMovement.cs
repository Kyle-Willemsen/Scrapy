using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    Camera cam;
    public GameObject wbForm;
    public GameObject humanoidForm;
    Vector3 velocity;

    public float playerSpeed;
    private float currentSpeed;

    private bool isGrounded;
    private float gravityValue = -19.62f;
    private float groundDistance = 0.4f;
    [SerializeField] LayerMask groundLayer;
    public Transform groundCheck;
    private Ray mousePos;
    private Vector3 pointToLook;
    [HideInInspector] public Vector3 facingfDir;


    private bool alreadyHit;
    public GameObject ammunitionUI;
    public GameObject wreckingballUI;

    public GameObject gunbarrel;

    //public float scrapCount = 0f;
    //public TextMeshProUGUI tmpScrap;




    public void Start()
    {
        currentSpeed = playerSpeed;
        controller = GetComponentInParent<CharacterController>();
        cam = Camera.main;
    }

    public void Update()
    {
        Movement();
        MouseLook();
        Gravity();
        WreckingBallTransition();
        //tmpScrap.SetText(scrapCount + "");
    }



    public void Movement()
    {
        facingfDir = new Vector3(pointToLook.x, transform.position.y, pointToLook.z);

        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * currentSpeed);

        if (move != Vector3.zero)
        {
            transform.LookAt(facingfDir);
        }

    }
    private void MouseLook()
    {
            mousePos = cam.ScreenPointToRay(Input.mousePosition);
            Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
            float rayLength;

            if (groundPlane.Raycast(mousePos, out rayLength))
            {
                pointToLook = mousePos.GetPoint(rayLength);

                transform.LookAt(facingfDir);
                gunbarrel.transform.LookAt(facingfDir);
            }
    }

    public void Gravity()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        velocity.y += gravityValue * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }



    public void WreckingBallTransition()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            wbForm.SetActive(true);
            humanoidForm.SetActive(false);
            controller.height = 1f;
            wreckingballUI.SetActive(true);
            ammunitionUI.SetActive(false);
        }
    }



   // private void OnTriggerEnter(Collider other)
   // {
   //     Debug.Log("COLLISION");
   //     if (other.gameObject.tag == "Scrap")
   //     {
   //         Debug.Log("SCRAP COLLISION");
   //         scrapCount += 10;
   //         Destroy(other.gameObject);
   //     }
   // }


    // private void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawSphere(transform.position, gpRadius);
    // }
}
