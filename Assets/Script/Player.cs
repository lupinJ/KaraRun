using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    SpriteRenderer sprite;

    [SerializeField]
    Skill[] skills;

    [SerializeField]
    public GameObject roket;

    int jumpForce;
    int jumpCount;
    int jumpCountMax;

    [SerializeField]
    int hp;
    int maxHp;

    float demegedTime; // 발동주기
    float dTime; // update() 루프용
    int demege; // 데미지량

    bool is_pause;
    bool is_ground;
    bool is_lean;
    bool is_Invincible;
    bool is_breakable;
    bool is_growth;
    bool is_dead;

    float growthTime; // 발동 시간
    float growthDuration; // 지속 시간

    public int Hp
    {
        get { return hp; }
        set 
        {
            hp = value;
            if (hp > maxHp)
                hp = maxHp;
            if (hp <= 0)
                hp = 0;

            EventManager.Instance.HpChanged(maxHp, hp);

            if(hp == 0 && !is_dead)
                Die();
        }
    }
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        jumpForce = 11;
        jumpCount = 0;
        jumpCountMax = 2;

        maxHp = 100;
        demege = 1;
        demegedTime = 2;
        dTime = 0;

        is_pause = false;
        is_ground = true;
        is_lean = false;
        is_Invincible = false;
        is_breakable = false;
        is_growth = false;
        is_dead = false;

        growthTime = 0.5f;
        growthDuration = 5.0f;
    }

    private void Start()
    {
        Hp = maxHp;
    }

    void Update()
    {
        if (is_pause || is_dead)
            return;

        if (dTime >= demegedTime)
        {
            Hp -= demege;
            dTime = 0;
        }
        dTime += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            if (jumpCount < jumpCountMax)
                Jump();
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (is_ground && !is_lean && !is_growth)
                LeanDown();

        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if(is_ground && !is_growth)
                LeanUp();
        }

        // 착지 확인
        if(rigid.velocity.y < 0)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, LayerMask.GetMask("Floor"));

            if (hit.collider != null)
            {
                is_ground = true;
                jumpCount = 0;
                
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
 
        if(is_breakable && collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Obstacle obstacle = collision.gameObject.GetComponent<Obstacle>();
            if (obstacle == null)
                obstacle = collision.transform.parent.gameObject.GetComponent<Obstacle>();

            obstacle.Break();

        }
    }

    public void Pause(bool pause)
    {
        is_pause = pause;
        gameObject.GetComponent<BoxCollider2D>().enabled = !is_pause;
        rigid.gravityScale = is_pause ? 0f : 3f;
    }
    void Jump()
    {
        if (is_lean)
            LeanUp();
        
        SoundManager.Instance.Play("Jump");
        is_ground = false;
        jumpCount++;
        rigid.velocity = Vector3.zero;
        rigid.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void LeanDown()
    {
        is_lean = true;
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y/2);
    }

    void LeanUp()
    {
        is_lean = false;
        transform.localScale = new Vector2(transform.localScale.x, transform.localScale.y * 2);
    }

    void Die()
    {
        is_dead = true;
        sprite.flipY = true;
        transform.Translate(Vector2.up);
        EventManager.Instance.PlayerDie();
    }

    public void Hit(int atk)
    {
        if (is_Invincible)
            return;
        Hp -= atk;

        SkillActive(SkillName.Invincible, 1.0f);
    }

    public void SetInvincible(bool select)
    {
        is_Invincible = select;
    }

    public void SetBreakable(bool select)
    {
        is_breakable = select;
    }
    public void SkillActive(SkillName index)
    {
        skills[(int)index].Active();
    }

    public void SkillActive(SkillName index, float time)
    {
        skills[(int)index].duration = time;
        SkillActive(index);
    }
    public void ActiveGrowth()
    {
        StartCoroutine(Growth());
    }

    IEnumerator Growth()
    {
        float time = 0f;
        Vector2 start = new Vector2(1, 1);
        Vector2 end = new Vector2(3, 3);

        SkillActive(SkillName.Invincible, growthDuration);
        SkillActive(SkillName.Breakable, growthDuration);
        
        is_growth = true;
        while (time < growthTime)
        {
            time += Time.deltaTime;
            float t = time / growthTime;
        
            transform.localScale = Vector2.Lerp(start, end, t);

            yield return null; 
        }
        is_growth = false;

        if (is_lean)
            LeanDown();

        yield return new WaitForSeconds(growthDuration - 2 * growthTime);

        time = 0f;
        is_growth = true;
        while (time < growthTime)
        {
            time += Time.deltaTime;      
            float t = time / growthTime;

            transform.localScale = Vector2.Lerp(end, start, t);

            yield return null; 
        }
        is_growth = false;

        if (is_lean)
            LeanDown();
       
    }

}
