using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuitButtonUI : UIBase
{
    public void QuitButtonClicked()
    {
        Application.Quit();
    }
}
