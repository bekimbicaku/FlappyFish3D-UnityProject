using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    

    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5000;

    [SerializeField] private float force;
    [SerializeField] public float motorForce;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float reqSpeed;
    [SerializeField] public float lowSpeed;
    public static int numberOfCoins;
    public static int bullets;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI bulletsText;

    [SerializeField] private float gravity;
    [SerializeField] private ForceMode forceMode;
    private Rigidbody playerRB;
    private float XRange = -2;
    private float Range = -4;
    public GameObject player;
    public GameObject playerBody;
   
    public GameObject retryMenu;
    public string Tagged;

    public GameObject panel;
    public GameObject panel2;
    public GameObject panel3;
    public GameObject firstpanel;
    public GameObject revivePanel;
    public GameObject GameOverPanel;

    public GameObject Net;

    [SerializeField] TextMeshProUGUI distancemoved;
    public int distanceunit = 0;

    public Text HSText;
    public Text currentText;
    public Text HSText2;
    public Text currentText2;

    public TextMeshProUGUI coinsText2;

    public GameObject Tropicalplayer;
    public GameObject Yellowplayer;
    public GameObject Turtleplayer;
    public GameObject Mantaplayer;
    public GameObject Starplayer;
    public GameObject Dolphinplayer;
    public GameObject Blueplayer;



    private void Awake()
    {
        HSText2.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore").ToString();
        HSText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore").ToString();
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        bullets = PlayerPrefs.GetInt("Bullets", 0);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        playerRB = GetComponent<Rigidbody>();
        InvokeRepeating("distance", 0, 1 / transform.position.z);

    }

    // Update is called once per frame
    void Update()
    {
        coinsText.text = " " + PlayerPrefs.GetInt("NumberOfCoins", 0).ToString();
        bulletsText.text = bullets.ToString();
        coinsText2.text = " " + PlayerPrefs.GetInt("NumberOfCoins", 0).ToString();
        GetComponent<Rigidbody>().AddForce(Vector3.forward * motorForce * Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            SoundManagerScript.PlaySound("up");
            playerRB.AddForce(Vector3.up * force, forceMode);
        }
        playerRB.AddForce(Vector3.down * gravity, ForceMode.Acceleration);

        if (motorForce < maxSpeed)
            motorForce += 0.06f * Time.deltaTime;

        PlayerXRange();

        distance();


    }
    public void UseTropical()
    {
        Tropicalplayer.SetActive(true);
        Yellowplayer.SetActive(false);
        Turtleplayer.SetActive(false);
        Mantaplayer.SetActive(false);
        Starplayer.SetActive(false);
        Dolphinplayer.SetActive(false);
        Blueplayer.SetActive(false);

    }
    public void UseYellow()
    {
        Tropicalplayer.SetActive(false);
        Yellowplayer.SetActive(true);
        Turtleplayer.SetActive(false);
        Mantaplayer.SetActive(false);
        Starplayer.SetActive(false);
        Dolphinplayer.SetActive(false);
        Blueplayer.SetActive(false);

    }
    public void UseTurtlel()
    {
        Tropicalplayer.SetActive(false);
        Yellowplayer.SetActive(false);
        Turtleplayer.SetActive(true);
        Mantaplayer.SetActive(false);
        Starplayer.SetActive(false);
        Dolphinplayer.SetActive(false);
        Blueplayer.SetActive(false);

    }
    public void UseManta()
    {
        Tropicalplayer.SetActive(false);
        Yellowplayer.SetActive(false);
        Turtleplayer.SetActive(false);
        Mantaplayer.SetActive(true);
        Starplayer.SetActive(false);
        Dolphinplayer.SetActive(false);
        Blueplayer.SetActive(false);

    }
    public void UseStar()
    {
        Tropicalplayer.SetActive(false);
        Yellowplayer.SetActive(false);
        Turtleplayer.SetActive(false);
        Mantaplayer.SetActive(false);
        Starplayer.SetActive(true);
        Dolphinplayer.SetActive(false);
        Blueplayer.SetActive(false);

    }
    public void UseDolphin()
    {
        Tropicalplayer.SetActive(false);
        Yellowplayer.SetActive(false);
        Turtleplayer.SetActive(false);
        Mantaplayer.SetActive(false);
        Starplayer.SetActive(false);
        Dolphinplayer.SetActive(true);
        Blueplayer.SetActive(false);

    }
    public void UseFirst()
    {
        Tropicalplayer.SetActive(false);
        Yellowplayer.SetActive(false);
        Turtleplayer.SetActive(false);
        Mantaplayer.SetActive(false);
        Starplayer.SetActive(false);
        Dolphinplayer.SetActive(false);
        Blueplayer.SetActive(true);

    }
    public void Go()
    {
        force = 7f;
        //GetComponent<HighScore>().enabled = true;
        playerBody.SetActive(true);
        panel.SetActive(true);
        firstpanel.SetActive(false);
        Time.timeScale = 1;
    }
    void distance()
    {
        if (motorForce > reqSpeed)
        {
            distanceunit = distanceunit + 1;
            
        }
        if(motorForce < lowSpeed)
        {
            distanceunit = distanceunit + 0;
        }
        distancemoved.text = " " + distanceunit.ToString();

    }
    public void RevivePlayer()
    {
        player.transform.position = new Vector3(-4, 3, player.transform.position.z - 5);
        playerBody.SetActive(true);
        
        revivePanel.SetActive(false);
        panel.SetActive(true);
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - 10);
        numberOfCoins = numberOfCoins - 10;
        motorForce = 125f;
        force = 7f;
        gravity = 1.1f;

        StartCoroutine(tagPlayer());
    }
    IEnumerator tagPlayer()
    {
        yield return new WaitForSeconds(3f);
        player.tag = Tagged;
    }

    public void PlayerXRange()
    {
        if(transform.position.x > XRange)
        {
            transform.position = new Vector3(XRange, transform.position.y, transform.position.z + 1);
        }
        if (transform.position.x < Range)
        {
            transform.position = new Vector3(Range, transform.position.y, transform.position.z + 1);
        }
    }
    public void Buy()
    {
        PlayerPrefs.SetInt("Bullets", PlayerPrefs.GetInt("Bullets", 0) + 1);
        bullets = bullets + 1;
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - 10);
        numberOfCoins = numberOfCoins - 10 ;
    }
    public void Buy2()
    {
        PlayerPrefs.SetInt("Bullets", PlayerPrefs.GetInt("Bullets", 0) + 1);
        bullets = bullets + 1;
        
    }
    public void RevivePrice()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Speed")
        {          
            motorForce = motorForce + 80f;           
        }
        if (other.tag == "Slow")
        {
            motorForce = motorForce - 40f;
        }
        if (other.tag == "Increase")
        {
            PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) + 5);
            numberOfCoins = numberOfCoins + 5;
        }
        if (other.tag == "Broke")
        {
            PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - 5);
            numberOfCoins = numberOfCoins - 5;
        }
        if (other.tag == "Coral")
        {

            //motorForce = 0f;
            //force = 10f;
            //gravity = 0f;
            currentText.text = "CURRENT SCORE: " + distanceunit.ToString();
            if (distanceunit > PlayerPrefs.GetInt("highscore"))
            {
                
                PlayerPrefs.SetInt("highscore", distanceunit);
                HSText.text = "NEW HIGHSCORE: " + PlayerPrefs.GetInt("highscore").ToString();
                HSText.color = Color.green;
            }
           

        }
        if (other.tag == "Net")
        {
            currentText2.text = "CURRENT SCORE: " + distanceunit.ToString();
            Net.GetComponent<Animator>().Play("Net");
            //player.GetComponent<Animator>().Play("Catch");
            StartCoroutine(NetCatch());
            motorForce = 0f;
            gravity = 0f;
            force = 0f;
            if (distanceunit > PlayerPrefs.GetInt("highscore"))
            {

                PlayerPrefs.SetInt("highscore", distanceunit);
                HSText2.text = "NEW HIGHSCORE: " + PlayerPrefs.GetInt("highscore").ToString();
                HSText2.color = Color.green;
            }

        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Speed")
        {            
            motorForce = motorForce - 80f;
        }
        if (other.tag == "Slow")
        {
            motorForce = motorForce + 80f;
        }
    }
    public void shoot()
    {
        PlayerPrefs.SetInt("Bullets", PlayerPrefs.GetInt("Bullets", 0) - 1);
        bullets = bullets - 1;
        SoundManagerScript.PlaySound("shoot");
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * Time.deltaTime * bulletSpeed;
    }
    public void Pause()
    {

        panel2.SetActive(true);
        panel.SetActive(false);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        panel2.SetActive(false);
        panel.SetActive(true);
        Time.timeScale = 1;
        motorForce = 120f;
    }
    public void loadMenu()
    {
        motorForce = 0f;
        retryMenu.SetActive(true);
        panel3.SetActive(false);

    }

   
    
    IEnumerator NetCatch()
    {
        yield return new WaitForSeconds(11f);
        GameOverPanel.SetActive(true);
    }
}
