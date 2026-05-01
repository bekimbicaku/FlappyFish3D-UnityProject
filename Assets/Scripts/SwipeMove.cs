using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour
{
    public GameObject player;
    private Transform playerTransform;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Awake()
    {
        playerTransform = player.transform;
    }

    private void Update()
    {
        if (Input.touchCount <= 0)
        {
            return;
        }

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            startTouchPosition = touch.position;
        }
        if (touch.phase == TouchPhase.Ended)
        {
            endTouchPosition = touch.position;
            if (endTouchPosition.x < startTouchPosition.x)
            {
                Right();
            }
            if (endTouchPosition.x > startTouchPosition.x)
            {
                Left();
            }
        }

    }
    private void Left()
    {
        SoundManagerScript.PlaySound("swipe");
        playerTransform.position = new Vector3(playerTransform.position.x + 2, playerTransform.position.y, playerTransform.position.z - 1);

    }
    private void Right()
    {
        SoundManagerScript.PlaySound("swipe");
        playerTransform.position = new Vector3(playerTransform.position.x - 2, playerTransform.position.y, playerTransform.position.z - 1);
    }
}
