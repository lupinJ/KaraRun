using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealPortion : Item
{
    [SerializeField]
    int heal;

    public override void ActiveItem(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player>().Hp += heal;
    }

    
}
