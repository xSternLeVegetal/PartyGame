using UnityEngine;

public class Monster : InterractableBase
{
    public string MonsterName;
    public string GainOnKill;

    public Monster()
    {
        InteractionType = InteractionType.Monster;
    }

    public override void Action(GameObject PlayerDoingTheAction)
    {
        //A la limite display les info du monstre sur un petit panel en haut a droite de l'écrant?
    }
}