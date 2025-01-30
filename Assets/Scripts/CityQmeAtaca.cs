using UnityEngine;
using UnityEngine.SceneManagement;

public class CityQmeAtaca : MonoBehaviour
{
    //public Transform playerTransform;
    public float speed;

    public bool playerInRange = false;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Transform playerTransform = GameManager.instance.monito.transform;
        Vector2 dir = (playerTransform.position - transform.position).normalized;
        if (playerInRange) rb.linearVelocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.monito.Damage(20);
            //string currentSceneName = SceneManager.GetActiveScene().name;
            //SceneManager.LoadScene(name);
            //GameManager.instance.player.Damage();
        }
    }
}
