using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public string playerTag;
    public float speed;

    private Rigidbody2D rb;
    
    private float direction = 1f;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }
    private void FixedUpdate()
    {
        //rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            //GameManager.instance.monito.Damage();
            Destroy(gameObject);
            if (gameObject.name == "powerUpHielo")
            {
                if (collision.gameObject.tag == "Player") GameManager.instance.monito.activar_hielo();
            }
            else if (gameObject.name == "powerUpFuego")
            {
                if (collision.gameObject.tag == "Player") GameManager.instance.monito.activar_fuego();
            }
        }


    }
}
