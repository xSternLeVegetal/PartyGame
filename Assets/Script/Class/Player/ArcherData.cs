public class ArcherData : ClassData
{
    public ArcherData()
    {
        ClassName = ConstantStringManager.PlayerClassName.Archer;
        LifePointMax = 50;
        ManaPointMax = 0;
        EnduranceMax = 20;
        AttaqueOriginal = 15;
        DefenseOriginal = 10;
        LifePoint = LifePointMax;
        ManaPoint = ManaPointMax;
        Endurance = EnduranceMax;
        Attaque = AttaqueOriginal;
        Defense = DefenseOriginal;
        AttackSpeed = 1f;
        AttackBasic = new ArrowShoot();
        AttackHeavy = new ArrowRain();
        Passive = new SpeedIncrease();
    }
}