using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public InimigoBehaviour inimigo;
    public Animator anim;
    public Rigidbody2D rb;
    public Text pontuacao;
    public Text LixoGuardado;
    private float live;
    private float speed = 385;
    private float lixosPegos = 0;
    private float lixosAux = 0;
    private float lixosNaLixeira = 0;
    [SerializeField] Animator anim2;
    private bool atirar = false;
     
    void Start()
    {
        inimigo = GameObject.FindGameObjectWithTag("Inimigo").GetComponent<InimigoBehaviour>();
        pontuacao = GameObject.FindGameObjectWithTag("pontuacao").GetComponent<Text>();
        if(lixosNaLixeira == 0){
            pontuacao.text = "pontuação " + 0;
        }

        if(lixosAux == 0){
            LixoGuardado.text = "Lixo guardado: " + 0;
        }
        rb.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (atirar)
        //{
        //    atirar = false;
        //    anim.SetBool("ataquechico", true);

        //}
        Move();
        Animation();
        Life();
    }

    void Animation(){
        if(Input.GetAxis("Horizontal") > 0){
            anim.SetBool("movement", true);
        }
        else if(Input.GetAxis("Horizontal") < 0){
            anim.SetBool("movement", true);
        }
        
        if(Input.GetAxis("Horizontal") == 0){
            anim.SetBool("movement", false);
        }
    }

    void Move(){
        rb.velocity = new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0);
    }

    void OnTriggerEnter2D(Collider2D col){
        if(col.tag == "lixo"){
            Destroy(col.gameObject);
            lixosPegos++;
            Lentidao();
            Somador();
            LixoGuardado.GetComponent<Text>().text = "Lixo guardado: " + lixosPegos;
        } 

        if(col.tag == "Tiro")                                 //------------------
        {                                                     //------------------
           atirar = col.GetComponent<TiroBehaviour>().AtirarPlayer(); //------------------
           
        }                                                     //------------------


        if(col.tag == "lixeiro"){
            speed = 385;
            lixosNaLixeira += lixosAux;
            lixosPegos = 0;
            lixosAux = 0;
            LixoGuardado.GetComponent<Text>().text = "Lixo guardado: " + 0;
            pontuacao.GetComponent<Text>().text = "Pontuação:    " + lixosNaLixeira;
        }
    }

    private void Life()             //------------------
    {                               //------------------
        live = inimigo.life;        //------------------
        if (live <= 7)              //------------------
        {                           //------------------
            speed = 400;            //------------------
        }                           //------------------
    }                               //------------------

    void Somador(){
        lixosAux += lixosPegos;
    }

    void Lentidao(){
        speed = speed - (lixosPegos * 1.4f);
    }

    //public void Ataque()
    //{
    //  anim2.SetBool("ataquechico", true);
        
    //}
       
}