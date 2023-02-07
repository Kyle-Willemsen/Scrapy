using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBallstate : PlayerBaseState
{
    public WreckingBallstate(PlayerStateHandler stateMachine) : base("WreckingBallstate", stateMachine) { }

    public GameObject player;
    public GameObject wreckingball;
    public bool isBalling;
    public Transform groundCheckWB;

    private bool isCharging;
    [SerializeField] float dashTime;
    [SerializeField] float dashSpeed;
    [SerializeField] int chargeDamage;
    [SerializeField] float gpSpeed;
    [SerializeField] float gpTime;
    [SerializeField] float gpRadius;
    [SerializeField] int gpDamage;
    [SerializeField] int gpShieldDamage;
    //NormalState norm;

    public bool alreadyHit;

    public override void Enter()
    {
        base.Enter();
       // norm.controller.height = 1f;
       // isBalling = true;
       // player.SetActive(false);
       // wreckingball.SetActive(true);
       // norm.playerSpeed = 20f;

    }

    public override void Update()
    {
        base.Update();

    }

    public override void Exit()
    {
        base.Exit();
       // norm.controller.height = 2f;
       // isBalling = false;
       // player.SetActive(true);
       // wreckingball.SetActive(false);
       // norm.playerSpeed = 10f;
    }


}

