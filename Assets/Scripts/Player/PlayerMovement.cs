using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    public float jumpAmount = 10f;
    public bool jumping;

    public bool crouching = false;  // Se o jogador está agachado
    private float normalHeight = 1f; // Altura normal do personagem
    private float crouchHeight = 0.5f; // Altura quando agachado
    private float crouchSpeed = 5f;  // Velocidade de transição entre agachar e desagachar

    public bool canMove = true;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    private bool grounded;

    public Transform TouchingGround;
    private Vector3 Foot;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void Update()
    {
        Foot = TouchingGround.position;

        // Ground Check
        // Physics.Raycast(<origem do raio>, <direção do raio>, <comprimento do raio>, <objeto que será verificado>);
        grounded = Physics.CheckSphere(Foot, 0.3f, whatIsGround);

        // Ground Dragging
        if (grounded)
        {
            rb.linearDamping = groundDrag;
            canMove = true;
        }
        else
        {
            rb.linearDamping = 0;
        }

        // Input de movimento
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Controle de velocidade
        SpeedControl();

        PlayerJump();

        HandleCrouch();
    }

    private void MovePlayer()
    {
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);

    }

    private void PlayerJump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && grounded) // Só pula se estiver no chão
        {
            jumping = true;
            grounded = false; // O jogador não está mais no chão
            rb.AddForce(Vector3.up * jumpAmount, ForceMode.Impulse); // Aplica a força do pulo
        }

        // Aqui você deve verificar se o jogador voltou ao chão
        if (grounded && jumping)
        {
            jumping = false; // Quando voltar ao chão, pulo é encerrado
        }
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !jumping) // Pressiona Ctrl para agachar
        {
            crouching = !crouching; // Alterna entre agachar e desagachar
        }

        // Se o jogador estiver agachado, reduz a altura
        if (crouching)
        {
            // Gradualmente diminui a altura do jogador
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, crouchHeight, 1f), Time.deltaTime * crouchSpeed);
        }
        else
        {
            // Gradualmente retorna à altura normal
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1f, normalHeight, 1f), Time.deltaTime * crouchSpeed);
        }
    }

    private void SpeedControl()
    {
        // Pega a velocidade atual
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Limita a velocidade caso passe da moveSpeed do player
        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;

            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }
}
