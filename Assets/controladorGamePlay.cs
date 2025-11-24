using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using TMPro;

public class controladorGamePlay : MonoBehaviour
{
    public Camera mainCamera;
    public TMP_Text Timer,scoreHUD,LifeHUD;
    public int pontosAtuais;
    public GameObject[] inimigo;
    private float nextFire = 0;
    public float fire_rate,playerLife;
    
            
    [Header("Configurações de Arma")]
    public GameObject hitEffectPrefab; // Prefab do efeito visual (ex: um círculo de sangue, um flash)
    
    // Variáveis para detecção de Swipe
    private bool isSwiping = false;
    private Vector2 swipeStartPos;
    public float stageTempo;
    
    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
            playerLife = 100f;
        }

        StageStarter(1,"normal");
    }

    IEnumerator StageStarter(int level, string Dificuldade){
        yield return new WaitForSeconds(0f);
        if (level == 1)
        {
            stageTempo = 60f;
        }


    }
    
       void Update()
    {
         if (Time.time > nextFire && stageTempo > 0f) {
         nextFire = Time.time + fire_rate;
            

         Instantiate(inimigo[0],new Vector3(Random.Range(-6.5f,9.5f),-5.4f),Quaternion.identity);
        }

        scoreHUD.text = $"Score:{pontosAtuais}";
        LifeHUD.text = $"LIFE:{playerLife}";

        if (stageTempo > 0f)
        {
            stageTempo -= Time.deltaTime;
            Timer.text = stageTempo.ToString("F0"); ;
        }
        


        // --- LÓGICA DE CLIQUE (Simples Shot) ---
        if (Input.GetMouseButtonDown(0))
        {
            // Captura a posição do clique/toque inicial
            Vector3 currentScreenPos = Input.mousePosition;
            currentScreenPos.z = -mainCamera.transform.position.z;
            Vector3 objetoPos = mainCamera.ScreenToWorldPoint(currentScreenPos); //Covertendo para uma posição da camera

            Instantiate(hitEffectPrefab, objetoPos, Quaternion.identity);

            // Chama a função de acerto (para o tiro instantâneo)
            //PerformHitCheck(currentScreenPos);
        }

        // --- LÓGICA DE SWIPE (Legacy Input) ---
        HandleSwipe();
    }

   
    // --- LÓGICA DE SWIPE ---
    void HandleSwipe()
    {
        // 1. INÍCIO DO TOQUE/PRESSÃO
        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began))
        {
            isSwiping = true;
            // Salva a posição inicial do toque/mouse
            swipeStartPos = Input.mousePosition; 
            
            // Se for um toque, salve a posição do touch também para toque múltiplo
            if (Input.touchCount > 0)
            {
                 swipeStartPos = Input.GetTouch(0).position;
            }
        }

        // 2. FIM DO TOQUE/PRESSÃO
        if (Input.GetMouseButtonUp(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended))
        {
            if (isSwiping)
            {
                Vector2 swipeEndPos = Input.mousePosition;
                if (Input.touchCount > 0)
                {
                    swipeEndPos = Input.GetTouch(0).position;
                }

                // Calcula a distância percorrida
                float distance = Vector2.Distance(swipeStartPos, swipeEndPos);
                
                // Define um limiar mínimo para considerar um swipe (ajuste conforme necessário)
                if (distance > 50f) 
                {
                    // É um Swipe!
                    Vector2 swipeDirection = (swipeEndPos - swipeStartPos).normalized;
                    Debug.Log($"SWIPE DETECTADO! Direção: {swipeDirection}");
                    
                    // --- CHAME SUA LÓGICA DE SWIPE AQUI ---
                    // Ex: Se for um swipe para cima, ativa uma mira especial.
                    HandleSwipeAction(swipeDirection);
                }
                else
                {
                    // Foi apenas um clique curto (já tratado em PerformHitCheck)
                    Debug.Log("Foi um clique curto, não um swipe.");
                }
                
                isSwiping = false;
            }
        }
    }
    
    void HandleSwipeAction(Vector2 direction)
    {
        // Lógica específica para o swipe
    }
}