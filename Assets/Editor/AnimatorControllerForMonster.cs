using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class AnimatorControllerForMonster : MonoBehaviour
{
    [MenuItem("MyMenu/Create AnimatorControllerForMonster")]
    static void CreateController()
    {
        // Creates the controller
        var controller = AnimatorController.CreateAnimatorControllerAtPath($"Assets/{DateTime.Now.ToString("mmss")}.controller");

        // Add parameters
        controller.AddParameter(ConstantStringManager.MonsterAnimatorParameters.IsInBattleState, AnimatorControllerParameterType.Float);
        controller.AddParameter(ConstantStringManager.MonsterAnimatorParameters.IsDead, AnimatorControllerParameterType.Trigger);
        controller.AddParameter(ConstantStringManager.MonsterAnimatorParameters.IsHurt, AnimatorControllerParameterType.Trigger);
        controller.AddParameter(ConstantStringManager.MonsterAnimatorParameters.Attack, AnimatorControllerParameterType.Trigger);
        controller.AddParameter(ConstantStringManager.MonsterAnimatorParameters.Attack1, AnimatorControllerParameterType.Trigger);
        controller.AddParameter(ConstantStringManager.MonsterAnimatorParameters.Attack2, AnimatorControllerParameterType.Trigger);
        controller.AddParameter(ConstantStringManager.MonsterAnimatorParameters.Movementspeed, AnimatorControllerParameterType.Float);

        // Add StateMachines
        var rootStateMachine = controller.layers[0].stateMachine;

        //BlendTrees
        var blendTreeMovementState = controller.CreateBlendTreeInController("MovementBlendTree", out var blendTreeMovement, 0);
        blendTreeMovement.blendParameter = ConstantStringManager.MonsterAnimatorParameters.IsInBattleState;

        var PatrouilleBlendTree = blendTreeMovement.CreateBlendTreeChild(0);
        PatrouilleBlendTree.name = "PatrouilleBlendTree";
        PatrouilleBlendTree.children = new ChildMotion[2];
        PatrouilleBlendTree.blendParameter = ConstantStringManager.MonsterAnimatorParameters.Movementspeed;

        var AlerteBlendTree = blendTreeMovement.CreateBlendTreeChild(1);
        AlerteBlendTree.name = "AlerteBlendTree";
        AlerteBlendTree.children = new ChildMotion[2];
        AlerteBlendTree.blendParameter = ConstantStringManager.MonsterAnimatorParameters.Movementspeed;

        //Add StateMachine Attack
        var attackStateMachine = rootStateMachine.AddStateMachine(ConstantStringManager.MonsterAnimatorParameters.Attack);
        var defaultAttackState = attackStateMachine.AddState("Default");
        var attack1State = attackStateMachine.AddState("Attack1");
        var attack2State = attackStateMachine.AddState("Attack2");

        // Add States
        var hurtState = rootStateMachine.AddState("HurtState");
        var deadState = rootStateMachine.AddState("DeadState");

        // Add Transitions
        var toHurtTransition = rootStateMachine.AddAnyStateTransition(hurtState);
        hurtState.AddTransition(blendTreeMovementState);
        toHurtTransition.AddCondition(AnimatorConditionMode.If, 1, ConstantStringManager.MonsterAnimatorParameters.IsHurt);
        var toDeadTransition = rootStateMachine.AddAnyStateTransition(deadState);
        toDeadTransition.AddCondition(AnimatorConditionMode.If, 1, ConstantStringManager.MonsterAnimatorParameters.IsDead);

        var fromBlendTreeMovementStateToAttackSubState = blendTreeMovementState.AddTransition(attackStateMachine);
        fromBlendTreeMovementStateToAttackSubState.AddCondition(AnimatorConditionMode.If, 0,
            ConstantStringManager.MonsterAnimatorParameters.Attack);

        var fromDefaultToAttack1 = defaultAttackState.AddTransition(attack1State);
        fromDefaultToAttack1.AddCondition(AnimatorConditionMode.If,1,ConstantStringManager.MonsterAnimatorParameters.Attack1);
        attack1State.AddExitTransition();
        
        var fromDefaultToAttack2 = defaultAttackState.AddTransition(attack2State);
        fromDefaultToAttack2.AddCondition(AnimatorConditionMode.If, 1, ConstantStringManager.MonsterAnimatorParameters.Attack2);
        attack2State.AddExitTransition();

        //var exitTransition = stateA1.AddExitTransition();
        //exitTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "TransitionNow");
        //exitTransition.duration = 0;

        //var resetTransition = rootStateMachine.AddAnyStateTransition(stateA1);
        //resetTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "Reset");
        //resetTransition.duration = 0;

        //var transitionB1 = stateMachineB.AddEntryTransition(stateB1);
        //transitionB1.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "GotoB1");
        //stateMachineB.AddEntryTransition(stateB2);
        //stateMachineC.defaultState = stateC2;
        //var exitTransitionC2 = stateC2.AddExitTransition();
        //exitTransitionC2.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "TransitionNow");
        //exitTransitionC2.duration = 0;

        //var stateMachineTransition = rootStateMachine.AddStateMachineTransition(stateMachineA, stateMachineC);
        //stateMachineTransition.AddCondition(UnityEditor.Animations.AnimatorConditionMode.If, 0, "GotoC");
        //rootStateMachine.AddStateMachineTransition(stateMachineA, stateMachineB);

    }
}