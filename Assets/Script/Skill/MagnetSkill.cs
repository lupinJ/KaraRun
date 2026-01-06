using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetSkill : Skill
{

    public override void Init()
    {
        
    }

    public override void SkillEnd()
    {
        
    }

    public override void SkillStart()
    {
        
    }

    public override void SkillUpdate()
    {
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!is_active)
            return;

        if(collision.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            GameObject obj = collision.gameObject;
            Vector2 dir = transform.position - obj.transform.position;
            dir.Normalize();
            obj.transform.Translate(dir * Time.deltaTime * speed);
        }
    }


}
