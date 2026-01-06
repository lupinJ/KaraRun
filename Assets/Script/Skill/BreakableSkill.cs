using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableSkill : Skill
{
    [SerializeField]
    Player player;

    public override void Init()
    {
       
    }

    public override void SkillEnd()
    {
        player.SetBreakable(false);
    }

    public override void SkillStart()
    {
        player.SetBreakable(true);
    }

    public override void SkillUpdate()
    {
        
    }
}
