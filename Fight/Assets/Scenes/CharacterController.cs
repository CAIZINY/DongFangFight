using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Tooltip("地面碰撞层")]public LayerMask groundLayer;
    [Tooltip("地面检测距离")] public float groundDetectedDistance;

    private bool m_CharacterGrounded = true;
    private PlayerInputCollection m_PlayerInput;
    private Rigidbody2D m_Rigid2D;

    private AnimatorStateParamsXiaoYe m_AnimatorParamsStates;
    private Animator m_Animator;

    protected AnimatorStateInfo m_PreviousCurrentStateInfo;
    protected AnimatorStateInfo m_PreviousNextStateInfo;
    protected AnimatorStateInfo m_CurrentStateInfo;
    protected AnimatorStateInfo m_NextStateInfo;

    void Awake()
    {
        m_PlayerInput = GetComponent<PlayerInputCollection>();
        m_AnimatorParamsStates = GetComponent<AnimatorStateParamsXiaoYe>();
        m_Animator = GetComponent<Animator>();
        m_Rigid2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GroundedDetected();

        MoveCommandDetected();

        AttackCommandDetected();

        CacheAnimatorInfo();   
    }

    /// <summary>
    /// 检测和设置Move命名的值
    /// </summary>
    void MoveCommandDetected()
    {
        if (m_PlayerInput.movementCommand ==5)
        {
            m_Animator.SetBool(m_AnimatorParamsStates.m_HashParamsMoveCommandDetected, false);
        }
        else
        {
            m_Animator.SetBool(m_AnimatorParamsStates.m_HashParamsMoveCommandDetected, true);
            if (m_PlayerInput.moveDashCommand)
                m_Animator.SetBool(m_AnimatorParamsStates.m_HashParamsMoveDashCommand, true);
        }
        m_Animator.SetInteger(m_AnimatorParamsStates.m_HashParamsMoveCommand, m_PlayerInput.movementCommand);

    }

    void AttackCommandDetected()
    {
        if (m_PlayerInput.attackCommandType == -1)
        {
            m_Animator.SetBool(m_AnimatorParamsStates.m_HashParamsAttackCommandDetected, false);
        }
        else
        {
            m_Animator.SetBool(m_AnimatorParamsStates.m_HashParamsAttackCommandDetected, true);
        }
        m_Animator.SetInteger(m_AnimatorParamsStates.m_HashParamsAttackCommandType, m_PlayerInput.attackCommandType);
    }

    void GroundedDetected()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundDetectedDistance, groundLayer);
        Debug.DrawLine(transform.position, transform.position + Vector3.down* groundDetectedDistance, Color.red, 0.3f);
        m_Animator.SetBool(m_AnimatorParamsStates.m_HashParamsGrounded, (bool)hit);
    }

    void CacheAnimatorInfo()
    {
        m_PreviousCurrentStateInfo = m_CurrentStateInfo;
        m_PreviousNextStateInfo = m_NextStateInfo;

        m_CurrentStateInfo = m_Animator.GetCurrentAnimatorStateInfo(0);
        m_NextStateInfo = m_Animator.GetNextAnimatorStateInfo(0);
    }

    void OnAnimatorMove()
    {
        if(m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesWalkFront)
        {

        }
        if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesWalkBack)
        {

        }
    }
}
