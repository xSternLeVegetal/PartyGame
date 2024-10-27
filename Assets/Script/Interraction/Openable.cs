using UnityEngine;

public class Openable : InterractableBase
{
    public string ContainerName;
    public GameObject PartToRotate;
    public Vector3 RotationAxe;
    public bool isOpen;

    public Openable()
    {
        InteractionType = InteractionType.Loot;
    }

    public override void Action(GameObject PlayerDoingTheAction)
    {
        if (!isOpen)
        {
            PartToRotate.transform.Rotate(RotationAxe, 90);
            isOpen = true;
        }
        else
        {
            PartToRotate.transform.Rotate(RotationAxe, -90);
            isOpen = false;
        }
    }
}