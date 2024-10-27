using Unity.VisualScripting;
using UnityEngine;

public class SwordGo : WeaponGoManager
{
    public Transform HitPoint;
    public float RadiusHit;
    public LayerMask LayerMaskHit;

    public void Start()
    {
        Owner.AddObserverForActionBasic(this); 
    }

    public override void Action(string actionName)
    {
        // OU ici faire le trick avec cast over sphere!
        // donc je cast
        //je chope une ref des enemies touché
        //je fait un .TakeDamage(weaponDamage)

        var HitColliders = Physics.OverlapSphere(HitPoint.position, RadiusHit, LayerMaskHit);
        if (HitColliders != null && HitColliders.Length > 0)
        {
            Debug.Log(HitColliders[0].gameObject.name);
            var monsterManager = HitColliders[0].GetComponentInParent<MonsterManager>();
            monsterManager.TakeDamage(Owner.MyClassData);
        }

    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(HitPoint.position, RadiusHit);
    }

}
