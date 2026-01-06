using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButtonUI : MonoBehaviour
{
    public void ButtonClicked()
    {
        GameManager.Instance.Pause();
    }

}
