using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.InputSystem.InputAction;
using TMPro;

public class Monito : MonoBehaviour
{
    public float speed;
    public float speedEstrella;
    public float jumpSpeed;
    public float jumpSpeedPowerUp;
    public float groundCheckDistance;
    public float shootForce = 50;
    public float bulletLifetime = 5;

    public LayerMask groundMask;
    public Transform spawnPosition;
    public ParticleSystem damageParticle;

    public SpriteRenderer cabeza;
    public SpriteRenderer brazo_izq;
    public SpriteRenderer brazo_der;
    public SpriteRenderer pierna_izq;
    public SpriteRenderer pierna_der;
    public SpriteRenderer body;

    public Sprite Cabeza;
    public Sprite BrazoIzq;
    public Sprite BrazoDer;
    public Sprite PiernaIzq;
    public Sprite PiernaDer;
    public Sprite Body;

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
    private AudioSource _audioSource;

    private float direction = 0f;
    private float directionY = 0;
    private bool grounded = true;
    private float _time;

    private bool _hielo;
    private bool _fuego;
    private bool _estrella;
    private bool _grande;
    private bool _salta;
    public GameObject bolaHielo;
    public GameObject bolaFuego;
    public GameObject bolaEstrella;

    [SerializeField]
    private bool _isPaused;
    public GameObject menu;

    public Slider slider;
    public float hp;
    public float max_hp;

    public TMP_Text text;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();

        GameManager.instance.monito = this;

        _isPaused = false;
        menu.SetActive(false);

        Cabeza = cabeza.sprite;
        PiernaIzq = pierna_izq.sprite;
        PiernaDer = pierna_der.sprite;
        BrazoDer = brazo_der.sprite;
        BrazoIzq = brazo_izq.sprite;
        Body = body.sprite;
    }
    private void FixedUpdate()
    {
        if (_time > 0f)
        {
            _time -= Time.fixedDeltaTime;
            if (_time < 0f)
            {
                _time = 0f;
                desactivarPowerUps();
            }
        }

            rb.linearVelocity = new Vector2(direction * (_estrella ? speedEstrella : speed), rb.linearVelocity.y);
        if (grounded)
        {
            rb.linearVelocity += (_salta ? jumpSpeedPowerUp : jumpSpeed) * Vector2.up * directionY;
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

        slider.value = hp / max_hp;
    }

    public void Pause()
    {
        _isPaused = !_isPaused;
        if (_isPaused)
        {
            Time.timeScale = 0f;
            menu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            menu.SetActive(false);
        }
    }

    public void Damage()
    {
        damageParticle.Play();
        hp = hp - 20;
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

    public void OnPause(CallbackContext ctx)
    {
        if (ctx.performed) Pause();
        if (_isPaused) _audioSource.Play();
    }

    public void OnShoot(CallbackContext ctx)
    {
        if (ctx.performed)
        {
            if (!_isPaused)
            {
                if (_hielo) shootPowerUp(bolaHielo);
                else if (_fuego) shootPowerUp(bolaFuego);
                else if (_estrella) shootPowerUp(bolaEstrella);
            }
        }
    }

    public void shootPowerUp(GameObject prefab_bola)
    {
        GameObject bullet = Instantiate(prefab_bola, spawnPosition.position, Quaternion.identity, null);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bulletRB.linearVelocity = (spawnPosition.position - transform.position).normalized * shootForce * Vector2.right;
        Destroy(bullet, bulletLifetime);
        _time = 1f;
    }

    public void activar_hielo()
    {
        _time = 5;
        cabeza.sprite = sprite_cabeza_hielo;
        pierna_izq.sprite = sprite_pierna_izq_hielo;
        pierna_der.sprite = sprite_pierna_der_hielo;
        brazo_der.sprite = sprite_brazo_der_hielo;
        brazo_izq.sprite = sprite_brazo_izq_hielo;
        body.sprite = sprite_body_hielo;
        _hielo = true;
    }

    public void activar_fuego()
    {
        _time = 5;
        cabeza.sprite = sprite_cabeza_fuego;
        pierna_izq.sprite = sprite_pierna_izq_fuego;
        pierna_der.sprite = sprite_pierna_der_fuego;
        brazo_der.sprite = sprite_brazo_der_fuego;
        brazo_izq.sprite = sprite_brazo_izq_fuego;
        body.sprite = sprite_body_fuego;
        _fuego = true;
    }

    public void activar_superman()
    {
        _time = 5;
        cabeza.sprite = sprite_cabeza_superman;
        pierna_izq.sprite = sprite_pierna_izq_superman;
        pierna_der.sprite = sprite_pierna_der_superman;
        brazo_der.sprite = sprite_brazo_der_superman;
        brazo_izq.sprite = sprite_brazo_izq_superman;
        body.sprite = sprite_body_superman;
    }

    public void activar_estrella()
    {
        _time = 5;
        cabeza.sprite = sprite_cabeza_estrella;
        pierna_izq.sprite = sprite_pierna_izq_estrella;
        pierna_der.sprite = sprite_pierna_der_estrella;
        brazo_der.sprite = sprite_brazo_der_estrella;
        brazo_izq.sprite = sprite_brazo_izq_estrella;
        body.sprite = sprite_body_estrella;
        _estrella = true;
    }

    public void activar_salta()
    {
        _time = 5;
        pierna_izq.sprite = sprite_pierna_izq_salta;
        pierna_der.sprite = sprite_pierna_der_salta;
        _salta = true;
    }

    public void activar_grande()
    {
        _time = 5;
        transform.localScale = new Vector2(2, 2);
        groundCheckDistance *= 1.5f;
        _grande = true;
    }

    public void desactivarPowerUps()
    {
        if (_grande)
        {
            groundCheckDistance /= 1.5f;
            transform.localScale = new Vector2(1, 1);
        }
        cabeza.sprite = Cabeza;
        pierna_izq.sprite = PiernaIzq;
        pierna_der.sprite = PiernaDer;
        brazo_der.sprite = BrazoDer;
        brazo_izq.sprite = BrazoIzq;
        body.sprite = Body;
        _hielo = false;
        _estrella = false;
        _fuego = false;
        _salta = false;
        _grande = false;
    }
}