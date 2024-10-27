public class EpeisteData : ClassData
{
    public EpeisteData()
    {
        ClassName = ConstantStringManager.PlayerClassName.Epeiste;
        LifePointMax = 75;
        ManaPointMax = 0;
        EnduranceMax = 20;
        AttaqueOriginal = 20;
        DefenseOriginal = 30;
        LifePoint = LifePointMax;
        ManaPoint = ManaPointMax;
        Endurance = EnduranceMax;
        Attaque = AttaqueOriginal;
        Defense = DefenseOriginal;
        AttackSpeed = 1.5f;
        AttackBasic = new SwordAttack();
        AttackHeavy = new ShieldProtection();
        Passive = new ArmorPassive();
    }
}