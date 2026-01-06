using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class JewelDataUIControler : PopupUI
{
    [SerializeField]
    TextMeshProUGUI text;

    public override void SetPanel<T>(T data)
    {
        text.text = $"{data}";
    }
}
