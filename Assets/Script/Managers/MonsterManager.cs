using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class MonsterManager : MonoBehaviour
{
    public Animator MonsterAnimator;
    public NavMeshAgent Agent;
    public string MonsterName;
    public ClassData MonsterData;
    public Image LifeUiImage;
    public PlayerManager LastPlayerHitting;
    public StateStruct State;
    public void Start()
    {
        MonsterData = GameManager.Instance.FindMonster(MonsterName);
        State.AlreadyDead = false;
    }

    public void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.gameObject.name);
        if ((other.tag == "Weapon" || other.tag == "Projectile"))
        {
            //Debug.Log(other.gameObject.name);

            //var rb = this.GetComponent<Rigidbody>();
            //rb.detectCollisions = false;
            //StartCoroutine("ReActivateCollision", 0.5);

            var Attacker = other.GetComponent<WeaponGoManager>().Owner.MyClassData;

            TakeDamage(Attacker);

            LastPlayerHitting = other.transform.GetComponent<WeaponGoManager>().Owner;
            Debug.Log(MonsterData.LifePoint);
            if (other.tag == "Projectile")//risuqe pas de marcher connard peuvent pas avoir 2 tag
                Destroy(other.gameObject);
        }
    }

    public void Attack()//Sortirsa dans un Skelette Manager , car un MageSkelette feras autrement
    {
        Debug.Log("Il me tape OMG");
        //CastOverSphere
        //GetUnPlayer/Cart
        //Apply les dégat
    }

    public void TakeDamage(ClassData Attacker)
    {
        //MonsterAnimator.SetTrigger("isHurt");
        State.isHurt = true;
        MonsterData = GameManager.Instance.BattleManager.AttackDone(Attacker, MonsterData);
        //LastPlayerHitting = Attacker
        UpdateLifeUi();
    }

    private IEnumerator ReActivateCollision(float time)
    {
        yield return new WaitForSeconds(time);
        var rb = this.GetComponent<Rigidbody>();
        rb.detectCollisions = true;
    }

    public void UpdateLifeUi()
    {
        var hp = Mathf.Clamp(MonsterData.LifePoint, 0, MonsterData.LifePointMax);
        float amount = (float)hp / MonsterData.LifePointMax;
        LifeUiImage.fillAmount = amount;
    }

    public void Update()
    {
        if (State.AlreadyDead)
            return;
        if (MonsterData.LifePoint <= 0)
        {
            Dead();
        }
        CheckCurrentState();
    }

    private void Dead()
    {
        State.isDead = true;
        GameManager.Instance.MapInfo.CurrentGeneralScore += 20;
        //LastPlayerHitting.PersonalScore += 20;

        //var questEvent = new QuestEvent()
        //{
        //    QuestEventType = QuestEventType.Kill,
        //    SpecificEnemiToKill = (SpecificEnemiToKill) Enum.Parse(typeof(SpecificEnemiToKill), MonsterName),
        //    SpecificResourceToCollect = SpecificResourceToCollect.None
        //};
    
        //GameManager.Instance.QuestManager.InformQuest(questEvent);
        //Destroy(this.transform.gameObject);
    }

    public void CheckCurrentState()
    {
        //Ici méthod to check logiq of State (aka can't patroll and run to attack

        if (State.isFreeze)
        {
            MonsterAnimator.SetFloat(ConstantStringManager.MonsterAnimatorParameters.Movementspeed, 0f);
        }
        if (State.isPatrolling)
        {
            Agent.speed = 1f;
            MonsterAnimator.SetFloat(ConstantStringManager.MonsterAnimatorParameters.IsInBattleState, 0f);
            State.isMovingToAttack = false;
        }
        if (State.isMovingToAttack)
        {
            Agent.speed = 2.5f;
            MonsterAnimator.SetFloat(ConstantStringManager.MonsterAnimatorParameters.IsInBattleState, 1f);
            State.isPatrolling = false;
        }
        if (State.isAttacking)
        {
            if (State.Attack1)
            {
                MonsterAnimator.SetTrigger(ConstantStringManager.MonsterAnimatorParameters.Attack1);
            }
            if (State.Attack2)
            {
                MonsterAnimator.SetTrigger(ConstantStringManager.MonsterAnimatorParameters.Attack2);
            }
            MonsterAnimator.SetTrigger(ConstantStringManager.MonsterAnimatorParameters.Attack);
            State.isAttacking = false;
        }
        if (State.isDead)
        {
            Debug.Log("est mort");
            MonsterAnimator.SetTrigger(ConstantStringManager.MonsterAnimatorParameters.IsDead);
            State.isDead = false;
            State.AlreadyDead = true;
        }
        //else
        //{
        //    MonsterAnimator.SetBool(ConstantStringManager.MonsterAnimatorParameters.IsDead, false);
        //}

        if (State.isHurt)
        {
            MonsterAnimator.SetTrigger(ConstantStringManager.MonsterAnimatorParameters.IsHurt);
            State.isHurt = false;
        }
    }

}

public struct StateStruct
{
    public bool isPatrolling;
    public bool isMovingToAttack;
    public bool isAttacking;
    public bool isDead;
    public bool isHurt;
    public bool isFreeze;
    public bool Attack1;
    public bool Attack2;
    public bool AlreadyDead;
}