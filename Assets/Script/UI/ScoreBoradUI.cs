using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoradUI : PopupUI
{
    [SerializeField]
    TextMeshProUGUI[] text;

    public override void SetPanel<T>(T data) 
    {
        List<int> list = data as List<int>;

        if (list == null)
        {
            Debug.Log("SetPanelError (not List<int> in Paremeter");
            return;
        }

        int length = list.Count > 4 ? 4 : list.Count;

        for (int i=0; i < length; i++)
        {
            text[i].text = $"{i + 1}. {list[i]}";
        }
    }

}
