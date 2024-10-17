using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HighScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI distancemoved;
    public int distanceunit = 0;

    public Text HSText;

    // Start is called before the first frame update
    void Awake()
    {
        HSText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore").ToString();
    }
    void Start()
    {
        
       
        InvokeRepeating("distance", 0, 50 / 150);

    }

    // Update is called once per frame
    void Update()
    {
        distance();
    }
    private void distance()
    {

        distanceunit = distanceunit + 1;
        distancemoved.text = " " + distanceunit.ToString();

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Coral")
        { 
            
            if(distanceunit > PlayerPrefs.GetInt("highscore"))
            {

                PlayerPrefs.SetInt("highscore", distanceunit);
                HSText.text = "NEW HIGHSCORE: " + PlayerPrefs.GetInt("highscore").ToString();
            }
           

        }
    }
}
