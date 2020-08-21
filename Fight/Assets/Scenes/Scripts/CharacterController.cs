using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Tooltip("地面碰撞层")]public LayerMask groundLayer;
    [Tooltip("地面检测距离")] public float groundDetectedDistance;
    [Tooltip("水平方向移动速度")] public float horizontalSpeed;
    [Tooltip("竖直方向跳跃力")] public float verticalSpeed;

    [Header("垂直跳跃")]
    [Tooltip("竖直方向跳跃")] public float jumpSpeedScale;
    //[Tooltip("竖直方向的时间")] public float jumpUpTime;
    //[Tooltip("普通跳跃竖直方向高度")] public float jumpUpNormalHeight;
    //[Tooltip("强力跳跃竖直方向高度")] public float jumpUpHighHeight;


    private bool m_CharacterGrounded = true;
    private PlayerInputCollection m_PlayerInput;
    private Rigidbody2D m_Rigid2D;
    private Vector2 m_Rigid2DSpeed;

    private AnimatorStateParamsXiaoYe m_AnimatorParamsStates;
    private Animator m_Animator;

    private CharacterXiaoYeBulletAttackSystem attackSystem;

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
        attackSystem = GetComponent<CharacterXiaoYeBulletAttackSystem>();
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

        MoveCommandReact();
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

    void MoveCommandReact()
    {
        if(m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesWalkFront)
        {
            m_Rigid2D.velocity = Vector2.right * horizontalSpeed;
            return;
        }
        if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesWalkBack)
        {
            m_Rigid2D.velocity = Vector2.left * horizontalSpeed;
            return;
        }
        if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesJumpUpReady)
        {
            if(m_CurrentStateInfo.normalizedTime>0.8f)
            {
                m_Rigid2D.velocity = Vector2.up * -Physics2D.gravity * jumpSpeedScale;
                m_Animator.SetFloat(m_AnimatorParamsStates.m_HashParamsVerticalSpeed, m_Rigid2D.velocity.y);
            }
            return;
        }
        if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesJumpUpRaising)
        {
            m_Animator.SetFloat(m_AnimatorParamsStates.m_HashParamsVerticalSpeed, m_Rigid2D.velocity.y);
            return;
        }
        if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesJumpUpDrop)
        {
            m_Animator.SetFloat(m_AnimatorParamsStates.m_HashParamsVerticalSpeed, m_Rigid2D.velocity.y);
            return;
        }
        if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesJumpUpDroping)
        {
            m_Animator.SetFloat(m_AnimatorParamsStates.m_HashParamsVerticalSpeed, m_Rigid2D.velocity.y);
            return;
        }
        /*
              if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesJumpUpStartRaising)
              {
                  m_Rigid2D.velocity = Vector2.up * verticalSpeed;
                  return;
              }

              if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesJumpUpRaising)
              {

                  m_Rigid2D.velocity = Vector2.up * verticalSpeed;
                  return;
              }

               if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesJumpUpStartDorping)
               {
                   m_Rigid2D.velocity = Vector2.down * verticalSpeed;
                   return;
               }
               if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesJumpUpDroping)
               {
                   m_Rigid2D.velocity = Vector2.down * verticalSpeed;
                   return;
               }

             if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesAttackBcEnding)
             {
                 m_Rigid2D.velocity = Vector2.down * verticalSpeed;
                 return;
             }
             if (m_CurrentStateInfo.shortNameHash == m_AnimatorParamsStates.m_HashStatesAttackBcCast)
             {

                 return;
             }
             */
        m_Rigid2D.velocity = Vector2.zero;
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
            attackSystem.Attack5B();
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

}
