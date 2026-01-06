using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillName : int
{
    Magnet = 0,
    Rush = 1,
    Breakable = 2,
    Invincible = 3
}
abstract public class Skill : MonoBehaviour
{

    [SerializeField]
    protected float speed;
    [SerializeField]
    public float duration;
    

    protected bool is_active;
    protected bool is_update;

    protected float leftTime;

    public IEnumerator timer;

    private void Awake()
    {
        is_active = false;
        leftTime = 0f;
        Init();
    }

    public virtual void Active()
    {
        if (leftTime > duration)
            return;

        if (timer != null)
        {
            leftTime = duration;
            is_update = true;
            return;
        }

        leftTime = duration;
        timer = DurationTimer();
        StartCoroutine(timer);
    }

    public void InActive()
    {
        leftTime = 0;
        is_active = false;
        timer = null;
    }

    IEnumerator DurationTimer()
    {
        is_active = true;
        SkillStart();

        while (true)
        {
            if (leftTime <= 0)
                break;

            SkillUpdate();
            leftTime -= Time.deltaTime;
            yield return null;
        }

        InActive();
        SkillEnd();
    }

    abstract public void Init();
    abstract public void SkillStart();
    abstract public void SkillUpdate();
    abstract public void SkillEnd();
    
}
