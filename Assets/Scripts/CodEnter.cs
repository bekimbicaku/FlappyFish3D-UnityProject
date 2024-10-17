using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CodEnter : MonoBehaviour
{
    public GameObject firstplayer;
    //public GameObject player;
    //public GameObject player2;

    
    public GameObject panel;
    public GameObject panel2;

    public string Untagged;

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            this.transform.position = this.transform.position + new Vector3(0f, 0f, 0f);
            SoundManagerScript.PlaySound("crash");
            //player.SetActive(false);
           // player2.SetActive(true);
            StartCoroutine(respawnMenu());
            firstplayer.tag = Untagged;
        }
        if(other.tag == "Bobi")
        {
            Destroy(gameObject);
        }
    }


    IEnumerator respawnMenu()
    {
        yield return new WaitForSeconds(2f);
        panel.SetActive(false);
        panel2.SetActive(true);
        

    }
   


}
