using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private const string JUMP = "Jump";
    public static CharacterController instance { get; private set; }

    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private Vector3 moveDir;

    [SerializeField] private KeyCode jumpKey = KeyCode.Space;


    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.1f;

    private bool isGrounded;

    private void Awake()
    {
        groundCheck = transform.Find("GroundCheck");
        instance = this;
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveX = 0f;

        if(Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = +1f;
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        moveDir = new Vector3(moveX, 0f, 0f).normalized;

        // Проверяем, находится ли персонаж на земле
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded && Input.GetKeyDown(jumpKey))
        {
            animator.SetBool(JUMP, true);
            Debug.Log("Jump!");
            Jump();
        }
        else
        {
            animator.SetBool(JUMP, false);
        }
    }

    private void Jump()
    {
        // Сначала сбрасываем вертикальную скорость
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 0f);
        rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }
}
