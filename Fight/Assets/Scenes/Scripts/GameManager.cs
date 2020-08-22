using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject dropPoint;//X +- 8
    public GameObject coinPrefab;
    public float createTimer;
    public float minCreateTime;
    public float maxCreateTime;
    public float existTime;

    public Text coinScoreText;
    public Text timerText;
    [Header("ResultPanels")]
    public Text resultCoinText;
    public GameObject resultPanel;

    private float timer;
    private float timeCounterPeriod = 1f;
    private int totalTimer = 60;

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = totalTimer.ToString();
    }

    void FixedUpdate()
    {
        if (Convert.ToInt16(timerText.text)<=0)
        {
            return;
        }
        if (createTimer >= UnityEngine.Random.Range(minCreateTime,maxCreateTime))
        {
            Instantiate<GameObject>(coinPrefab, (Vector2)dropPoint.transform.position + UnityEngine.Random.Range(-8f, 8f) * Vector2.right, Quaternion.Euler(0, 0, 0));
            createTimer = 0;
        }
        if (timer >= timeCounterPeriod)
        {
            timerText.text = (Convert.ToSingle(timerText.text) - 1f).ToString();
            timer = 0;
            if (Convert.ToInt16(timerText.text)==0)
            {
                ShowResult();
            }
        }
        createTimer = createTimer + Time.deltaTime;
        timer = timer + Time.deltaTime;
    }

    public void AddScore()
    {
        coinScoreText.text = (Convert.ToSingle(coinScoreText.text) + 1f).ToString();
    }

    void ShowResult()
    {
        resultPanel.SetActive(true);
        resultCoinText.text = coinScoreText.text;
    }
}
