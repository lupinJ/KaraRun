using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupUI : UIBase
{

    public virtual void ShowPanel() //UI를 켜는 함수
    {
        gameObject.SetActive(true);
    }

    public virtual void HidePanel()
    {
        gameObject.SetActive(false);
    }

    public virtual void SetPanel<T>(T data) 
    { }
}
