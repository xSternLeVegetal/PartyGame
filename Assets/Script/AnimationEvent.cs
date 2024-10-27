using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    public PlayerManager playerManager;

    public void NotifyActionBasic(string actionName)
    {
        playerManager.NotifyObserversForActionBasic(actionName);
    }

    public void NotifyActionSpecial(string actionName)
    {
        playerManager.NotifyObserversForActionSpecial(actionName);
    }

    public void StopAction()
    {

    }
}
