using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterXiaoYeBulletAttackSystem : MonoBehaviour
{
    public GameObject bullet;
    public GameObject startPoint;


    public void Attack5B()
    {
        Instantiate<GameObject>(bullet,startPoint.transform.position,Quaternion.Euler(0,0,0));
    }
}
