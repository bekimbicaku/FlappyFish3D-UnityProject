using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class DelfinSpeed : MonoBehaviour
{
    [SerializeField] public float motorForce;
    public GameObject playerBody;
    public GameObject panel;
    public GameObject panel2;

    public GameObject player;

    public string Tagged;
    public string Untagged;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().AddForce(Vector3.forward * motorForce * Time.deltaTime);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerBody.SetActive(false);
            StartCoroutine(respawnMenu());
            player.tag = Untagged;

        }
    }
    IEnumerator respawnMenu()
    {
        yield return new WaitForSeconds(3f);
        panel.SetActive(false);
        panel2.SetActive(true);
        //player.tag = Tagged;


    }
}
