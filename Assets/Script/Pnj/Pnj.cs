using UnityEngine;

public class Pnj : InterractableBase
{
    public GameObject ActionUi;
    public PlayerManager ActualManager;

    public Pnj()
    {
        InteractionType = InteractionType.Pnj;
    }

    public override void Action(GameObject PlayerDoingTheAction)
    {
        Debug.Log("OUAI OUAI OUAI");
        ActualManager = PlayerDoingTheAction.GetComponent<PlayerManager>();
        ActualManager.State.isFreeze = true;
        ActionUi.SetActive(true);
        //Ici pop up de 
    }


    public void ClosePanel()
    {
        ActualManager.State.isFreeze = false;
        ActionUi.SetActive(false);
    }


}