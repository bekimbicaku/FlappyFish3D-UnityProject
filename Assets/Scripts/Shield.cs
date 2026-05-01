using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shield : MonoBehaviour
{
    public GameObject shield;
    public GameObject shieldImage;

    public GameObject player;

    public string Untagged;
    public string Tagged;

    float currentTime = 0f;
    float startingTime = 9f;
    private int lastShownSeconds = int.MinValue;

    [SerializeField] TextMeshProUGUI countdownText;
    void Start()
    {
        currentTime = startingTime;
    }
    void Update()
    {
        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        int shownSeconds = Mathf.CeilToInt(currentTime);
        if (lastShownSeconds != shownSeconds)
        {
            countdownText.text = currentTime.ToString("0");
            lastShownSeconds = shownSeconds;
        }

        currentTime -= 1 * Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CloseShield"))
        {
            SoundManagerScript.PlaySound("shield");
            currentTime = startingTime;

            StartCoroutine(Close());
            gameObject.tag = Untagged;
          
            Destroy(other.gameObject);
            shield.SetActive(true);
            shieldImage.SetActive(true);


        }

    }
    
    IEnumerator Close()
    {
        yield return new WaitForSeconds(9f);
        shield.SetActive(false);
        player.tag = Tagged;
        currentTime = startingTime;
        shieldImage.SetActive(false);
    }
}
