using UnityEngine;

public class BattleManager : MonoBehaviour
{
    public ClassData AttackDone(ClassData from, ClassData to)
    {
        ClassData toReturn = to;
        Debug.Log(from.ClassName + " attack " + to.ClassName);
        Debug.Log("Attack value : " + from.Attaque + " Defense value : " + to.Defense);
        var value = from.Attaque - to.Defense;
        toReturn.LifePoint -= value < 0 ? 0 : value;
        return toReturn;
    }
}
