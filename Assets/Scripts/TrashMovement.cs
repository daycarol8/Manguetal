using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashMovement : MonoBehaviour
{
    private Countdown tempo; 
    private float speed = 4;  
    void Start()
    {
        tempo = GameObject.FindGameObjectWithTag("countdown").GetComponent<Countdown>();
    }

    void Update()
    {
        if(tempo.tempo >= 30 && tempo.tempo <= 40){
            speed = 4;
        }
        else if(tempo.tempo >= 20 && tempo.tempo <=30){
            speed = 4.5f;
        }
        else if(tempo.tempo >= 10 && tempo.tempo <= 20){
            speed = 5;
        }
        else if(tempo.tempo >=0 && tempo.tempo <= 10){
            speed = 6.5f;
        }

       transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
