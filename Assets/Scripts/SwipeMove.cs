using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour
{
    public GameObject player;
    private Vector2 startTouchPosition;
    private Vector2 endTouchPosition;

    private void Update()
    {
        if(Input.touchCount > 0.9 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0.9 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            endTouchPosition = Input.GetTouch(0).position;
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
        player.transform.position = new Vector3(player.transform.position.x + 2, player.transform.position.y, player.transform.position.z - 1);

    }
    private void Right()
    {
        SoundManagerScript.PlaySound("swipe");
        player.transform.position = new Vector3(player.transform.position.x - 2, player.transform.position.y, player.transform.position.z - 1);
    }
}
