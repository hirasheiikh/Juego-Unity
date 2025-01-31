using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    public int hpEnemy = 3;
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (hpEnemy <= 0) Destroy(gameObject);
            else hpEnemy -= 1;
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Player" && GameManager.instance.monito.superman)
        {
            Destroy(gameObject);
        }
    }
}