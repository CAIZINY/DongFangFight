using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeController : MonoBehaviour
{
    public float speed;
    public AnimationCurve bulletTrack;
    

    private Rigidbody2D m_Rigidbody2D;
    private float existTime;

    void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        m_Rigidbody2D.velocity = Vector2.right * speed;
    }

    void Update()
    {
        existTime = existTime + Time.deltaTime;
        transform.localPosition = new Vector2(transform.localPosition.x,bulletTrack.Evaluate(existTime));
    }
}
