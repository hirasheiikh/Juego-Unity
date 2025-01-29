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
    public ParticleSystem damageParticle;

    public SpriteRenderer cabeza;
    public SpriteRenderer brazo_izq;
    public SpriteRenderer brazo_der;
    public SpriteRenderer pierna_izq;
    public SpriteRenderer pierna_der;
    public SpriteRenderer body;


    public Sprite sprite_cabeza_hielo;
    public Sprite sprite_brazo_izq_hielo;
    public Sprite sprite_brazo_der_hielo;
    public Sprite sprite_pierna_izq_hielo;
    public Sprite sprite_pierna_der_hielo;
    public Sprite sprite_body_hielo;

    public Sprite sprite_cabeza_fuego;
    public Sprite sprite_brazo_izq_fuego;
    public Sprite sprite_brazo_der_fuego;
    public Sprite sprite_pierna_izq_fuego;
    public Sprite sprite_pierna_der_fuego;
    public Sprite sprite_body_fuego;

    public Sprite sprite_cabeza_superman;
    public Sprite sprite_brazo_izq_superman;
    public Sprite sprite_brazo_der_superman;
    public Sprite sprite_pierna_izq_superman;
    public Sprite sprite_pierna_der_superman;
    public Sprite sprite_body_superman;

    public Sprite sprite_cabeza_estrella;
    public Sprite sprite_brazo_izq_estrella;
    public Sprite sprite_brazo_der_estrella;
    public Sprite sprite_pierna_izq_estrella;
    public Sprite sprite_pierna_der_estrella;
    public Sprite sprite_body_estrella;

    public Sprite sprite_pierna_izq_salta;
    public Sprite sprite_pierna_der_salta;

    public Sprite sprite_cabeza_grande;
    public Sprite sprite_brazo_izq_grande;
    public Sprite sprite_brazo_der_grande;
    public Sprite sprite_pierna_izq_grande;
    public Sprite sprite_pierna_der_grande;
    public Sprite sprite_body_grande;

    private Rigidbody2D rb;
    private Animator animator;
    //private AudioSource _audioSource;

    private float direction = 0f;
    private float directionY = 0;
    private bool grounded = true;
    //private float time;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
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
        grounded = (Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundMask) && rb.linearVelocity.y <= 0.2f);

        animator.SetBool("Grounded", grounded);
        animator.SetFloat("Hor", rb.linearVelocity.x);
        animator.SetFloat("Ver", rb.linearVelocity.y);

        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }

    }

    public void Damage()
    {
        damageParticle.Play();
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

    public void activar_hielo()
    {
        cabeza.sprite = sprite_cabeza_hielo;
        pierna_izq.sprite = sprite_pierna_izq_hielo;
        pierna_der.sprite = sprite_pierna_der_hielo;
        brazo_der.sprite = sprite_brazo_der_hielo;
        brazo_izq.sprite = sprite_brazo_izq_hielo;
        body.sprite = sprite_body_hielo;
    }

    public void activar_fuego()
    {
        cabeza.sprite = sprite_cabeza_fuego;
        pierna_izq.sprite = sprite_pierna_izq_fuego;
        pierna_der.sprite = sprite_pierna_der_fuego;
        brazo_der.sprite = sprite_brazo_der_fuego;
        brazo_izq.sprite = sprite_brazo_izq_fuego;
        body.sprite = sprite_body_fuego;
    }

    public void activar_superman()
    {
        cabeza.sprite = sprite_cabeza_superman;
        pierna_izq.sprite = sprite_pierna_izq_superman;
        pierna_der.sprite = sprite_pierna_der_superman;
        brazo_der.sprite = sprite_brazo_der_superman;
        brazo_izq.sprite = sprite_brazo_izq_superman;
        body.sprite = sprite_body_superman;
    }

    public void activar_estrella()
    {
        cabeza.sprite = sprite_cabeza_estrella;
        pierna_izq.sprite = sprite_pierna_izq_estrella;
        pierna_der.sprite = sprite_pierna_der_estrella;
        brazo_der.sprite = sprite_brazo_der_estrella;
        brazo_izq.sprite = sprite_brazo_izq_estrella;
        body.sprite = sprite_body_estrella;
    }

    public void activar_salta()
    {
        pierna_izq.sprite = sprite_pierna_izq_salta;
        pierna_der.sprite = sprite_pierna_der_salta;
    }

    public void activar_grande()
    {
        
    }


}