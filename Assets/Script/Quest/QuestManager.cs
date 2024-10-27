using System.Collections.Generic;
using System.Linq;

public class QuestManager
{
    public List<QuestScriptableObject> AllQuest;
    //Methode qui est appelé quand un enemie meurt, toutes les quétes en rapport sont updaté?
    // genre AllQuest.Where(x=>x.QuestType == KillCount).NbEnemiesKill ++;

    public void InformQuest(QuestEvent questEvent)
    {
        List<QuestScriptableObject> ToInform = new List<QuestScriptableObject>();
        if (questEvent.QuestEventType == QuestEventType.Kill)
        {
            ToInform = AllQuest.Where(x => x.QuestType == QuestType.KillCount).ToList();
        }
        else if (questEvent.QuestEventType == QuestEventType.Collect)
        {
            ToInform = AllQuest.Where(x => x.QuestType == QuestType.Collect).ToList();
        }

        foreach (var quest in ToInform)
        {
            quest.NbCurrent++;
            if (quest.IsFinish())
            {
                GameManager.Instance.MapInfo.CurrentGeneralScore += quest.PointQuest;
                quest.PlayerOwner.PersonalScore += quest.PointQuest;
            }
        }
    }

}