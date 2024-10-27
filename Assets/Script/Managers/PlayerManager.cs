using Photon.Pun;
using UnityEngine;

public class PlayerManager : Subject
{
    public string className;
    public ClassData MyClassData;
    public Animator Animator;
    public int PersonalScore;
    public StateStruct State;

    public struct StateStruct
    {
        public bool isGrounded;
        public bool isRunning;
        public bool isAttacking;
        public bool isDead;
        public bool isFreeze;
        public bool isClimbing;
    }

    private string animBaseLayer;
    private string animUpperBodyLayer;
    private int attack01Hash;
    private int attack02Hash;
    private int death01Hash;
    private int death02Hash;
    private int runningHash;
    private int walkingHash;
    private int idleHash;

    void Start()
    {
        //Test
        MyClassData = GameManager.Instance.FindClassSelected(className);
        //

        animBaseLayer = "Base Layer." + MyClassData.ClassName;
        animUpperBodyLayer = "UpperBodyLayer" + MyClassData.ClassName;
        attack01Hash = Animator.StringToHash(animUpperBodyLayer + "Attack1");
        attack02Hash = Animator.StringToHash(animUpperBodyLayer + "Attack2");
        death01Hash = Animator.StringToHash(animBaseLayer + "Death1");
        death02Hash = Animator.StringToHash(animBaseLayer + "Death2");
        runningHash = Animator.StringToHash(animBaseLayer + "Run");
        walkingHash = Animator.StringToHash(animBaseLayer + "Walk");
        idleHash = Animator.StringToHash(animBaseLayer + "Idle");
    }

    void Update()
    {
        if (photonView.IsMine == false && PhotonNetwork.IsConnected == true)
        {
            return;
        }
        if (State.isFreeze)
            return;
        AnimationStateMapper();
    }
    

    //méthode que je veux : observe l'état dans le quel on est 
    //et si je suis entrain de jouer l'animation d'attaque, alors je suis attacking, sinon je le suis pas
    //si je suis idle alors je suis rien etc etc etc

    private void AnimationStateMapper()
    {
        var currentStateBaseLayer = Animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
        var currentStateUpperLayer = Animator.GetCurrentAnimatorStateInfo(1).fullPathHash;
        if (currentStateUpperLayer == attack01Hash || currentStateUpperLayer == attack02Hash)
        {
            State.isAttacking = true;
        }
        else
        {
            State.isAttacking = false;
        }
        if (currentStateBaseLayer == death01Hash || currentStateBaseLayer == death02Hash)
        {
            State.isDead = true;
        }
        else
        {
            State.isDead = false;
        }
        if (currentStateBaseLayer == runningHash || currentStateBaseLayer == walkingHash)
        {
            State.isRunning = true;
        }
        else
        {
            State.isRunning = false;
        }
        if (currentStateBaseLayer == idleHash)
            Debug.Log("COUCOU");
    }
}
