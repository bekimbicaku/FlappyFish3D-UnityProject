using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyBullets : MonoBehaviour
{
    public Button buyButton;
    public Button shootButton;
    public Button respawnButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }


    public void UpdateUI()
    { 
       
        
        if (10 <= PlayerPrefs.GetInt("NumberOfCoins", 0))
        {
           buyButton.interactable = true;
        }
        else
        {
           buyButton.interactable = false;
        }
        if (10 <= PlayerPrefs.GetInt("NumberOfCoins", 0))
        {
            respawnButton.interactable = true;
        }
        else
        {
            respawnButton.interactable = false;
        }

        if (1 <= PlayerPrefs.GetInt("Bullets", 0))
        {
            shootButton.interactable = true;
        }
        else
        {
            shootButton.interactable = false;
        }

    }
}
