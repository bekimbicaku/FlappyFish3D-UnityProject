using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldProtect : MonoBehaviour
{
   void Update()
   {
        
   }
    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "Coin")
        {
            SoundManagerScript.PlaySound("coin");
            PlayerController.numberOfCoins++;
            PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) + 1);
            //Add 1 to points;
            Destroy(other.gameObject); // This destroys things;
        }
    }
}
