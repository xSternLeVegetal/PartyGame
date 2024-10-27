public class FireBallGo : WeaponGoManager
{
    public void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }
}
