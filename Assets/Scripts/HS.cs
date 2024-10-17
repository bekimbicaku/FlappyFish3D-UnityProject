using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HS : MonoBehaviour
{ 
     public TextMeshProUGUI HSText2;
     


    // Start is called before the first frame update
    void Awake()
    {
        
        HSText2.text = " " + PlayerPrefs.GetInt("highscore").ToString();
    }
    
}
