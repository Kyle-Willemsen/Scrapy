using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalState : PlayerBaseState
{
    public NormalState(PlayerStateHandler stateMachine) : base ("NormalState", stateMachine) { }
   //WreckingBallstate wbState;
   //public CharacterController controller;
   //[SerializeField] LayerMask enemyLayerMask;
   //public float playerSpeed;
   //public float jumpHeight;
   //
   //public bool isGrounded;
   //public float gravityValue = -9.81f;
   //public float groundDistance = 0.4f;
   //public LayerMask groundLayer;
   //public Transform groundCheck;
   //
   //public GameObject player;
   //public GameObject wreckingball;
   //public bool isBalling;
   //public Transform groundCheckWB;
   //
   //public float scrapCount = 0f;
   //
   //[SerializeField] Camera cam;
   //public bool isAiming;
   //
   //private Ray mousePos;
   //[HideInInspector] public Vector3 facingfDir;
   //private Vector3 pointToLook;

    public override void Enter()
    {
        base.Enter();

        /*humanoid form is active
         * play transition animation
         */
    }

    public override void Update()
    {
        base.Update();
        // Movement();
        // MouseLook();

        // facingfDir = new Vector3(pointToLook.x, controller.transform.position.y, pointToLook.z);
        //
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        //controller.Move(move * Time.deltaTime * playerSpeed);
        //
        //if (move != Vector3.zero)
        //{
        //    controller.transform.LookAt(facingfDir);
        //    //gameObject.transform.forward  = move;
        //}
        //
        //
        //mousePos = cam.ScreenPointToRay(Input.mousePosition);
        //Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        //float rayLength;
        //
        //if (groundPlane.Raycast(mousePos, out rayLength))
        //{
        //    pointToLook = mousePos.GetPoint(rayLength);
        //
        //    controller.transform.LookAt(facingfDir);
        //}
    }

   // public void Movement()
   // {
   //     facingfDir = new Vector3(pointToLook.x, controller.transform.position.y, pointToLook.z);
   //
   //     Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
   //     controller.Move(move * Time.deltaTime * playerSpeed);
   //
   //     if (move != Vector3.zero)
   //     {
   //         controller.transform.LookAt(facingfDir);
   //         //gameObject.transform.forward  = move;
   //     }
   //  
   // }
   // private void MouseLook()
   // {
   //     mousePos = cam.ScreenPointToRay(Input.mousePosition);
   //     Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
   //     float rayLength;
   //  
   //     if (groundPlane.Raycast(mousePos, out rayLength))
   //     {
   //         pointToLook = mousePos.GetPoint(rayLength);
   //  
   //         controller.transform.LookAt(facingfDir);
   //     }
   // }
}