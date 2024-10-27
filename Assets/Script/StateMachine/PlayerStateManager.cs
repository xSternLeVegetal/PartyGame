using static PlayerStateManager;

public abstract class PlayerStateManager : StateManager<EPlayerAnimationState>
{
    public enum EPlayerAnimationState
    {
        Walk,
        Run,
        Idle,
        Attack,
        Hurt,
        Dead
    }
}
