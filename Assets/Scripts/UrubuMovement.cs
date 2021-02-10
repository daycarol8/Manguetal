using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrubuMovement : MonoBehaviour
{
    [SerializeField]
    public GameObject[] lixos;
    private bool isRight;
    private float speed = 6;
    private float proximoLixo = 1f;
 

    void Start()
    {
      
    }

    void Update()
    {
        Move();
        SpawnLixo();
    }
    //espelhar o sprite quando ele chegar no x -12, pra ele n fazer moon walk
    void Move(){
        if(!isRight){
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        }
        else{
            transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
        }

        if(transform.position.x < -10 || transform.position.x > 10){
            isRight = !isRight;
            this.GetComponent<SpriteRenderer>().flipX = !this.GetComponent<SpriteRenderer>().flipX;
        }
    }

    void SpawnLixo(){
        if(Time.time > proximoLixo){
            proximoLixo = Time.time + Random.Range(0.5f, 2);
            if(transform.position.x > -7.97 && transform.position.x < 7.55){
                Instantiate(lixos[Random.Range(0, lixos.Length)], transform.position, Quaternion.identity);
            }
        }
    }
}
