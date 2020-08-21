using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public float speedScale;
    [Header("速度控制")]
    public bool constantXVelocity;
    public AnimationCurve bulletXVelocity;
    public bool constantYVelocity;
    public AnimationCurve bulletYVelocity;
    

    private Rigidbody2D m_Rigidbody2D;
    private float timer;
    private float destoryTime = 5f;

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

    }

    void Start()
    {
        m_Rigidbody2D.velocity = new Vector2(bulletXVelocity.Evaluate(0), bulletYVelocity.Evaluate(0))* speedScale;
    }

    void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        if (!constantXVelocity)
        {
            m_Rigidbody2D.velocity = new Vector2(bulletXVelocity.Evaluate(timer), m_Rigidbody2D.velocity.y) * speedScale;
        }
        if(!constantYVelocity)
        {
            m_Rigidbody2D.velocity = new Vector2(m_Rigidbody2D.velocity.x, bulletYVelocity.Evaluate(timer)) * speedScale;
        }
        if (timer>= destoryTime)
        {
            Destroy(gameObject);
        }
    }
}
