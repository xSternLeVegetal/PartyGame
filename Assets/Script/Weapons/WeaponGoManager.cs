using UnityEngine;

public class WeaponGoManager : MonoBehaviour, IObserver
{
    public PlayerManager Owner;
    public float ReloadTime;

    public virtual void Action(string actionName)
    {

    }


    public void OnNotify(string action)
    {
        Action(action);
    }
}
