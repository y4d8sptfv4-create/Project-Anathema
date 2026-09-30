using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigb;
    private BoxCollider2D box;
    void Start()
    {
       rigb = GetComponent<Rigidbody2D>();
       box = GetComponent<BoxCollider2D>();
     }

    // Update is called once per frame
    public float speedmult = 1f;
    public bool onfloor = true;
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){transform.Translate(0.01f*speedmult,0,0);}
        if(Input.GetKey(KeyCode.A)){transform.Translate(-0.01f*speedmult,0,0);}
        if(Input.GetKeyDown(KeyCode.Space)&&onfloor){rigb.AddForce(Vector2.up*300); onfloor = false; }
        
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {

        Debug.Log("HELP");
        onfloor = true;
        
    }
    
}

