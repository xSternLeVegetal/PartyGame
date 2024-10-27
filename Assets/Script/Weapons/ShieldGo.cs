using UnityEngine;

public class ShieldGo : WeaponGoManager
{
    public void Start()
    {
        Owner.AddObserverForActionSpecial(this);
    }

    public override void Action(string actionName)
    {
        Debug.Log("TESETSETSETESTSETSE");
        Debug.Log(actionName);
    }
}
