using UnityEngine;

public class CityNoseMueve : MonoBehaviour
{
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameManager.instance.monito.Damage(20);
        }
    }
}