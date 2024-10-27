using System;
using UnityEngine;

public class Loot : InterractableBase
{
    public string LootName;
    public int ValueGainOnLooted;
    public LootTypeEnum lootType;
    public LootRarityEnum lootRarity;

    public Loot()
    {
        InteractionType = InteractionType.Loot;
    }

    public override void Action(GameObject PlayerDoingTheAction)
    {
        GameManager.Instance.MapInfo.CurrentGeneralScore += ValueGainOnLooted;
        PlayerDoingTheAction.GetComponent<PlayerManager>().PersonalScore += ValueGainOnLooted;
        var questEvent = new QuestEvent()
        {
            QuestEventType = QuestEventType.Collect,
            SpecificResourceToCollect = (SpecificResourceToCollect)Enum.Parse(typeof(SpecificResourceToCollect), lootType.ToString()),
            SpecificEnemiToKill = SpecificEnemiToKill.None
        };

        //GameManager.Instance.QuestManager.InformQuest(questEvent);

        //Debug.Log("OUAI OUAI OUAI");
        Destroy(this.gameObject);
        //Ici pop up de 
    }
}