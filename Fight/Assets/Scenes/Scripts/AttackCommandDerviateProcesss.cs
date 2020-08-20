using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommandDerviateProcesss : StateMachineBehaviour
{
    //params
    readonly int m_HashParamsAttackCommandDerivateState = Animator.StringToHash("AttackCommandDerivateState");

    //states
    readonly int m_HashStatesIdle0 = Animator.StringToHash("Idle0");//AttackCommandDerivateState = 5
    readonly int m_HashStatesDashFrontStart = Animator.StringToHash("DashFrontStart");//AttackCommandDerivateState = 66
    readonly int m_HashStatesDashFrontDashing = Animator.StringToHash("DashFrontDashing");//AttackCommandDerivateState = 66
    readonly int m_HashStatesDashFrontEnd = Animator.StringToHash("DashFrontEnd");//AttackCommandDerivateState = 66
    readonly int m_HashStatesWalkFront = Animator.StringToHash("WalkFront");//AttackCommandDerivateState = 6
    readonly int m_HashStatesWalkBack = Animator.StringToHash("WalkBack");//AttackCommandDerivateState = 4
    readonly int m_HashStatesSitUp = Animator.StringToHash("SitUp");//AttackCommandDerivateState = 2
    readonly int m_HashStatesSitting = Animator.StringToHash("Sitting");//AttackCommandDerivateState = 2
    readonly int m_HashStatesSitDown = Animator.StringToHash("SitDown");//AttackCommandDerivateState = 2

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.shortNameHash == m_HashStatesIdle0)
        {
            animator.SetInteger(m_HashParamsAttackCommandDerivateState, 5);
        }
        if (stateInfo.shortNameHash == m_HashStatesDashFrontStart)
        {
            animator.SetInteger(m_HashParamsAttackCommandDerivateState, 66);
        }
        if (stateInfo.shortNameHash == m_HashStatesDashFrontDashing)
        {
            animator.SetInteger(m_HashParamsAttackCommandDerivateState, 66);
        }
        if (stateInfo.shortNameHash == m_HashStatesDashFrontEnd)
        {
            animator.SetInteger(m_HashParamsAttackCommandDerivateState, 66);
        }
        if (stateInfo.shortNameHash == m_HashStatesWalkFront)
        {
            animator.SetInteger(m_HashParamsAttackCommandDerivateState, 6);
        }
        if (stateInfo.shortNameHash == m_HashStatesWalkBack)
        {
            animator.SetInteger(m_HashParamsAttackCommandDerivateState, 4);
        }
        if (stateInfo.shortNameHash == m_HashStatesSitUp)
        {
            animator.SetInteger(m_HashParamsAttackCommandDerivateState, 2);
        }
        if (stateInfo.shortNameHash == m_HashStatesSitting)
        {
            animator.SetInteger(m_HashParamsAttackCommandDerivateState, 2);
        }
        if (stateInfo.shortNameHash == m_HashStatesSitDown)
        {
            animator.SetInteger(m_HashParamsAttackCommandDerivateState, 2);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
