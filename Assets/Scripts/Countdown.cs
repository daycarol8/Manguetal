using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Countdown : MonoBehaviour
{
    public Text displaycontagem;
    public int tempo = 40;
    public static int speed;

    
    void Start()
    {

        InvokeRepeating("diminuir", 0, 1);
    }

    void Update()
    {
        if(tempo == 0)
        {
            SceneManager.LoadScene("Ajuda2");
        }
    }

    void diminuir(){
        tempo--;
        displaycontagem.text = "Tempo restante: " + tempo.ToString();
    }
}
