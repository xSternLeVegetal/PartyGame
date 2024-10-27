using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/CollectResource")]
public class QuestCollectResource : QuestScriptableObject
{
    public SpecificResourceToCollect SpecificResourceToCollect;

    QuestCollectResource()
    {
        QuestType = QuestType.KillCount;
    }
 }