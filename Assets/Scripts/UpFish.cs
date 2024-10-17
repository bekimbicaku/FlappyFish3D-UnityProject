using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class UpFish : MonoBehaviour
{
    [SerializeField] public float motorForce;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.up * motorForce * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "UpZone")
        {
            Destroy(gameObject);

        }
    }
}
