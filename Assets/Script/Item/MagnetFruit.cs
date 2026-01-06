using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetFruit : SkillFruit
{
    public override void ActiveSkill(Collider2D collision)
    {
        collision.gameObject.GetComponent<Player>().SkillActive(SkillName.Magnet);
    }

    
}
