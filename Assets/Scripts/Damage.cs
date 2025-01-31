using UnityEngine;

public class Damage : MonoBehaviour
{
    public int dmgAmount;

    void Update()
    {   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && !GameManager.instance.monito.superman)
        {
            GameManager.instance.monito.Damage(dmgAmount);
        }
    }
}