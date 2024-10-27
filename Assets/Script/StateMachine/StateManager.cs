using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateManager<EState> : MonoBehaviour where EState : Enum
{
    protected Dictionary<EState, BaseState<EState>> States = new Dictionary<EState, BaseState<EState>>();
    protected BaseState<EState> currentState;
    protected bool IsTransitionState = false;

    public void Start()
    {
        currentState.EnterState();
    }

    public void Update()
    {
        EState nexStateKey = currentState.GetNextState();
        if (!IsTransitionState && nexStateKey.Equals(currentState.StateKey))
        {
            currentState.UpdateState();
        }
        else if (!IsTransitionState)
        {
            TransitionToState(nexStateKey);
        }
    }

    private void TransitionToState(EState nexStateKey)
    {
        IsTransitionState = true;
        currentState.ExitState();
        currentState = States[nexStateKey];
        currentState.EnterState();
        IsTransitionState = false;
    }

    public void OntriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(other);
    }
    public void OntriggerStay(Collider other)
    {
        currentState.OnTriggerStay(other);
    }
    public void OntriggerExit(Collider other)
    {
        currentState.OnTriggerExit(other);
    }
}
