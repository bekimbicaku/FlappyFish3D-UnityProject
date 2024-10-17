using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveIce : MonoBehaviour
{
    public GameObject ice;

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {

            ice.SetActive(true);

        }
    }
}
