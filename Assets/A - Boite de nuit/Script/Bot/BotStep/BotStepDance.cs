using UnityEngine;

public class BotStepDance : BotStep
{
    public override void Action(Animator animator)
    {
        animator.Play("Silly Dancing");
        GameManagerOld.Instance.HapinnessBonnus(0.5f);
    }
}