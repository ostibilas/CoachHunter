using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//classe generica para todos inimigos morrer    

public class targetScript : MonoBehaviour
{
  public bool jaMorreu = false;
  [Header("Configurações de Vida")]
  public float Vida;
  public int Pontos;
  [Header("Configurações de Animações e SOM")]
  
  public Animator Anima;
  public AudioSource localAudioSource;
  public AudioClip[] gritoMorte;
  public GameObject FalaAtual;
  public Collider2D ThisCollider;
  public GameObject gameControler;
  // Start is called before the first frame update
  void Start()
  {
    gameControler = GameObject.Find("MAIN_STAGE_CONTROLER"); 
    jaMorreu = false;
  }

  // Update is called once per frame
  void Update()
  {
    if (Vida <= 0f && jaMorreu == false)
    { //se avida zerar
      jaMorreu = true;
      chamarMorte();

    }
  }
  void OnTriggerStay2D(Collider2D other)
  {
    print("encostei OnTriggerStay2D");
  }

  void OnTriggerEnter2D(Collider2D colisao)
  {
    print("encostei OnTriggerEnter2D: " + colisao.gameObject.tag);

    if (colisao.gameObject.tag == "pistolShootTag") { Vida = Vida - 1; } //se tomar tiro de pistola é -1
  }



  void chamarMorte()
  {
    gameControler.GetComponent<controladorGamePlay>().pontosAtuais += Pontos;
    ThisCollider.enabled = false; //Desativa colisor
    Anima.SetBool("morreu", true); //ativa a animacao de Morte
    StartCoroutine(gritodeMorte()); //chama a funcao de sair som de morte
    if (FalaAtual != null)
    {
      FalaAtual.GetComponentInChildren<Animator>().SetBool("isDead", true);//busca o GameObject dentro do falaAtual
    }


  }

  IEnumerator gritodeMorte()
  {
    yield return new WaitForSeconds(0.05f); //espera um pouco antes de chamar o audio
    localAudioSource.PlayOneShot(gritoMorte[0]);
  }

  public void matarInimigo()
  {
    Destroy(this.gameObject, 0f);
  }

}
