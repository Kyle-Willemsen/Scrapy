using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateHandler : PlayerStateMachine
{
    [HideInInspector] public NormalState normalState;
    [HideInInspector] public WreckingBallstate wbState;

    public CharacterController controller;
    [SerializeField] LayerMask enemyLayerMask;
    public float playerSpeed;
    public float jumpHeight;

    public bool isGrounded;
    public float gravityValue = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public GameObject player;
    public GameObject wreckingball;
    public bool isBalling;
    public Transform groundCheckWB;

    public float scrapCount = 0f;
    [SerializeField] Camera cam;
    public bool isAiming;

    private Ray mousePos;
    [HideInInspector] public Vector3 facingfDir;
    private Vector3 pointToLook;



    private bool isCharging;
    [SerializeField] float dashTime;
    [SerializeField] float dashSpeed;
    [SerializeField] int chargeDamage;
    [SerializeField] float gpSpeed;
    [SerializeField] float gpTime;
    [SerializeField] float gpRadius;
    [SerializeField] int gpDamage;
    [SerializeField] int gpShieldDamage;

    private void Awake()
    {
        normalState = new NormalState(this);
        wbState = new WreckingBallstate(this);
    }

    protected override PlayerBaseState GetInitialState()
    {
        return normalState;
    }
}
