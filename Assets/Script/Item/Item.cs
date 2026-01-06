using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Item : MonoBehaviour
{
    [SerializeField]
    protected SpriteRenderer sprite;

    abstract public void ActiveItem(Collider2D collision);

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            ActiveItem(collision);
            gameObject.SetActive(false);
        }
    }

}
