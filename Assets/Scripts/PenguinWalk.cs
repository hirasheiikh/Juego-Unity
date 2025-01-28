using UnityEngine;

public class PenguinWalk : MonoBehaviour
{
    public string collisionTag;
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
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
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
            //GameManager.instance.monito.Damage();
            Destroy(gameObject);
        }



    }
}
