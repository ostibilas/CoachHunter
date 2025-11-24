using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damangeHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void DestroyMe()
    {
        Destroy(this.gameObject, 0f);
    }
}
