using UnityEngine;

public class InterractableBase : MonoBehaviour
{
    public InteractionType InteractionType;

    public void Start()
    {
        GameObject.Find("Interraction UI");
    }

    public virtual void Action(GameObject PlayerDoingTheAction)
    {
        Debug.Log("Not Implemented");
    }

}