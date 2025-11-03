using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe generica para todos inimigos morrer    

public class targetScript : MonoBehaviour
{
    private bool jaMorreu = false;
    [Header("Configurações de Vida")]
    public float Vida;
    [Header("Configurações de Animações e SOM")]
    public Animator Anima;
    public AudioSource localAudioSource;
    public AudioClip[] gritoMorte;
   
    public Collider2D ThisCollider;
    // Start is called before the first frame update
    void Start()
    {
        jaMorreu = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vida<=0f && jaMorreu == false){ //se avida zerar
            jaMorreu =true; 
            chamarMorte();
            
        }
    }
    void OnTriggerStay2D(Collider2D other){
         print("encostei OnTriggerStay2D");
    }

    void OnTriggerEnter2D(Collider2D colisao){
          print("encostei OnTriggerEnter2D: " + colisao.gameObject.tag);
          
        if(colisao.gameObject.tag == "pistolShootTag"){ print("a");Vida = Vida -1;} //se tomar tiro de pistola é -1
    }
    
   
  
  void chamarMorte(){
    ThisCollider.enabled  = false;
    Anima.SetBool("morreu", true);
  }

  public void gritodeMorte(){
    localAudioSource.PlayOneShot(gritoMorte[0]);
  }

}
