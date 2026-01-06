using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinUIControler : UIBase
{
    [SerializeField]
    TextMeshProUGUI coinText;
    
    private void Start()
    {
        EventManager.Instance.OnCoinChanged += SetCoinText;
    }
    void SetCoinText(int coin)
    {
        coinText.text = $"{coin}";
    }

    private void OnDisable()
    {
        if(EventManager.Instance != null)
        {
            EventManager.Instance.OnCoinChanged -= SetCoinText;
        }
    }
}
