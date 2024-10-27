using UnityEngine;

public class ClimbAction : InterractionAction
{

    public override void Action(GameObject PlayerDoingTheAction)
    {
        PlayerDoingTheAction.GetComponent<PlayerManager>().State.isClimbing = true;
    }

    public void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.GetComponent<PlayerManager>().State.isClimbing = false;
        }
    }

}