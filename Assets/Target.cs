using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int scoreValue = 10;

    // Chamado pelo clique instantâneo (PerformHitCheck)
    public void InstantHit()
    {
        Debug.Log($"Alvo {gameObject.name} atingido instantaneamente.");
        
        // Aqui você colocaria a lógica de pontuação ou animação de morte
        // Ex: ScoreManager.AddScore(scoreValue);
        
        // Destrói o objeto (você pode usar Object Pooling aqui para otimização)
        Destroy(gameObject); 
    }
}