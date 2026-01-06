using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreUIControler : UIBase
{
    [SerializeField]
    TextMeshProUGUI scoreText;

    private void Start()
    {
        EventManager.Instance.OnScoreChanged += SetScoreText;
    }
    void SetScoreText(int score)
    {
        scoreText.text = $"{score}";
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.OnScoreChanged -= SetScoreText;
        }
    }
}
