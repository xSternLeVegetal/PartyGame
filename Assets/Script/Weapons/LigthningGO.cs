using UnityEngine;

public class LigthningGO : WeaponGoManager
{
    public Vector3 StartPoint;
    public Vector3 EndPoint;
    public Transform TargetGO;

    public void Update()
    {
        this.transform.position = StartPoint;
        TargetGO.position = EndPoint;
    }
    //public void OnCollisionEnter()
    //{
    //    Destroy(this.gameObject);
    //}
}
