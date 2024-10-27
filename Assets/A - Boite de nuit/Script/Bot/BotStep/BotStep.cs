using UnityEngine;

public class BotStep : MonoBehaviour
{
    public BotStepTypeEnum Type;
    public bool IsOccupied;

    public void Start()
    {

    }

    public void OnCollisionEnter()
    {
        IsOccupied = true;
    }

    public void OnCollisionExit()
    {
        IsOccupied = false;
    }

    public virtual void Action(Animator animator)
    {
        animator.Play("Idle");
    }
}