using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class UpFish : MonoBehaviour
{
    [SerializeField] public float motorForce;
    private Rigidbody cachedRigidbody;

    void Awake()
    {
        cachedRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        cachedRigidbody.AddForce(Vector3.up * motorForce * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UpZone"))
        {
            Destroy(gameObject);

        }
    }
}
