using UnityEngine;

public class QuestScriptableObject : ScriptableObject
{
    public string QuestName;
    public string QuestDescription;
    public int NbToReach;
    public int NbCurrent;
    public int PointQuest;
    public QuestType QuestType;
    public QuestLevel QuestLevel;
    public QuestScope QuestScope;
    public PlayerManager PlayerOwner;
    public GameObject QuestUiHolderPrefab;

    public bool IsFinish()
    {
        return NbCurrent >= NbToReach;
    }
}