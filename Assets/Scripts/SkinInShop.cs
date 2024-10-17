using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkinInShop : MonoBehaviour
{
    public PlayerInfo skinInfo;


    //public Image skinImage;
    public Button Buy;
    public Button Use;
   
    public bool isSkinUnlocked;
    

    private void Awake()
    {
        //skinImage.sprite = skinInfo.skinSprite;
        IsSkinUnlocked();
    }

    private void IsSkinUnlocked()
    {
        if (PlayerPrefs.GetInt(skinInfo.skinID.ToString()) == 1)
        {
            isSkinUnlocked = true;
            Buy.gameObject.SetActive(false);
            Use.gameObject.SetActive(true);
            
        }
    }
    public void Update()
    {
        if (PlayerPrefs.GetInt("NumberOfCoins") >= skinInfo.skinPrice)
        {
            Buy.interactable = true;
        }
        else
            Buy.interactable = false;

    }

    public void OnButtonPress()
    {
        if (isSkinUnlocked)
        {
            Use.gameObject.SetActive(true);

        }
        else
        {
            PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins") - skinInfo.skinPrice);
            PlayerPrefs.SetInt(skinInfo.skinID.ToString(), 1);
            IsSkinUnlocked();

        }
    }
}