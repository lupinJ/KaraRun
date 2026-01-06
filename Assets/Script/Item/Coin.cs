using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    [SerializeField]
    int coin;

    public override void ActiveItem(Collider2D collision)
    {
        GameManager.Instance.Coin += coin;
    }

}
