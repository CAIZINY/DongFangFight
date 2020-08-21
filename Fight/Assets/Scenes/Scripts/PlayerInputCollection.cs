using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputCollection : MonoBehaviour
{
    
    [Tooltip("默认为5，表示站直的状态")]public int movementCommand = 5;
    [Tooltip("移动命令检测，不要修改")] public bool movementCommandDetected = false;
    [Tooltip("移动冲刺命令检测，不要修改")] public bool moveDashCommand = false;
    [Tooltip("攻击命令检测，不要修改")] public bool attackCommandDetected = false;
    [Tooltip("攻击命令，默认为-1，0对应A，1对应B")] public int attackCommandType = -1;

    private bool upInput = false;
    private bool downInput = false;
    private bool leftInput = false;
    private bool rightInput = false;
    private bool upInputLastPeriod = false;//用来判断Dash的模块
    private bool downInputLastPeriod = false;
    private bool leftInputLastPeriod = false;
    private bool rightInputLastPeriod = false;
    private bool reverseInput = false;

    private AnimatorStateParamsXiaoYe animatorStateParamsXiaoYe;

    void Awake()
    {
        animatorStateParamsXiaoYe = GetComponent<AnimatorStateParamsXiaoYe>();
    }

    void Update()
    {

    }

    public void UpInput(InputAction.CallbackContext context)
    {
        upInput = !upInput;
        MovementCommandProcessor();
    }
    public void DownInput(InputAction.CallbackContext context)
    {
        downInput = !downInput;
        MovementCommandProcessor();
    }
    public void LeftInput(InputAction.CallbackContext context)
    {
        leftInput = !leftInput;
        MovementCommandProcessor();
    }
    public void RightInput(InputAction.CallbackContext context)
    {
        rightInput = !rightInput;
        MovementCommandProcessor();
    }

    /// <summary>
    /// 每帧调用，用来分析玩家的输入情况，然后赋值给movementCommand
    /// </summary>
    private void MovementCommandProcessor()
    {
        if(upInput)
        {
            if (leftInput)
            {
                movementCommand = 7;
                CacheLastFrameMovementCommand();
                movementCommandDetected = true;
                return;
            }
            if (rightInput)
            {
                movementCommand = 9;
                CacheLastFrameMovementCommand();
                movementCommandDetected = true;
                return;
            }
            movementCommand = 8;
            CacheLastFrameMovementCommand();
            movementCommandDetected = true;
            return;
        }
        if (downInput)
        {
            if (leftInput)
            {
                movementCommand = 1;
                CacheLastFrameMovementCommand();
                movementCommandDetected = true;
                return;
            }
            if (rightInput)
            {
                movementCommand = 3;
                CacheLastFrameMovementCommand();
                movementCommandDetected = true;
                return;
            }
            if(upInput)
            {
                movementCommand = 8;
                CacheLastFrameMovementCommand();
                movementCommandDetected = true;
                return;
            }
            movementCommand = 2;
            CacheLastFrameMovementCommand();
            movementCommandDetected = true;
            return;
        }
        if (leftInput)
        {
            if (!rightInput)
            {
                movementCommand = 4;
                CacheLastFrameMovementCommand();
                movementCommandDetected = true;
                return;
            }
        }
        if (rightInput)
        {
            if (!leftInput)
            {
                movementCommand = 6;
                CacheLastFrameMovementCommand();
                movementCommandDetected = true;
                return;
            }
        }
        movementCommand = 5;
        movementCommandDetected = false;
    }

    public void DashCommand(InputAction.CallbackContext context)
    {
        if (movementCommand == 5)//没有处于移动命令退出检测Dash
            return;
        if (moveDashCommand)
        {
            moveDashCommand = false;
        }
        else
        {
            moveDashCommand = true;
        }
    }

    public void AttackACommand(InputAction.CallbackContext context)
    {
        if(attackCommandDetected)
        {
            attackCommandDetected = false;
            attackCommandType = -1;
            return;
        }
        else
        {
            attackCommandDetected = true;
            attackCommandType = 0;
        }
    }
    public void AttackBCommand(InputAction.CallbackContext context)
    {
        if (attackCommandDetected)
        {
            attackCommandDetected = false;
            attackCommandType = -1;
            return;
        }
        else
        {
            attackCommandDetected = true;
            attackCommandType = 1;
        }
    }
    public void AttackCCommand(InputAction.CallbackContext context)
    {
        if (attackCommandDetected)
        {
            attackCommandDetected = false;
            attackCommandType = -1;
            return;
        }
        else
        {
            attackCommandDetected = true;
            attackCommandType = 2;
        }
    }

    void CacheLastFrameMovementCommand()
    {
        leftInputLastPeriod = leftInput;
        rightInputLastPeriod = rightInput;
        downInputLastPeriod = downInput;
        upInputLastPeriod = upInput;

    }
}
