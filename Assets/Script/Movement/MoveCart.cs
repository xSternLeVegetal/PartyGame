using UnityEngine;
using UnityEngine.AI;

public class MoveCart : MonoBehaviour
{
    public NavMeshAgent NevMeshAgent;
    public Transform Goal;

    void Start()
    {
        NevMeshAgent.destination = Goal.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
