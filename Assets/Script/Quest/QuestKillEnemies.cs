using UnityEngine;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest/KillEnemies")]
public class QuestKillEnemies : QuestScriptableObject
{
    public SpecificEnemiToKill SpecificEnemiToKill;

    QuestKillEnemies()
    {
        QuestType = QuestType.KillCount;
    }
 }