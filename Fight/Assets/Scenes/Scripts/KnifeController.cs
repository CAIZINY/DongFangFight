using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public float speedScale;
    public float existTime;

    [Header("XY速度")]
    public bool constantXVelocity;
    public AnimationCurve bulletXVelocity;

    public bool constantYVelocity;
    public AnimationCurve bulletYVelocity;

    [HideInInspector]
    public GameObject creator;

    private float timer;
    private Rigidbody2D m_Rigidbody2D;

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        m_Rigidbody2D.velocity = new Vector2(bulletXVelocity.Evaluate(0), bulletYVelocity.Evaluate(0))*5;
    }

    void FixedUpdate()
    {
        timer = timer + Time.deltaTime;
        if (!constantXVelocity)
        {
            m_Rigidbody2D.velocity = new Vector2(bulletXVelocity.Evaluate(timer), bulletYVelocity.Evaluate(0))*5;
        }
        if (!constantYVelocity)
        {
            m_Rigidbody2D.velocity = new Vector2(bulletXVelocity.Evaluate(0), bulletYVelocity.Evaluate(timer))*5;
        }
        if (timer>=existTime)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == creator)
        {
            print("hit");
            return;
        }
           
        if (collision.tag == "Player")
        {

        }
    }
}
