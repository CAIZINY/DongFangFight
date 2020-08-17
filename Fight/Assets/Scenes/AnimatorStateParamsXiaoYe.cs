using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateParamsXiaoYe : MonoBehaviour
{
    //params
    public readonly int m_HashParamsMoveCommand = Animator.StringToHash("MoveCommand");
    public readonly int m_HashParamsMoveCommandDetected = Animator.StringToHash("MoveCommandDetected");
    public readonly int m_HashParamsMoveDashCommand = Animator.StringToHash("MoveDashCommand");

    //states
    public readonly int m_HashStatesIdle0 = Animator.StringToHash("Idle0");
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
