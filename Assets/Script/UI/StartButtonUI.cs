using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonUI : UIBase
{
    public void StartButtonClicked()
    {
        GameManager.Instance.GameStart();
    }
}
