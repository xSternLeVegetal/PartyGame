public class ArrowGo : WeaponGoManager
{
    public void OnCollisionEnter()
    {
        Destroy(this.gameObject);
    }
}
