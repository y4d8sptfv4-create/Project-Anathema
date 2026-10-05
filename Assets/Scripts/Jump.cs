using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    private Rigidbody2D frigb;
    private PlayerController parent;
    

    // Start is called before the first frame update
    void Start()
    {
        frigb = GetComponent<Rigidbody2D>();
        parent = transform.parent.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    { parent.Floor();}
}
