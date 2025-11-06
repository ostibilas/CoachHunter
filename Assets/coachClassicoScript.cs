using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coachClassicoScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject mira1,falaPersonagem; // mira1 é o local aonde vai aparecer a fala 
    public float speed; // velociade que ele sobe
    private bool jaAtacou; //ele só pode atirar uma vez

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position =  new Vector3 (this.transform.position.x,-4.95f,0f); //manda ele pra baixo da tela
        jaAtacou=false;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= 0f ) // sobre ele ate o 0f
        {
            rb.velocity = new Vector3(0f,speed, 0f);
        }else
        {
            rb.velocity = new Vector3(0f,0f, 0f);
            if(jaAtacou == false){
                StartCoroutine(AtivarAtaque());
            }
        }
        
            
        
        
           
    }

    IEnumerator AtivarAtaque(){
    yield return new WaitForSeconds(0.05f);
    
  }
}
