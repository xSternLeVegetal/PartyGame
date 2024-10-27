public class MageData : ClassData
{
    public MageData()
    {
        ClassName = ConstantStringManager.PlayerClassName.Mage;
        LifePointMax = 50;
        ManaPointMax = 100;
        EnduranceMax = 5;
        AttaqueOriginal = 0;
        DefenseOriginal = 10;
        LifePoint = LifePointMax;
        ManaPoint = ManaPointMax;
        Endurance = EnduranceMax;
        Attaque = AttaqueOriginal;
        Defense = DefenseOriginal;
        AttackSpeed = 0.5f;
        AttackBasic = new SmallFireball();
        AttackHeavy = new LightningChain();
        Passive = new ManaRecovery();
    }
}