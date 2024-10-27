using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotManager : MonoBehaviour
{
    public List<BotStep> Path;
    public int CurrentStep;
    public Transform TargetPosition;
    public NavMeshAgent Agent;
    public Animator Animator;

    //public float Happiness;

    [Header("Movement")]
    public int Speed = 2;
    public bool Frozen;

    public void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponentInChildren<Animator>();
        //TargetPosition = Path[CurrentStep].transform;
        GetRandomNextTargetPos();
    }

    public void LateUpdate()
    {
        if (!Frozen)
        {
            if (Vector3.Distance(transform.position, Path[CurrentStep].transform.position) <= 1f)//Gerer avec le stopping distance du navmesh
            {
                switch (Path[CurrentStep].Type)
                {
                    case BotStepTypeEnum.GoNext:
                        GetRandomNextTargetPos();
                        break;
                    case BotStepTypeEnum.Action:
                    {
                        Freeze(5);
                        if (Animator!=null) 
                            Path[CurrentStep].Action(Animator);
                    }
                        break;
                    case BotStepTypeEnum.Wait:
                        Freeze(10);
                        break;
                }
            }
            else if (Vector3.Distance(transform.position, Path[CurrentStep].transform.position) <= 5f)
            {
                if (Path[CurrentStep].IsOccupied)
                {
                    GetRandomNextTargetPos();
                }
            }
            else
            {
                MoveToTarget();
            }
        }
    }

    //public void FixedUpdate()
    //{

    //}

    public void MoveToTarget()
    {
        //Vector3 dir = Path[CurrentStep].transform.position - transform.position;
        //transform.Translate(dir.normalized * Speed * Time.deltaTime, Space.World);
        //transform.LookAt(Path[CurrentStep].transform);

        Agent.destination = TargetPosition.transform.position;
    }
    
    public void Freeze(float seconds)
    {
        Frozen = true;
        Animator?.Play("Idle");
        //Inutile je pense , faire juste que si les point action + waiting, sont déja occupé par X (généralement 1 ) alors je prend un autres points tout simplement
        Invoke("Unfreeze", seconds);
    }

    private void Unfreeze()
    {
        Frozen = false;
        GetRandomNextTargetPos();
        Animator?.Play("Walk");
    }

    public void GetRandomNextTargetPos()
    {
        var Rand = Random.Range(0, Path.Count);
        CurrentStep = Rand;
        TargetPosition = Path[CurrentStep].transform;
        //Agent.destination = TargetPosition.transform.position;
    }
}