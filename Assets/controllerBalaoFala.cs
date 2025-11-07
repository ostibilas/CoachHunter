using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //por estar usando o text mesh pro

public class controllerBalaoFala : MonoBehaviour
{
    public string[] falasRandomicas; //indice de falas que serão sorteadas aleatoriamente
    public TextMeshPro TextoTMP;
    //Programa que ira controlar a criação dos baloes de fala

    // Start is called before the first frame update
    void Start()
    {
        TextoTMP.text = falasRandomicas[Random.Range(0, falasRandomicas.Length)]; /* sorteando a mandando o texto correto na mesma linha*/
        //podia fazer separado mas...

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyMySelf()
    {
        Destroy(this.gameObject, 0f);
    }
}
