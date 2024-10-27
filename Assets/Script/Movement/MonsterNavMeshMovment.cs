using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class MonsterNavMeshMovment : MonoBehaviour
{
    //public string className;
    //public ClassData MyClassData;
    public MonsterManager MonsterManager;
    public LayerMask CibleLayerMask;

    // Start is called before the first frame update
    [Header("Patrouille")] public Vector3 SpawnPoint;
    public Vector3 Target;
    private Transform TargetTransform;
    public float RadiusPatrouille;
    public float RadiusDetection;
    public float ChaseDistanceMax;
    public float RadiusAttack;
   

    //private string animBaseLayer;
    //private string animUpperBodyLayer;
    //private int attack01Hash;
    //private int attack02Hash;
    //private int death01Hash;
    //private int death02Hash;
    //private int runningHash;
    //private int walkingHash;
    //private int idleHash;

    void Start()
    {
        //MyClassData = GameManager.Instance.FindMonster(className);
        //

        //animBaseLayer = "Base Layer." + MyClassData.ClassName;
        //animUpperBodyLayer = "UpperBodyLayer" + MyClassData.ClassName;
        //attack01Hash = Animator.StringToHash(animUpperBodyLayer + "Attack1");
        //attack02Hash = Animator.StringToHash(animUpperBodyLayer + "Attack2");
        //death01Hash = Animator.StringToHash(animBaseLayer + "Death1");
        //death02Hash = Animator.StringToHash(animBaseLayer + "Death2");
        //runningHash = Animator.StringToHash(animBaseLayer + "Run");
        //walkingHash = Animator.StringToHash(animBaseLayer + "Walk");
        //idleHash = Animator.StringToHash(animBaseLayer + "Idle");

        MonsterManager.State.isPatrolling = true;
        GetRandomDestination();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (MonsterManager.State.AlreadyDead)
            return;
        MonsterManager.MonsterAnimator.SetFloat(ConstantStringManager.MonsterAnimatorParameters.Movementspeed, MonsterManager.Agent.velocity.magnitude);

        CheckEnemiesInAttackRange();
        CheckEnemiesInRange();
        //pour l'instant risque de
        //bug du mob qui sais plus quoi faire
        if (MonsterManager.State.isMovingToAttack && /*Vector3.Distance(transform.position, SpawnPoint)*/
            MonsterManager.Agent.remainingDistance > ChaseDistanceMax)
        {
            MonsterManager.State.isMovingToAttack = false;
            MonsterManager.State.isPatrolling = true;
        }

        if (MonsterManager.State is {isPatrolling: true, isFreeze: false} && Vector3.Distance(transform.position, Target) <= 2f)
        {
            Freeze(2);
        }

        
    }
    
    private void CheckEnemiesInAttackRange()
    {
        var HitTargets = Physics.OverlapSphere(transform.position, RadiusAttack, CibleLayerMask);
        if (HitTargets != null && HitTargets.Any())
        {
            MonsterManager.Agent.isStopped = true;
            MonsterManager.State.Attack1 = true;
            MonsterManager.State.Attack2 = false;
            MonsterManager.State.isAttacking = true;
            //animator.Play(className + "Attack");
            //GetRandom ennemy a porter à Taper
            //voir à faire que si le cart est à - de X alors il passe en prio sinon c'est le joueur ?
        }
        else
        {
            MonsterManager.Agent.isStopped = false;
            MonsterManager.State.isAttacking = false;
            MonsterManager.State.Attack1 = false;
            MonsterManager.State.Attack2 = false;
        }
    }

    private void CheckEnemiesInRange()
    {
        var HitTargets = Physics.OverlapSphere(transform.position, RadiusDetection, CibleLayerMask);
        if (HitTargets != null && HitTargets.Any())
        {
            //TargetTransform = HitTargets[0].transform;
            MonsterManager.Agent.ResetPath();
            MonsterManager.Agent.destination = HitTargets[0].transform.position;
            MonsterManager.State.isMovingToAttack = true;
            MonsterManager.State.isPatrolling = false;
            //animator.SetFloat("VectorY", 0.5f);

        }
        else
        {
            MonsterManager.State.isMovingToAttack = false;
            MonsterManager.State.isPatrolling = true;
        }
    }

    public void Freeze(float seconds)
    {
        MonsterManager.State.isFreeze = true;
        //animator.SetFloat("VectorY", 0);
        //animator.Play(className+"Idle");
        MonsterManager.Agent.isStopped = true;
        MonsterManager.Agent.ResetPath();
        Invoke("Unfreeze", seconds);
    }

    private void Unfreeze()
    {
        MonsterManager.State.isFreeze = false;
        MonsterManager.Agent.isStopped = false;
        GetRandomDestination();
    }

    public void GetRandomDestination()
    {
        var direction = Random.insideUnitSphere * RadiusPatrouille;
        direction += SpawnPoint;
        NavMeshHit hit;
        Vector3 FinalPos = Vector3.zero;
        if (NavMesh.SamplePosition(direction, out hit, RadiusPatrouille, 1))
        {
            FinalPos = hit.position;
        }
        else
        {
            GetRandomDestination();
        }

        Target = FinalPos;
        MonsterManager.Agent.ResetPath();
        MonsterManager.Agent.destination = Target;
        //animator.Play(className + "Walk");
    }

    //void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawLine(transform.position, Target);
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawSphere(SpawnPoint, RadiusPatrouille);
    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawSphere(transform.position, RadiusDetection);
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawSphere(transform.position, RadiusAttack);
    //}
}