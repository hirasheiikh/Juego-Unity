using UnityEngine;

public class PowerUps : MonoBehaviour
{
    public string playerTag;
    private Rigidbody2D rb;
    
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == playerTag)
        {
            Destroy(gameObject);
            if (gameObject.name == "powerUpHielo")
            {
                if (collision.gameObject.tag == "Player") GameManager.instance.monito.activar_hielo();
            }
            else if (gameObject.name == "powerUpFuego")
            {
                if (collision.gameObject.tag == "Player") GameManager.instance.monito.activar_fuego();
            }
            else if (gameObject.name == "powerUpSalto")
            {
                if (collision.gameObject.tag == "Player") GameManager.instance.monito.activar_salta();
            }
            else if (gameObject.name == "powerUpEstrella")
            {
                if (collision.gameObject.tag == "Player") GameManager.instance.monito.activar_estrella();
            }
            else if (gameObject.name == "powerUpGrande")
            {
                if (collision.gameObject.tag == "Player") GameManager.instance.monito.activar_grande();
            }
            else if (gameObject.name == "powerUpSuperman")
            {
                if (collision.gameObject.tag == "Player") GameManager.instance.monito.activar_superman();
            }
        }
    }
}
