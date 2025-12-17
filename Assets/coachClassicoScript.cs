using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coachClassicoScript : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameObject mira1, falaPersonagem, damageHUD, playerLifeGameObj; // mira1 é o local aonde vai aparecer a fala 
    public float speed, damageOutput; // velociade que ele sobe
    private bool jaAtacou; //ele só pode atirar uma vez
    private GameObject falaEstanciada; //Salva o GameObject que Criei

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new Vector3(this.transform.position.x, -4.95f, 0f); //manda ele pra baixo da tela
        jaAtacou = false;
        playerLifeGameObj = GameObject.Find("MAIN_STAGE_CONTROLER");
        
    }
       
    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y <= 0f) // sobre ele ate o 0f
        {
            rb.velocity = new Vector3(0f, speed, 0f);
        }
        else
        {
            rb.velocity = new Vector3(0f, 0f, 0f); //para de subir
            if (jaAtacou == false && this.GetComponent<targetScript>().jaMorreu == false)
            {
                jaAtacou = true;//so chama uma vez
                StartCoroutine(AtivarAtaque()); //inicia ataque
                print("Ativar Ataque!!!");
            }
        }
        
        
     
            

    } 

    
        
    IEnumerator AtivarAtaque()
    {

        //yield return new WaitForSeconds(0.05f);//tempo de espera
        this.GetComponent<targetScript>().Anima.SetBool("iniciarAtaque", true);
        falaEstanciada = Instantiate(falaPersonagem, mira1.transform.position, mira1.transform.rotation);//cria a fala
        this.GetComponent<targetScript>().FalaAtual = falaEstanciada;//mandando a falaEstanciada para outro Script "targetScript" usar  
        print("BESTA");
        yield return new WaitForSeconds(1.0f);//tempo de espera 
        if (this.GetComponent<targetScript>().jaMorreu == false)
        {
            print("ENTREI AQUI!");
            playerLifeGameObj.GetComponent<controladorGamePlay>().playerLife -= damageOutput;
            Instantiate(damageHUD, new Vector3(0f, 0f, 0f), Quaternion.identity);//Solta efeito de dano na tela
        }


    }
}
