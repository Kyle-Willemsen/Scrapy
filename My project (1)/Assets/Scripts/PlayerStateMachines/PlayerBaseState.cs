using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBaseState
{
    public string name;
    protected PlayerStateMachine palyerStateMachine;

    public PlayerBaseState(string name, PlayerStateMachine playerStateMachine)
    {
        this.name = name;
        this.palyerStateMachine = playerStateMachine;
    }

    public virtual void Enter()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void LateUpdate()
    {

    }

    public virtual void Exit()
    {

    }
}

