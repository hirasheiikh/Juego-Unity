using UnityEngine;

public class Chase : MonoBehaviour
{
    public float minDist;
    public int moveSpeed = 8;
    private Rigidbody2D rb;

    public void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void FixedUpdate()
    {
        Transform monitoTransform = GameManager.instance.monito.transform;
        if (Vector2.Distance(monitoTransform.position, transform.position) < minDist)
        {
            rb.linearVelocityX = (monitoTransform.position - transform.position).normalized.x * moveSpeed;
        }

    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, minDist);
    }
}
