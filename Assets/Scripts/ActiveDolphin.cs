using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveDolphin : MonoBehaviour
{
    public GameObject Dolphin;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Dolphin.SetActive(true);
            StartCoroutine(respawnMenu());
        }
    }
    IEnumerator respawnMenu()
    {
        yield return new WaitForSeconds(2f);

        Dolphin.GetComponent<Animator>().Play("OpenMouth");
        Dolphin.GetComponent<Animator>().Play("OpenMouth2");

    }
}
