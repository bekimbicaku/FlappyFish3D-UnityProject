using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyBullets : MonoBehaviour
{
    private const string CoinsKey = "NumberOfCoins";
    private const string BulletsKey = "Bullets";
    public Button buyButton;
    public Button shootButton;
    public Button respawnButton;
    private bool lastBuyInteractable;
    private bool lastRespawnInteractable;
    private bool lastShootInteractable;

    // Update is called once per frame
    void Update()
    {
        UpdateUI();
    }


    public void UpdateUI()
    { 
        int coins = PlayerPrefs.GetInt(CoinsKey, 0);
        int bullets = PlayerPrefs.GetInt(BulletsKey, 0);

        bool canBuyOrRespawn = coins >= 10;
        bool canShoot = bullets >= 1;

        if (lastBuyInteractable != canBuyOrRespawn)
        {
            buyButton.interactable = canBuyOrRespawn;
            lastBuyInteractable = canBuyOrRespawn;
        }

        if (lastRespawnInteractable != canBuyOrRespawn)
        {
            respawnButton.interactable = canBuyOrRespawn;
            lastRespawnInteractable = canBuyOrRespawn;
        }

        if (lastShootInteractable != canShoot)
        {
            shootButton.interactable = canShoot;
            lastShootInteractable = canShoot;
        }

    }
}
