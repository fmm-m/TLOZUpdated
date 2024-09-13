using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector2 movement;

    private Rigidbody2D rb;
    private Animator animator;

    private const string horizontal = "HORIZONTAL";
    private const string vertical = "VERTICAL";



    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.Set(InputManager.Movement.x, InputManager.Movement.y);
        
        rb.velocity = movement * moveSpeed;

        animator.SetFloat(horizontal, movement.x);
        animator.SetFloat(vertical, movement.y);

    }
}
