using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincible : Skill
{
    [SerializeField]
    Player player;

    public override void Init()
    {
        
    }

    public override void SkillEnd()
    {
        player.SetInvincible(false);
    }

    public override void SkillStart()
    {
        player.SetInvincible(true);
    }

    public override void SkillUpdate()
    {
        
    }
}
