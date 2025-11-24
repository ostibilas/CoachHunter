using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ifNullDestroyMe : MonoBehaviour
{
    public GameObject gameObjFilho;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObjFilho ==  null)
        {
            Destroy(this.gameObject,0f);
        }
    }
}
