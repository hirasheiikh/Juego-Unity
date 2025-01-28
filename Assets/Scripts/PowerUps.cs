using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public string collisionTag;
    public string playerTag;
    public float speed;

    private Rigidbody2D rb;
    private float direction = 1;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == collisionTag)
        {
            Debug.Log(collision.gameObject.name);
            direction *= -1;
        }
        else if (collision.gameObject.tag == playerTag)
        {
            GameManager.instance.monito.Damage();
            Destroy(gameObject);
        }


    }
}
