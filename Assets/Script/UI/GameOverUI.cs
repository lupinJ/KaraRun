using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : PopupUI
{
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI CoinText;
    [SerializeField] Button[] buttons;

    private void OnEnable()
    {
        scoreText.text = $"{GameManager.Instance.Score}";
        CoinText.text = $"{GameManager.Instance.Coin}";
    }
    public void OnReGameButtonClicked()
    {
        GameManager.Instance.ReStart();
    }

    public void OnBackButtonClicked()
    {
        GameManager.Instance.GameEnd();
    }
}
