using System;
using UnityEngine;

public abstract class BaseState <EState> where EState : Enum
{
    public EState StateKey;

    public BaseState(EState key)
    {
        StateKey = key;
    }
    
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
    public abstract void OnTriggerEnter(Collider other);
    public abstract void OnTriggerStay(Collider other);
    public abstract void OnTriggerExit(Collider other);
}
