using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialChanger : MonoBehaviour
{
    public Material[] material;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
        StartCoroutine(Change());
        StartCoroutine(Change2());
        StartCoroutine(Change3());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Change()
    {
        yield return new WaitForSeconds(120f);
        rend.sharedMaterial = material[1];
    }
    IEnumerator Change2()
    {
        yield return new WaitForSeconds(240f);
        rend.sharedMaterial = material[0];
    }
    IEnumerator Change3()
    {
        yield return new WaitForSeconds(360f);
        rend.sharedMaterial = material[1];
    }

}
