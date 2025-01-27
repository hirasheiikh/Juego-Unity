using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;
using TMPro;
using static System.Net.Mime.MediaTypeNames;
using UnityEngine.UIElements;

public class Monito : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float groundCheckDistance;
    //public float shootForce = 50;
    //public float bulletLifetime = 5;


    public LayerMask groundMask;
    public GameObject bulletPrefab;
    public Transform spawnPosition;



    private Rigidbody2D rb;
    private Animator animator;
    private AudioSource _audioSource;

    private float direction = 0f;
    private float directionY = 0;
    private bool grounded = true;
    //private float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        //_audioSource = GetComponent<AudioSource>();

        GameManager.instance.monito = this;
    }
    private void FixedUpdate()
    {
   

        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        if (grounded)
        {
            rb.linearVelocity += jumpSpeed * Vector2.up * directionY;
        }

        Debug.DrawRay(transform.position, Vector2.down * groundCheckDistance, Color.blue, 1);
        grounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask);
        grounded &= rb.linearVelocity.y <= 0f;

        //animator.SetBool("Grounded", grounded);
        //animator.SetFloat("Hor", rb.linearVelocity.x);
        //animator.SetFloat("Ver", rb.linearVelocity.y);

        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    public void OnMove(CallbackContext ctx)
    {
        direction = ctx.ReadValue<float>();
        Debug.Log(direction);

    }

    public void OnJump(CallbackContext ctx)
    {
        directionY = ctx.ReadValue<float>();
    }

}
