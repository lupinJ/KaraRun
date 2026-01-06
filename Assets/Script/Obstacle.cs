using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    int atk;
    [SerializeField]
    int score;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            collision.GetComponent<Player>()?.Hit(atk);
        }

    }

    public void Break()
    {
        GameManager.Instance.Score += score;
        gameObject.SetActive(false);
    }

}
