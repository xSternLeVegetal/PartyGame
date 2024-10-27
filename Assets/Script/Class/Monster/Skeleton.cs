public class Skeleton : ClassData
{
    public Skeleton()
    {
        ClassName = ConstantStringManager.MonsterName.Skeleton;
        LifePointMax = 75;
        ManaPointMax = 0;
        EnduranceMax = 20;
        AttaqueOriginal = 20;
        DefenseOriginal = 10;
        LifePoint = LifePointMax;
        ManaPoint = ManaPointMax;
        Endurance = EnduranceMax;
        Attaque = AttaqueOriginal;
        Defense = DefenseOriginal;
        AttackBasic = new SwordAttack();
        AttackHeavy = new ShieldProtection();
        Passive = new ArmorPassive();
    }
}