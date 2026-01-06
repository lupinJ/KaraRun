using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Item
{
    [SerializeField]
    protected int score;
   
    public override void ActiveItem(Collider2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        GameManager.Instance.Score += score;
        ActiveSkill(collision);
    }

    public virtual void ActiveSkill(Collider2D collision) { }
}
