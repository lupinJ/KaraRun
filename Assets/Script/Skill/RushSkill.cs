using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushSkill : Skill
{
    [SerializeField]
    Player player;

    public override void Init()
    {
  
    }

    public override void SkillStart()
    {
        player.roket.SetActive(true);
        player.SkillActive(SkillName.Invincible, duration);
        player.SkillActive(SkillName.Breakable, duration);
        GameManager.Instance.Speed += speed;
    }

    public override void SkillEnd()
    {
        player.roket.SetActive(false);
        GameManager.Instance.Speed -= speed;
    }

    public override void SkillUpdate()
    {
        if(is_update)
        {
            player.SkillActive(SkillName.Invincible, duration);
            player.SkillActive(SkillName.Breakable, duration);
        }
    }
}
