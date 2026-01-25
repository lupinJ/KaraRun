using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlideButtonUI : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    Player player;

    private bool isPressed = false;
    
    void Update()
    {
        if (isPressed)
        {
            player.PlayerLeanDown();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        player.PlayerLeanUp();
        isPressed = false;
    }
}
