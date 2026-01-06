using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class SkillFruit : Fruit
{
    public abstract override void ActiveSkill(Collider2D collision);
}
