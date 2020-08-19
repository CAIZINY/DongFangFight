using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateParamsXiaoYe : MonoBehaviour
{
    //params
    public readonly int m_HashParamsMoveCommand = Animator.StringToHash("MoveCommand");
    public readonly int m_HashParamsMoveCommandDetected = Animator.StringToHash("MoveCommandDetected");
    public readonly int m_HashParamsMoveDashCommand = Animator.StringToHash("MoveDashCommand");
    public readonly int m_HashParamsAttackCommandDetected = Animator.StringToHash("AttackCommandDetected");
    public readonly int m_HashParamsAttackCommandType = Animator.StringToHash("AttackCommandType");
    public readonly int m_HashParamsGrounded = Animator.StringToHash("Grounded");

    //states
    public readonly int m_HashStatesIdle0 = Animator.StringToHash("Idle0");//AttackCommandDerivateState = 5
    public readonly int m_HashStatesDashFrontStart = Animator.StringToHash("DashFrontStart");//AttackCommandDerivateState = 66
    public readonly int m_HashStatesDashFrontDashing = Animator.StringToHash("DashFrontDashing");//AttackCommandDerivateState = 66
    public readonly int m_HashStatesDashFrontEnd = Animator.StringToHash("DashFrontEnd");//AttackCommandDerivateState = 66
    public readonly int m_HashStatesWalkFront = Animator.StringToHash("WalkFront");//AttackCommandDerivateState = 6
    public readonly int m_HashStatesWalkBack = Animator.StringToHash("WalkBack");//AttackCommandDerivateState = 4
    public readonly int m_HashStatesSitUp = Animator.StringToHash("SitUp");//AttackCommandDerivateState = 2
    public readonly int m_HashStatesSitting = Animator.StringToHash("Sitting");//AttackCommandDerivateState = 2
    public readonly int m_HashStatesSitDown = Animator.StringToHash("SitDown");//AttackCommandDerivateState = 2
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
