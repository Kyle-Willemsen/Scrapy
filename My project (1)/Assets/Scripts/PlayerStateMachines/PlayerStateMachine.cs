using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    PlayerBaseState currentState;

    void Start()
    {
        currentState = GetInitialState();
        if (currentState != null)
        {
            currentState.Enter();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState != null)
        {
            currentState.Update();
        }
        Debug.Log(currentState);
    }

    private void LateUpdate()
    {
        if (currentState != null)
        {
            currentState.LateUpdate();
        }
    }

    public void ChangeState(PlayerBaseState newState)
    {
        currentState.Exit();

        currentState = newState;
        currentState.Enter();
    }

    protected virtual PlayerBaseState GetInitialState()
    {
        return null;
    }

    private void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(Not current State)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }
}
