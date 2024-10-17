using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPManager : MonoBehaviour
{
    private string gems50 = "com.bicakugames.flappyfish3d.gems50";
    private string gems100 = "com.bicakugames.flappyfish3d.gems100";
    private string gems500 = "com.bicakugames.flappyfish3d.gems500";

    public GameObject restorePurchaseBtn;
    
    private void Awake()
    {
        DisableRestorePurchareBtn();
    }
    public void OnPurchaseComplete(Product product)
    {
        if(product.definition.id == gems50)
        {
            PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) + 50);
           
            Debug.Log("You've gain 50 gems");
        }
        if (product.definition.id == gems100)
        {
            PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) + 100);
            
            Debug.Log("You've gain 100 gems");
        }
        if (product.definition.id == gems500)
        {
            PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) + 500);
            
            Debug.Log("You've gain 500 gems");
        }

    }
    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
      
        Debug.Log(product.definition.id + "failed because" + failureReason);
       
    }
    private void DisableRestorePurchareBtn()
    {
        if(Application.platform != RuntimePlatform.IPhonePlayer)
        {
            restorePurchaseBtn.SetActive(false);
        }
    }
}
