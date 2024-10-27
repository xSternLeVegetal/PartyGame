using UnityEngine;

public class BowGo : WeaponGoManager
{
    public GameObject ArrowPrefab;
    public Transform ShootPoint;

    public void Start()
    {
        Owner.AddObserverForActionBasic(this);
    }

    public override void Action(string actionName)
    {
        if (actionName == "Arrow")
            ShootArrow();
    }

    public void ShootArrow()
    {
        var camera = Owner.GetComponent<PlayerInputManager>().MyCamera;
        var OwnerCameraForward = camera.transform.forward;
        //var CameraRotation =  camera.transform.rotation.eulerAngles + new Vector3(-90,0,0);
        var projectile = Instantiate(ArrowPrefab, ShootPoint);
        projectile.transform.localPosition = Vector3.zero;
        projectile.transform.rotation = camera.transform.rotation;
        projectile.transform.parent = null;
        projectile.GetComponentInChildren<ArrowGo>().Owner = Owner;
        var rb = projectile.GetComponentInChildren<Rigidbody>();
        rb.velocity = OwnerCameraForward * 80;
    }

}
