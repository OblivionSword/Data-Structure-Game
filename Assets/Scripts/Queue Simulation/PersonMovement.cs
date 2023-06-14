using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        Vector3 directionX = new Vector3(1.0f,0,0);

        rb.MovePosition(transform.position + directionX * Time.deltaTime * speed);
    }

    
}
