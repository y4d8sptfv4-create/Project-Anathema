using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public float speedmult = 1f;
    void Update()
    {
        if(Input.GetKey(KeyCode.D)){transform.Translate(0.01f*speedmult,0,0);}
        if(Input.GetKey(KeyCode.A)){transform.Translate(-0.01f*speedmult,0,0);}
        if(Input.GetKeyDown(KeyCode.Space)){transform.Translate(0,1,0);}
    }
}
