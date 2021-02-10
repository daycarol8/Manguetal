using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TiroBehaviour : MonoBehaviour
{
    private float force;
    private Rigidbody2D rb;
    private bool space = false;
    private bool chao = false;
   [SerializeField] private PlayerController playerController;
   
    private void Start()
    {
        ShootBoss();
        
    }

    void ShootBoss()
    {
        rb = GetComponent<Rigidbody2D>();
        force = Random.Range(280, 445);
        rb.AddForce(new Vector2(-force, force));
    }

    private void Update()
    {
        if(transform.position.y <= -5.19f)
        {
            Destroy(this.gameObject);
        }
        if(transform.position.x >= 10f)
        {
            Destroy(this.gameObject);
        }

        if(Input.GetKeyDown("space")){
            space = true;
        }
    }

    public bool AtirarPlayer()
    {
        if(space)
        {
            rb.AddForce(new Vector2(force*2, force*2));
            //playerController.GetComponent<PlayerController>().Ataque();
            gameObject.GetComponent<Renderer>().material.color = Color.green;
            return true;
           
        }
        else
        {
            return false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "cenario")
        {
            Destroy(this.gameObject);
        }
    }
}
