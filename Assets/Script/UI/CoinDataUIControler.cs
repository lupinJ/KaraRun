using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinDataUIControler : PopupUI
{
    [SerializeField]
    TextMeshProUGUI coinText;

    public override void SetPanel<T>(T data) 
    {
        coinText.text = $"{data}";
    }


}
