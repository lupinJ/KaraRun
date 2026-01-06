using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBarUIControler : UIBase
{
    Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();
        EventManager.Instance.OnHpChanged += SetHpBar;
    }

    void SetHpBar(int maxHp, int hp)
    {
        slider.value = (float)hp / maxHp;
    }

    private void OnDisable()
    {
        if (EventManager.Instance != null)
        {
            EventManager.Instance.OnHpChanged -= SetHpBar;
        }
    }
}
