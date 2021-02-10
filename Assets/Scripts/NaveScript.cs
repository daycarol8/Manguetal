using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaveScript : MonoBehaviour
{
    [SerializeField] private GameObject imag;
    private float varia = 0;
    void Start()
    {
        Invoke("ChangeScene", 5);

    }
    void Update()
    {
        if(varia < 1)
        {
            varia += 0.01f;
        }
        
        imag.GetComponent<Renderer>().material.color = Color.HSVToRGB(0,0,varia);
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Menu");
    }
}
