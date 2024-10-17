using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shopPanel : MonoBehaviour
{
    public GameObject Panel;

    public void ShowGemsShop()
    {
        Panel.SetActive(true);
    }
    public void HideGemsShop()
    {
        Panel.SetActive(false);
    }
}
