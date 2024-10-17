using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackWallScript : MonoBehaviour
{
    public GameObject wall;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(wall);
        }
    }
}
