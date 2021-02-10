using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mangue : MonoBehaviour
{
  [SerializeField] private Text texto;
  [SerializeField]private Image lifee;
    private int life = 5;
    
   private void Update() {

       texto.text = life.ToString();
        if(life <= 0)
        {
            SceneManager.LoadScene("Gameover2");
        }
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tiro")
        {
           if(collision.gameObject.GetComponent<Renderer>().material.color == Color.white)
             {
                 lifee.fillAmount -= 0.2f;
                life--;
             }
        }
    }
}
