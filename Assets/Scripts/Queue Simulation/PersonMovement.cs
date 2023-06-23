using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMovement : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 2.0f;
    private Vector3 directionX;
    private Vector3 directionY;
    public bool dequeued;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        directionX = new Vector3(1.0f, 0, 0);
    }

    private void FixedUpdate()
    {
        rb.velocity = directionX * speed;
    }


}
