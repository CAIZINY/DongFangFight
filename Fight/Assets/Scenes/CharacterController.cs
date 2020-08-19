using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Tooltip("地面碰撞层")]public LayerMask groundLayer;
    [Tooltip("地面检测距离")] public float groundDetectedDistance;

    private bool m_CharacterGrounded = true;
    private PlayerInputCollection m_PlayerInput;
    private AnimatorStateParamsXiaoYe m_AnimatorParamsStates;
    private Animator m_Animator;

    void Awake()
    {
        m_PlayerInput = GetComponent<PlayerInputCollection>();
        m_AnimatorParamsStates = GetComponent<AnimatorStateParamsXiaoYe>();
        m_Animator = GetComponent<Animator>();
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
}
