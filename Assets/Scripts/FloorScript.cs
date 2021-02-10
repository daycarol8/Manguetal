using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FloorScript : MonoBehaviour
{
   // [SerializeField] private Text texto;
    [SerializeField] private Image lifee;
    private int life = 5;
  

    // Update is called once per frame
    void Update()
    {
        //texto.text = life.ToString();

        if (life == 0)
        {
            SceneManager.LoadScene("Gameover1");
        }
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "lixo"){
            Destroy(col.gameObject);
            life--;
            lifee.fillAmount -= 0.2f;

        }

    }
}
