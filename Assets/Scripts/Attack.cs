using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        box = GetComponent<BoxCollider2D>();
    }
    private BoxCollider2D box;
    public float timer = 0;
    // Update is called once per frame
    void Update()
    {
        if(timer >= 20f) { Destroy(transform.gameObject); }
        timer += 0.1f;

    }
}
