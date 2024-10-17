using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CollidEnter : MonoBehaviour
{
    public GameObject player;
    public GameObject player2;
    public GameObject text;
    public GameObject mainMenu;
    public GameObject panel2;

    float currentTime = 0f;
    float startingTime = 8f;

   


    [SerializeField] TextMeshProUGUI countdownText;

    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        countdownText.text = currentTime.ToString("Go Down Immediately   0.00");
        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           
            SoundManagerScript.PlaySound("water");
            text.SetActive(true);

        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            currentTime -= 1 * Time.deltaTime;
            

            text.SetActive(true);
            StartCoroutine(DestPlayer());
                //Destroy(player);
            StartCoroutine(MyCoroutine2());
            StartCoroutine(loadMenu());

           


        }
        

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            currentTime = startingTime;
            SoundManagerScript.PlaySound("water");
            text.SetActive(false);
            StopAllCoroutines();
        }
    }

    //IEnumerator MyCoroutine()
    //{
    // yield return new WaitForSeconds(5f);
    //player.SetActive(false);

    //}
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator loadMenu()
    {
        yield return new WaitForSeconds(6f);
        panel2.SetActive(true);
    }
    IEnumerator DestPlayer()
    {
        yield return new WaitForSeconds(4f);
        player.SetActive(false);
        mainMenu.SetActive(false);
    }
    IEnumerator MyCoroutine2()
    {
        yield return new WaitForSeconds(4.1f);
        player2.SetActive(true);

    }
   

}
