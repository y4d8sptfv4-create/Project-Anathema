using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rigb;
    private BoxCollider2D box;
    public GameObject attackPF;
    public GameObject feet;
    void Start()
    {
       rigb = GetComponent<Rigidbody2D>();
       temp = speedmult;
       box = GetComponent<BoxCollider2D>();
     }

    // Update is called once per frame
    public float speedmult = 1f;
    private float temp;
    private int facing;
    public bool onfloor = true;
    void Update() 
    {
        feet.transform.position = transform.position - new Vector3(0,0.52f,0);
        if (Input.GetKey(KeyCode.D)){transform.Translate(0.01f*speedmult,0,0);facing = 1;  }
        if(Input.GetKey(KeyCode.A)){transform.Translate(-0.01f*speedmult,0,0);facing = -1; }
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) { speedmult = temp + 0.25f; }
        else { speedmult = temp; }
        if (Input.GetKeyDown(KeyCode.Space) && onfloor) {rigb.AddForce(Vector2.up * 300);onfloor = false;}
        if (Input.GetMouseButtonDown(0)) {Instantiate(attackPF, new Vector3(transform.position.x+facing, transform.position.y, transform.position.z), transform.rotation); }
        
                    
    
    }

    public void Floor() { onfloor = true;}
        
}

