using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    private bool Damaged = false;
    private Animator animator;
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

        if (gameObject.tag == "Mushroom")
        {
            Damaged = (collision.gameObject.tag == "Bullet" || GameManager.instance.monito.superman);
            animator.SetBool("Damaged", Damaged);
            animator.SetInteger("Hp", hpEnemy);
            Damaged = false;
        }
    }
}
