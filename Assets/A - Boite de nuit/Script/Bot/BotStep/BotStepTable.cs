using UnityEngine;

public class BotStepTable : BotStep
{
    public override void Action(Animator animator)
    {
        animator.Play("StandToSit");
        GameManagerOld.Instance.HapinnessBonnus(0.8f);
    }
}