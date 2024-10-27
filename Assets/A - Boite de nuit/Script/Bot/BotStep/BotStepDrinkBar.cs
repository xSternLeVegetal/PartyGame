using UnityEngine;

public class BotStepDrinkBar : BotStep
{
    public override void Action(Animator animator)
    {
        animator.Play("Drink");
        GameManagerOld.Instance.HapinnessBonnus(0.15f);
    }
}