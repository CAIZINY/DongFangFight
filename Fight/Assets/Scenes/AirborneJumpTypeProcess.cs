using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneJumpTypeProcess : StateMachineBehaviour
{
    //params
    readonly int m_HashParamsAirborneJumpType = Animator.StringToHash("AirborneJumpType");

    //states
    readonly int m_HashStatesIdle0 = Animator.StringToHash("Idle0");//AirborneJumpType = 2
    readonly int m_HashStatesDashFrontStart = Animator.StringToHash("DashFrontStart");//AirborneJumpType=668
    readonly int m_HashStatesDashFrontDashing = Animator.StringToHash("DashFrontDashing");//AirborneJumpType=668
    readonly int m_HashStatesDashFrontEnd = Animator.StringToHash("DashFrontEnd");//AirborneJumpType=668
    readonly int m_HashStatesWalkFront = Animator.StringToHash("WalkFront");//AirborneJumpType = 9
    readonly int m_HashStatesWalkBack = Animator.StringToHash("WalkBack");//AirborneJumpType = 7
    readonly int m_HashStatesSitUp = Animator.StringToHash("SitUp");//AirborneJumpType = 28
    readonly int m_HashStatesSitting = Animator.StringToHash("Sitting");//AirborneJumpType = 28
    readonly int m_HashStatesSitDown = Animator.StringToHash("SitDown");//AirborneJumpType = 28

    //float lastStateTime;//上一个动画状态d的
    //float lastStateTimePerido;
    //AnimatorStateInfo lastStateInfo;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log(m_HashStatesIdle0 + "Idle0");
        Debug.Log(stateInfo.shortNameHash + "Current");
        if (stateInfo.shortNameHash == m_HashStatesIdle0)
        {
            animator.SetInteger(m_HashParamsAirborneJumpType, 2);
        }
        if (stateInfo.shortNameHash == m_HashStatesDashFrontStart)
        {
            animator.SetInteger(m_HashParamsAirborneJumpType, 668);
        }
        if (stateInfo.shortNameHash == m_HashStatesDashFrontDashing)
        {
            animator.SetInteger(m_HashParamsAirborneJumpType, 668);
        }
        if (stateInfo.shortNameHash == m_HashStatesDashFrontEnd)
        {
            animator.SetInteger(m_HashParamsAirborneJumpType, 668);
        }
        if (stateInfo.shortNameHash == m_HashStatesWalkFront)
        {
            Debug.Log(9);
            animator.SetInteger(m_HashParamsAirborneJumpType, 9);
        }
        if (stateInfo.shortNameHash == m_HashStatesWalkBack)
        {
            animator.SetInteger(m_HashParamsAirborneJumpType, 7);
        }
        if (stateInfo.shortNameHash == m_HashStatesSitUp)
        {
            animator.SetInteger(m_HashParamsAirborneJumpType, 28);
        }
        if (stateInfo.shortNameHash == m_HashStatesSitting)
        {
            animator.SetInteger(m_HashParamsAirborneJumpType, 28);
        }
        if (stateInfo.shortNameHash == m_HashStatesSitDown)
        {
            animator.SetInteger(m_HashParamsAirborneJumpType, 28);
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
