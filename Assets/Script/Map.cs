using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    [SerializeField]
    float speed;
    Vector2 endPos;

    public float Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    private void Awake()
    {
        speed = 0;
        endPos = Vector2.zero;
    }

    public void Init(Vector2 pos, float speed)
    {
        endPos = pos;
        Speed = speed;
    }

    void Update()
    {
        if(isEndofMap())
        {
            GameManager.Instance.ChangeMap();
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.left * Time.fixedDeltaTime * Speed);
    }

    bool isEndofMap()
    {
        if(transform.position.x <= endPos.x)
            return true;
        return false;
    }
}
