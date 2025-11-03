using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pistolShootScript : MonoBehaviour
{
    public Collider2D thisCollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DestroyMySelf(){
        thisCollider.enabled = false;
        Destroy(this.gameObject,1f);
    }
}
