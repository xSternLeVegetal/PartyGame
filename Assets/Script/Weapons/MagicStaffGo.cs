using UnityEngine;

public class MagicStaffGo : WeaponGoManager
{
    public GameObject FireBallPrefab;
    public GameObject LignthingPrefab;
    public Transform FireballShootPoint;
    public Transform LigthningShootPoint;
    [SerializeField] public LayerMask LayerMask;
    Camera camera;

    public void Start()
    {
        camera = Owner.GetComponent<PlayerInputManager>().MyCamera;
        Owner.AddObserverForActionBasic(this);
        Owner.AddObserverForActionSpecial(this);
    }

    public override void Action(string actionName)
    {
        if (actionName == "Fireball") 
            ShootFireball();
        if (actionName == "Eclair")
            ShootLihtning();
    }

    private void ShootLihtning()
    {
        //Cast de Rayon, si on touche on chope la target, on met le target de l'eclrait a sa poz ,sinon a 3 de devant nous
        // puis si on touche on cast sphére pour choper un autre gus et si on touche on instancie un nouvelle a ces coordonée, puis on refait le tous max 3/4 fois?
        Ray rayon = new Ray(camera.transform.position, (camera.transform.forward.normalized * 2));
        RaycastHit Hit = new RaycastHit();
        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out Hit, 3f, LayerMask))
        {
            if (Hit.transform.tag == "Monster")
            {
                
                InstantiateLigthning(LigthningShootPoint, Hit.transform);
                Transform previousTarget = Hit.transform;
                for (int i = 0; i < 2; i++)
                {
                    //methode pour cast la sphere aveec en param la position du dernier ennemies touché, et si c'est false on return
                    
                    Transform nextTarget = PropagationPossible(previousTarget);
                    if (nextTarget != null)
                    {
                        InstantiateLigthning(previousTarget , nextTarget);
                        previousTarget = nextTarget;
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
    }

    private Transform PropagationPossible(Transform HitPreviousTarget)
    {
        RaycastHit Hit = new RaycastHit();
        Ray rayon = new Ray(camera.transform.position, (camera.transform.forward.normalized * 2));
        var Test = Physics.OverlapSphere(HitPreviousTarget.position, 3f, LayerMask);
        Debug.Log(Test[0].gameObject.name); // Et check que c'est pas moi (aka l'origin/previoustarget) ???
        return Test[0].transform;
        //if (Physics.SphereCast(HitPreviousTarget.position, 3, HitPreviousTarget.position, out Hit,0, LayerMask))
        //{
        //    Debug.Log("OUI");
        //    if (Hit.transform.tag == "Monster")
        //    {
        //        Debug.Log("OUIOUIOUI");
        //        return Hit.transform;
        //    }
        //}
        return null;
    }

    private void InstantiateLigthning(Transform Origin, Transform Target)
    {
        var ligthning = Instantiate(LignthingPrefab, Origin.position, Quaternion.identity,
            Origin);
        ligthning.transform.parent = null; 
        var ligthningGO = ligthning.transform.GetComponent<LigthningGO>();
        ligthningGO.StartPoint = Origin.transform.position;
        ligthningGO.EndPoint = Target.transform.position;
        //var targetLigthningTransform = ligthning.GetComponentInChildren<Transform>();
        //targetLigthningTransform.position 
    }

    public void ShootFireball()
    {
        camera = Owner.GetComponent<PlayerInputManager>().MyCamera;
        var OwnerCameraForward = camera.transform.forward;
        //var CameraRotation =  camera.transform.rotation.eulerAngles + new Vector3(-90,0,0);
        var projectile = Instantiate(FireBallPrefab, FireballShootPoint);
        projectile.transform.localPosition = Vector3.zero;
        projectile.transform.rotation = camera.transform.rotation;
        projectile.transform.parent = null;
        projectile.GetComponentInChildren<FireBallGo>().Owner = Owner;
        var rb = projectile.GetComponentInChildren<Rigidbody>();
        rb.velocity = OwnerCameraForward * 30;
    }
}