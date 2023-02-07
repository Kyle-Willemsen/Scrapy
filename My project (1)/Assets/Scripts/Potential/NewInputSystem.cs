using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewInputSystem : MonoBehaviour
{
    PlayerControls playerControls;
    CharacterController controller;

    Vector2 currentMovementInput;
    Vector3 currentMovement;
    bool isMovementPressed;
    public float playerSpeed = 10;

    [SerializeField] Camera cam;



    private void Awake()
    {
        playerControls = new PlayerControls();
        controller = GetComponent<CharacterController>();

        playerControls.Grounded.Move.started += OnMovementInput;
        playerControls.Grounded.Move.canceled += OnMovementInput;
        playerControls.Grounded.Move.performed += OnMovementInput;

        playerControls.Grounded.MousePos.performed += MouseLook;

    }

    private void Update()
    {
       // controller.Move(currentMovement * Time.deltaTime * playerSpeed);
       //
       // Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
       // float rayLength;
       //
       // if (groundPlane.Raycast(mousePos, out rayLength))
       // {
       //     pointToLook = mousePos.GetPoint(rayLength);
       //
       //     transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
       // }
    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        currentMovementInput = context.ReadValue<Vector2>();
        currentMovement.x = currentMovementInput.x;
        currentMovement.z = currentMovementInput.y;
        isMovementPressed = currentMovementInput.x != 0 || currentMovementInput.y != 0;
    }

    private void MouseLook(InputAction.CallbackContext context)
    {
        // Ray mousePos = cam.ScreenPointToRay(Input.mousePosition);
        // Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        // float rayLength;
        //
        // if (groundPlane.Raycast(mousePos, out rayLength))
        // {
        //     Vector3 pointToLook = mousePos.GetPoint(rayLength);
        //
        //     transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        // }

        Vector2 mousePos = cam.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }
    

    private void OnEnable()
    {
        playerControls.Grounded.Move.Enable();
    }

    private void OnDisable()
    {
        playerControls.Grounded.Move.Disable();
    }
}