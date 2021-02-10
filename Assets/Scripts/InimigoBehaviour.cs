using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InimigoBehaviour : MonoBehaviour
{
    public GameObject[] tiroPrefab;
    [SerializeField]
    private Text texto;
    public int life = 20;
    [SerializeField]private Image lifee;
    public Animator anim;
  


    private void Start()
    {
        StartCoroutine(Loop());     
    }
    private void Update() {
        
        texto.text = life.ToString();
        if(life == 6)
        {
            anim.SetBool("Raivoso", true);
        }
        if(life == 0)
        {
            SceneManager.LoadScene("Win");
        }

        
      
    }

    void Shoot()
    {
        
        Instantiate(tiroPrefab[Random.Range(0, 13)], transform.position + new Vector3(0.88f, 0), Quaternion.identity);
        
    }

    IEnumerator Loop()
    {
        while(life > 10)
        {
            Shoot();
          
            yield return new WaitForSeconds(2.5f);
        }
        while(life > 3 && life <= 10)
        {
            Shoot();
            
            yield return new WaitForSeconds(1.5f);
        }
        while(life <= 3 && life > 0)
        {
            Shoot();
          
            yield return new WaitForSeconds(1f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Tiro")
        {
            if(collision.gameObject.GetComponent<Renderer>().material.color == Color.green)
            {
                lifee.fillAmount -= 0.05f;
                life--;
                Destroy(collision.gameObject);
            }
        }
    }
}
